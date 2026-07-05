import api from '@/api/axios'

import type {
  LoginRequest,
  RegisterRequest,
  AuthData
} from '@/types/auth'

import type { ApiResponse } from '@/types/api'

export default {
  login(data: LoginRequest) {
    return api.post<ApiResponse<AuthData>>(
      '/Auth/login',
      data
    )
  },

  register(data: RegisterRequest) {
    return api.post<ApiResponse<AuthData>>(
      '/Auth/register',
      data
    )
  },

  refresh(refreshToken: string) {
    return api.post<ApiResponse<AuthData>>(
      '/Auth/refresh',
      {
        refreshToken
      }
    )
  },

  logout(refreshToken: string) {
    return api.post<ApiResponse<null>>(
      '/Auth/logout',
      {
        refreshToken
      }
    )
  }
}
