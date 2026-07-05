import { defineStore } from 'pinia'
import authService from '@/services/auth.service'

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
    isAuthenticated: (state) => !!state.accessToken
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

        return response.data
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

        return response.data
      } finally {
        this.loading = false
      }
    },

    logout() {
      this.accessToken = ''
      this.refreshToken = ''

      localStorage.removeItem('accessToken')
      localStorage.removeItem('refreshToken')
    },

    initialize() {
      this.accessToken = localStorage.getItem('accessToken') ?? ''
      this.refreshToken = localStorage.getItem('refreshToken') ?? ''
    }
  }
})
