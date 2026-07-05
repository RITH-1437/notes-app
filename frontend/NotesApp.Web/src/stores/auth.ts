import { defineStore } from 'pinia'
import { toast } from 'vue-sonner'

import authService from '@/services/auth.service'
import { getApiErrorMessage } from '@/utils/api-error'

import type {
  LoginRequest,
  RegisterRequest
} from '@/types/auth'

export const useAuthStore = defineStore('auth', {
  state: () => ({
    accessToken: localStorage.getItem('accessToken') ?? '',
    refreshToken: localStorage.getItem('refreshToken') ?? '',
    loading: false
  }),

  getters: {
    isAuthenticated: (state) => !!state.accessToken,

    username: (state): string => {
      if (!state.accessToken) return ''
      try {
        const payload = JSON.parse(atob(state.accessToken.split('.')[1]))
        return (
          payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] ||
          payload['unique_name'] ||
          payload['name'] ||
          payload['sub'] ||
          ''
        )
      } catch {
        return ''
      }
    }
  },

  actions: {
    async login(data: LoginRequest) {
      this.loading = true

      try {
        const response = await authService.login(data)

        const result = response.data.data

        this.accessToken = result.accessToken
        this.refreshToken = result.refreshToken

        localStorage.setItem('accessToken', result.accessToken)
        localStorage.setItem('refreshToken', result.refreshToken)

        toast.success(response.data.message || 'Welcome back!')

        return response.data
      } catch (error) {
        toast.error(getApiErrorMessage(error, 'Unable to sign in. Please try again.'))
        throw error
      } finally {
        this.loading = false
      }
    },

    async register(data: RegisterRequest) {
      this.loading = true

      try {
        const response = await authService.register(data)

        const result = response.data.data

        this.accessToken = result.accessToken
        this.refreshToken = result.refreshToken

        localStorage.setItem('accessToken', result.accessToken)
        localStorage.setItem('refreshToken', result.refreshToken)

        toast.success(response.data.message || 'Your account has been created.')

        return response.data
      } catch (error) {
        toast.error(getApiErrorMessage(error, 'Unable to create your account. Please try again.'))
        throw error
      } finally {
        this.loading = false
      }
    },

    async logout() {
      const refreshToken = this.refreshToken

      try {
        if (refreshToken) {
          await authService.logout(refreshToken)
        }

        toast.success('You have been signed out.')
      } catch (error) {
        toast.warning('You were signed out locally, but the server could not be reached.')
      } finally {
        this.accessToken = ''
        this.refreshToken = ''

        localStorage.removeItem('accessToken')
        localStorage.removeItem('refreshToken')
      }
    },

    initialize() {
      this.accessToken = localStorage.getItem('accessToken') ?? ''
      this.refreshToken = localStorage.getItem('refreshToken') ?? ''
    }
  }
})
