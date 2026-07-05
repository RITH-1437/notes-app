# Phase 2 - Frontend Authentication

## Overview

Phase 2 implements the complete authentication module for NotesApp using Vue 3, Pinia, Axios, and the ASP.NET Core backend.

The frontend now communicates securely with the backend API using JWT authentication and protected routes.

---

# Objectives

- Login
- Register
- Logout
- JWT Authentication
- Route Guards
- Token Persistence
- Axios Interceptors

---

# Features

## Login

- Email & Password
- API Integration
- Loading State
- Error Handling
- Redirect After Login

---

## Register

- Full Name
- Username
- Email
- Password
- Confirm Password
- Password Validation
- API Integration

---

## Authentication Store

Implemented using Pinia.

Responsibilities:

- Login
- Register
- Logout
- Store JWT
- Store Refresh Token
- Restore Session
- Authentication State

---

## Axios

Configured with:

- Base URL
- Request Interceptor
- Authorization Header
- Response Interceptor
- Automatic Unauthorized Handling

---

## Route Protection

Protected Routes:

- Dashboard

Public Routes:

- Login
- Register

Unauthenticated users are redirected to the Login page.

Authenticated users cannot access Login or Register pages.

---

## Token Persistence

JWT and Refresh Token are stored in Local Storage.

Authentication state is restored automatically after refreshing the browser.

---

# Architecture

```text
Login/Register
        │
        ▼
Pinia Store
        │
        ▼
Auth Service
        │
        ▼
Axios
        │
        ▼
ASP.NET Core API
        │
        ▼
SQL Server
```

---

# Files Created

```text
layouts/
    AuthLayout.vue

components/auth/
    LoginForm.vue
    RegisterForm.vue

pages/auth/
    LoginPage.vue
    RegisterPage.vue

stores/
    auth.ts

services/
    auth.service.ts

api/
    axios.ts
```

---

# Testing

Completed:

- User Registration
- User Login
- JWT Storage
- Refresh Browser
- Protected Routes
- Logout
- Unauthorized Redirect

---

# Result

Authentication is fully functional and integrated with the backend.

The application is ready for dashboard development and Notes management.
