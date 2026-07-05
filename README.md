# 📝 NotesApp

A modern full-stack Notes application built with **ASP.NET Core 8 Web API**, **Dapper**, **SQL Server**, and **Vue 3**.

The project follows the **Repository-Service Pattern** and demonstrates clean architecture, secure authentication, RESTful API development, and modern frontend engineering practices.

---

# 🚀 Tech Stack

## Backend

- ASP.NET Core 8 Web API
- Dapper
- SQL Server
- JWT Authentication
- Refresh Token
- BCrypt Password Hashing
- FluentValidation
- Swagger / OpenAPI

## Frontend

- Vue 3
- TypeScript
- Vite
- Vue Router
- Pinia
- Axios
- Tailwind CSS

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

# 📊 Current Status

### ✅ Backend

The backend is feature-complete for the core Notes module, including authentication, notes management, tags, validation, search, filtering, sorting, and global exception handling.

### ✅ Frontend

Frontend is feature-complete, including authentication, dashboard, notes management, tags management, search, filtering, sorting, and toast notifications.

---

# ✅ Completed Features

## 🔐 Authentication

### Backend

- JWT Authentication
- Refresh Token Authentication
- BCrypt Password Hashing
- User Registration
- User Login
- User Logout
- Protected Endpoints
- Swagger JWT Authorization

### Frontend

- Login Page
- Register Page
- Authentication Layout
- JWT Authentication
- Pinia Authentication Store
- Route Guards
- Protected Routes
- Token Persistence
- Logout
- Axios Request Interceptor
- Axios Response Interceptor
- Dashboard
- Notes Management
- Tags Management
- Search, Filter, Sort
- Toast Notifications
- Responsive Dashboard Layout

---

## 📝 Notes

- Create Note
- Get All Notes
- Get Note By Id
- Update Note
- Soft Delete Note
- Search Notes
- Search by Title
- Search by Content
- Filter by Tag
- Dynamic Sorting
- User-specific Notes

---

## 🏷 Tags

- Create Tag
- Get All Tags
- Get Tag By Id
- Update Tag
- Soft Delete Tag
- User-specific Tags

---

## 🔗 Notes & Tags

- Assign Tag to Note
- Remove Tag from Note
- Nullable Tag Support
- Retrieve Tag Name with Notes
- SQL LEFT JOIN
- Tag Ownership Validation

---

## 🌐 Backend Features

- RESTful API
- Repository-Service Pattern
- Dependency Injection
- Dapper
- SQL Server
- Soft Delete
- Search & Filtering
- Dynamic Sorting
- User Data Isolation
- FluentValidation
- Global Exception Middleware
- Custom Exceptions
- Standard API Response
- Consistent Error Responses

---

## 💻 Frontend Features

- Vue 3 Project Setup
- Vite
- Vue Router
- Pinia
- Axios API Client
- Authentication Service
- Authentication Store
- Login & Register Pages
- Route Guards
- JWT Persistence
- Logout
- TypeScript Models
- Responsive Authentication Layout

---

# 🔒 Security

- JWT Bearer Authentication
- Refresh Token Support
- BCrypt Password Hashing
- Authorization Middleware
- User Ownership Validation
- FluentValidation
- Global Exception Middleware
- Protected API Endpoints

---

# 🏗 Architecture

## Backend

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
Dapper
    │
    ▼
SQL Server
```

## Frontend

```text
Pages
    │
    ▼
Pinia Store
    │
    ▼
Services
    │
    ▼
Axios Client
    │
    ▼
ASP.NET Core API
```

---

# 📂 Documentation

Project documentation is available in the **docs/** directory.

## Backend

- authentication.md
- notes.md
- tags.md
- note-tag.md
- search.md
- validation.md
- phase6.md
- setup.md
- tree.md

## Frontend

- phase1.md
- phase2.md
- phase3-frontend.md
- phase4-frontend.md

---

# 📅 Development Roadmap

## ✅ Completed

### Backend

- JWT Authentication
- Refresh Token
- BCrypt Password Hashing
- Swagger Authorization
- Notes CRUD
- Tags CRUD
- Notes ↔ Tags
- Search
- Filter by Tag
- Dynamic Sorting
- Repository-Service Pattern
- Soft Delete
- FluentValidation
- Custom Exceptions
- Global Exception Middleware
- Standard API Response

### Frontend

- Vue 3 Project Setup
- Folder Architecture
- Vue Router
- Pinia
- Axios API Client
- Authentication Service
- Authentication Store
- Login
- Register
- Logout
- Route Guards
- Dashboard Layout
- Notes CRUD
- Tags CRUD
- JWT Persistence
- Axios Interceptors
- Search
- Filter by Tag
- Dynamic Sorting
- Toast Notifications
- Responsive UI
- Type Safety with TypeScript

---

## 🚧 In Progress

## 📌 Planned

### Backend

- Structured Logging
- Docker Support
- Unit Testing
- Integration Testing
- CI/CD
- Azure Deployment

---

# 🛠 Getting Started

## Clone Repository

```bash
git clone https://github.com/your-username/NotesApp.git

cd NotesApp
```

---

## Backend

```bash
cd backend/NotesApp.Api

dotnet restore

dotnet build

dotnet run
```

Swagger

```text
http://localhost:5013/swagger
```

---

## Frontend

```bash
cd frontend/NotesApp.Web

npm install

npm run dev
```

Application

```text
http://localhost:5173
```

---

# 🎯 Project Goals

This project is being developed incrementally to demonstrate professional full-stack software engineering practices.

## Backend

- Clean Architecture
- Repository-Service Pattern
- RESTful API Development
- Authentication & Authorization
- SQL Server Database Design
- Secure API Development

## Frontend

- Modern Vue 3 Architecture
- Component-Based Development
- State Management with Pinia
- API Integration with Axios
- Responsive User Experience
- Type Safety with TypeScript

Every completed phase is documented inside the **docs/** directory before moving to the next milestone.

---

# 👨‍💻 Author

**Rin Nairith**

Full Stack Developer Student

### Backend

- ASP.NET Core
- Dapper
- SQL Server
- MySQL
- Laravel
- Spring Boot

### Frontend

- Vue.js
- TypeScript
- Tailwind CSS
- Pinia
- Axios

---

# ⭐ Future Vision

The long-term goal is to evolve **NotesApp** into a production-ready full-stack application featuring:

- Authentication & Authorization
- Rich Notes Management
- Tag Organization
- Advanced Search & Filtering
- Responsive Vue Dashboard
- Docker Deployment
- Azure Cloud Hosting
- CI/CD Automation
- Unit & Integration Testing
- Production Logging
- Clean, Maintainable Architecture
