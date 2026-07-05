# Project Setup

This guide explains how to set up and run the **NotesApp** project locally.

---

# Prerequisites

Make sure the following software is installed before running the project.

| Software | Recommended Version |
|----------|----------------------|
| .NET SDK | 8.0.x |
| Node.js | 22.x LTS |
| npm | 10.x or later |
| SQL Server | 2022 / 2025 Developer Edition |
| SQL Server Management Studio (SSMS) | Latest |
| Git | Latest |

---

# Project Structure

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
│
├── docs/
│
└── NotesApp.sln
```

---

# Clone Repository

```bash
git clone https://github.com/RITH-1437/notes-app.git
cd notes-app
```

---

# Backend Setup

Navigate to the backend project.

```bash
cd backend/NotesApp.Api
```

Restore NuGet packages.

```bash
dotnet restore
```

Build the project.

```bash
dotnet build
```

Run the API.

```bash
dotnet run
```

The API will start on:

```text
https://localhost:xxxx
http://localhost:xxxx
```

Swagger UI will be available at:

```text
https://localhost:xxxx/swagger
```

---

# Frontend Setup

Navigate to the frontend project.

```bash
cd frontend/NotesApp.Web
```

Install dependencies.

```bash
npm install
```

Run the development server.

```bash
npm run dev
```

Build for production.

```bash
npm run build
```

The frontend will be available at:

```text
http://localhost:5173
```

---

# Database Setup

1. Open **SQL Server Management Studio (SSMS)**.
2. Connect to your local SQL Server instance.
3. Create a database named:

```sql
NotesDb
```

> Database tables and scripts will be added in the `database` directory.

---

# Development Workflow

Start the backend:

```bash
cd backend/NotesApp.Api
dotnet run
```

Start the frontend:

```bash
cd frontend/NotesApp.Web
npm run dev
```

Run both applications simultaneously during development.

---

# Tech Stack

## Backend

- ASP.NET Core 8 Web API
- Dapper
- SQL Server

## Frontend

- Vue 3
- TypeScript
- Vite
- Tailwind CSS
- Pinia
- Axios

---

# Useful Commands

## Backend

```bash
dotnet restore
dotnet build
dotnet run
```

## Frontend

```bash
npm install
npm run dev
npm run build
npm run lint
npm run format
```

---

# Notes

- Use **.NET SDK 8** as specified in `global.json`.
- Use **Node.js 22 LTS** or newer.
- SQL Server Developer Edition is recommended for local development.
- Do not commit `.env` files or build artifacts (`bin`, `obj`, `node_modules`, `dist`).

---

# License

This project is created for learning and technical assessment purposes.