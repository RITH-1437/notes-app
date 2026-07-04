# 📝 NotesApp

A full-stack Notes application built as a technical assessment using **ASP.NET Core 8 Web API**, **Dapper**, **SQL Server**, and **Vue 3**.

The project follows the **Repository-Service Pattern** and focuses on clean architecture, secure authentication, RESTful API design, and modern full-stack development practices.

---

# 🚀 Tech Stack

## Backend

- ASP.NET Core 8 Web API
- Dapper
- SQL Server
- JWT Authentication
- BCrypt Password Hashing
- Swagger / OpenAPI

## Frontend

- Vue 3
- TypeScript
- Tailwind CSS
- Pinia
- Axios

---

# 📁 Project Structure

```text
NotesApp/
│
├── backend/
│   └── NotesApp.Api/
│
├── frontend/
│   └── NotesApp.Web/
│
├── database/
│   ├── schema/
│   └── seed/
│
├── docs/
│
└── README.md
```

---

# ✅ Current Status

🚧 Backend API is under active development.

## Completed

### Authentication

- JWT Authentication
- BCrypt Password Hashing
- User Registration
- User Login
- Refresh Token
- Logout
- Swagger JWT Authorization

### Notes

- Create Note
- Get All Notes
- Get Note By Id
- Update Note
- Soft Delete Note
- User-specific Notes

### Tags

- Create Tag
- Get All Tags
- Get Tag By Id
- Update Tag
- Soft Delete Tag
- User-specific Tags

### Architecture

- Repository Pattern
- Service Layer
- Dependency Injection
- SQL Server + Dapper
- RESTful API Design

---

# 📌 Features

## 🔐 Authentication

- User Registration
- User Login
- JWT Access Token
- Refresh Token
- Logout
- BCrypt Password Hashing
- Protected Endpoints

---

## 📝 Notes Management

- Create Notes
- View All Notes
- View Note Details
- Update Notes
- Soft Delete Notes
- JWT Protected
- User-specific Data

---

## 🏷 Tags Management

- Create Tags
- View All Tags
- View Tag Details
- Update Tags
- Soft Delete Tags
- JWT Protected
- User-specific Data

---

# 🔒 API Security

- JWT Bearer Authentication
- BCrypt Password Hashing
- Refresh Token Support
- Authorization Middleware
- User Ownership Validation
- Soft Delete Strategy

---

# 🏗 Architecture

```text
Client
   │
   ▼
Controllers
   │
   ▼
Services
   │
   ▼
Repositories
   │
   ▼
SQL Server (Dapper)
```

---

# 📂 Documentation

Project documentation is available inside the **docs/** directory.

- authentication.md
- notes.md
- tags.md
- setup.md
- tree.md

---

# 📅 Development Roadmap

## ✅ Completed

- JWT Authentication
- Refresh Token
- Swagger Authorization
- Notes CRUD
- Tags CRUD
- Soft Delete
- Repository-Service Pattern

## 🚧 Next

- Notes ↔ Tags Integration
- Search Notes
- Pagination
- Sorting
- Validation
- Global Exception Middleware

## 📌 Planned

- Vue 3 Frontend
- Dashboard
- Profile Management
- Docker Support
- Unit Testing
- CI/CD Pipeline
- Azure Deployment

---

# 🛠 Getting Started

## Backend

```bash
cd backend/NotesApp.Api
dotnet restore
dotnet build
dotnet run
```

API Documentation:

```
https://localhost:xxxx/swagger
```

---

## Frontend

```bash
cd frontend/NotesApp.Web
npm install
npm run dev
```

---

# 👨‍💻 Author

**Rin Nairith**

Full Stack Developer Student

### Technologies

- ASP.NET Core
- SQL Server
- Dapper
- Vue.js
- TypeScript
- Laravel
- Spring Boot
- MySQL

---

## ⭐ Project Goal

This project is being developed step by step to demonstrate professional backend and frontend development practices, including authentication, REST APIs, clean architecture, database design, and modern web technologies.

Each completed phase is documented in the `docs/` folder before moving on to the next milestone.
