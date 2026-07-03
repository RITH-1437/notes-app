# Project Structure

```text
NotesApp/
|-- backend/
|   `-- NotesApp.Api/
|       |-- Configurations/
|       |   |-- DatabaseSettings.cs
|       |   `-- JwtSettings.cs
|       |-- Constants/
|       |-- Controllers/
|       |   |-- AuthController.cs
|       |   |-- HealthController.cs
|       |   `-- NotesController.cs
|       |-- Data/
|       |   `-- SqlConntectionFactory.cs
|       |-- Extensions/
|       |-- Middleware/
|       |-- Models/
|       |   |-- Entities/
|       |   |   |-- Note.cs
|       |   |   |-- RefreshToken.cs
|       |   |   |-- Tage.cs
|       |   |   `-- User.cs
|       |   |-- Requests/
|       |   |   |-- CreateNoteRequest.cs
|       |   |   |-- LoginRequest.cs
|       |   |   |-- RefreshTokenRequest.cs
|       |   |   |-- RegisterRequest.cs
|       |   |   `-- UpdateNoteRequest.cs
|       |   `-- Responses/
|       |       |-- ApiResponse.cs
|       |       |-- AuthResponse.cs
|       |       `-- NoteResponse.cs
|       |-- Properties/
|       |   `-- launchSettings.json
|       |-- Repositories/
|       |   |-- Implementations/
|       |   |   |-- NoteRepository.cs
|       |   |   |-- RefreshTokenRepository.cs
|       |   |   `-- UserRepository.cs
|       |   `-- Interfaces/
|       |       |-- INoteRepository.cs
|       |       |-- IRefreshTokenRepository.cs
|       |       `-- IUserRepository.cs
|       |-- Services/
|       |   |-- Implementations/
|       |   |   |-- AuthService.cs
|       |   |   |-- JwtService.cs
|       |   |   |-- NoteService.cs
|       |   |   `-- PasswordService.cs
|       |   `-- Interfaces/
|       |       |-- IAuthServices.cs
|       |       |-- IJwtServices.cs
|       |       |-- INoteService.cs
|       |       `-- IPasswordService.cs
|       |-- NotesApp.Api.csproj
|       |-- NotesApp.Api.http
|       |-- Program.cs
|       |-- appsettings.Development.json
|       `-- appsettings.json
|-- database/
|   |-- schema/
|   |   |-- 001_CreateTables.sql
|   |   |-- 002_CreateIndexes.sql
|   |   `-- 003_SeedData.sql
|   |-- seed/
|   `-- README.md
|-- docs/
|   |-- authentication_flow.md
|   |-- setup.md
|   `-- tree.md
|-- frontend/
|   `-- NotesApp.Web/
|       |-- .vscode/
|       |   |-- extensions.json
|       |   `-- settings.json
|       |-- public/
|       |   `-- favicon.ico
|       |-- src/
|       |   |-- assets/
|       |   |-- components/
|       |   |-- composables/
|       |   |-- layouts/
|       |   |-- pages/
|       |   |-- router/
|       |   |-- services/
|       |   |-- stores/
|       |   |-- types/
|       |   |-- utils/
|       |   |-- App.vue
|       |   `-- main.ts
|       |-- .editorconfig
|       |-- .gitattributes
|       |-- .gitignore
|       |-- .oxlintrc.json
|       |-- .prettierrc.json
|       |-- README.md
|       |-- env.d.ts
|       |-- eslint.config.ts
|       |-- index.html
|       |-- package-lock.json
|       |-- package.json
|       |-- tsconfig.app.json
|       |-- tsconfig.json
|       |-- tsconfig.node.json
|       `-- vite.config.ts
|-- .editorconfig
|-- .gitignore
|-- global.json
|-- NotesApp.sln
`-- README.md
```

Generated directories such as `bin`, `obj`, `node_modules`, and `dist` are omitted.
