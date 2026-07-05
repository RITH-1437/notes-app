import axios from 'axios'

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL ?? 'http://localhost:5013/api',
  timeout: 15_000,
  headers: {
    'Content-Type': 'application/json'
  }
})

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('accessToken')

  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }

  return config
})

api.interceptors.response.use(
  (response) => response,
  (error) => {
    const requestUrl = error.config?.url ?? ''
    const isAuthenticationRequest = /^\/Auth\/(login|register|refresh)$/.test(requestUrl)
    const hasSession = Boolean(localStorage.getItem('accessToken'))

    if (error.response?.status === 401 && hasSession && !isAuthenticationRequest) {
      localStorage.removeItem('accessToken')
      localStorage.removeItem('refreshToken')
      sessionStorage.setItem(
        'authNotification',
        'Your session has expired. Please sign in again.'
      )

      if (window.location.pathname !== '/login') {
        window.location.assign('/login')
      }
    }

    return Promise.reject(error)
  }
)

export default api
