# 📝 NotesApp

A full-stack Notes application built as a technical assessment using **ASP.NET Core 8 Web API**, **Dapper**, **SQL Server**, and **Vue 3**.

The project follows the **Repository-Service Pattern** and focuses on clean architecture, secure authentication, RESTful API development, and modern full-stack best practices.

---

# 🚀 Tech Stack

## Backend

- ASP.NET Core 8 Web API
- Dapper
- SQL Server
- JWT Authentication
- Refresh Token
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

# 📊 Current Status

🚧 Backend API is feature-complete for the core Notes module and continues to evolve with validation, middleware, frontend integration, and deployment.

---

# ✅ Completed Features

## 🔐 Authentication

- JWT Authentication
- Refresh Token Authentication
- BCrypt Password Hashing
- User Registration
- User Login
- User Logout
- Protected Endpoints
- Swagger JWT Authorization

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
- Filter Notes by Tag
- Sort Notes
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

## 🔗 Notes & Tags Integration

- Assign Tag to Note
- Remove Tag from Note
- Nullable Tag Support
- Retrieve Tag Name with Notes
- SQL LEFT JOIN Integration
- Tag Ownership Validation

---

## 🌐 API Features

- RESTful API
- JWT Authentication
- Swagger Documentation
- Repository-Service Pattern
- Dependency Injection
- Dapper Data Access
- Soft Delete Strategy
- Search & Filtering
- Dynamic Sorting
- User Data Isolation
- FluentValidation
- Global Exception Middleware
- Custom Exceptions
- Consistent Error Responses

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

---

# 📂 Documentation

Project documentation is available inside the **docs/** directory.

- authentication.md
- notes.md
- tags.md
- note-tag.md
- search.md
- setup.md
- tree.md

---

# 📅 Development Roadmap

## ✅ Completed

- JWT Authentication
- Refresh Token
- BCrypt Password Hashing
- Swagger Authorization
- Notes CRUD
- Tags CRUD
- Notes ↔ Tags Integration
- Search Notes
- Filter by Tag
- Dynamic Sorting
- Repository-Service Pattern
- Soft Delete Strategy
- FluentValidation
- Custom Exceptions
- Global Exception Middleware

---

## 🚧 In Progress

- Standard API Response
- Logging

---

## 📌 Planned

### Backend

- Docker Support
- Unit Testing
- Integration Testing
- CI/CD Pipeline
- Azure Deployment

### Frontend

- Vue 3 Authentication
- Notes Dashboard
- Tag Management
- Responsive UI

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

# 🎯 Project Goals

This project is being developed phase by phase to demonstrate professional software engineering practices, including:

- Clean Architecture
- Repository-Service Pattern
- RESTful API Development
- JWT Authentication
- SQL Server Database Design
- Secure Backend Development
- Modern Frontend Development
- Documentation-Driven Development
- Git Version Control
- Production-ready Coding Standards

Each completed phase is documented inside the **docs/** directory before moving to the next milestone.

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

# ⭐ Future Vision

The long-term goal is to transform **NotesApp** into a production-ready full-stack application featuring:

- Authentication & Authorization
- Rich Note Management
- Smart Search
- Responsive Vue Frontend
- Docker Deployment
- Cloud Hosting
- CI/CD Automation
- Comprehensive Testing
- Clean, Maintainable Architecture
