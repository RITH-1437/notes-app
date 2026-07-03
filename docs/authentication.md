Register

Controller
      │
      ▼
AuthService
      │
      ▼
PasswordService
      │
      ▼
UserRepository
      │
      ▼
SQL Server


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