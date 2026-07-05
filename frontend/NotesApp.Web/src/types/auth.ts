export interface LoginRequest {
  email: string
  password: string
}

export interface RegisterRequest {
  fullName: string
  username: string
  email: string
  password: string
}

export interface AuthData {
  accessToken: string
  refreshToken: string
  expiresAt: string
}
