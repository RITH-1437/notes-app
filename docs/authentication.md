Login

Controller
      │
      ▼
AuthService
      │
      ├────────► PasswordService
      │
      ├────────► JwtService
      │
      ▼
UserRepository


Register
    ↓
User Created
    ↓
JWT Access Token + Refresh Token
    ↓
Client stores tokens
    ↓
Access protected endpoints
    ↓
Access token expires
    ↓
Refresh token issues new access token
    ↓
Logout revokes refresh token
