# Notes API Development Log

## Phase 1 - JWT Authentication ✅

### Features Completed

- User Registration
- User Login
- JWT Access Token
- Refresh Token
- Logout
- Password Hashing (BCrypt)
- JWT Authentication Middleware
- JWT Authorization
- Swagger JWT Authorization Support

### Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| POST | /api/Auth/register | Register new account |
| POST | /api/Auth/login | Login |
| POST | /api/Auth/refresh | Refresh access token |
| POST | /api/Auth/logout | Logout |

---

## Phase 2 - Notes CRUD API ✅

### Features Completed

- Create Note
- Get All Notes
- Get Note By Id
- Update Note
- Delete Note (Soft Delete)
- Notes belong to authenticated users only
- JWT Protected Endpoints

### Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| GET | /api/Notes | Get current user's notes |
| GET | /api/Notes/{id} | Get note by id |
| POST | /api/Notes | Create note |
| PUT | /api/Notes/{id} | Update note |
| DELETE | /api/Notes/{id} | Soft delete note |

---

## Edit Flow

```
User clicks Edit
        │
        ▼
GET /api/Notes/{id}
        │
        ▼
Receive Note JSON
        │
        ▼
Frontend fills form
        │
        ▼
User edits Title / Content
        │
        ▼
PUT /api/Notes/{id}
```

---

## Delete Flow

```
User clicks Delete
        │
        ▼
DELETE /api/Notes/{id}
        │
        ▼
Repository performs Soft Delete
(IsDeleted = 1)
        │
        ▼
Return HTTP 204 No Content
```

---

## Security

- JWT Authentication
- Authorization Attribute
- Password Hashing using BCrypt
- Refresh Token support
- Users can only access their own notes
- Soft Delete implementation

---

## Project Architecture

```
Controller
      │
      ▼
Service
      │
      ▼
Repository
      │
      ▼
SQL Server (Dapper)
```

---

## Technologies

- .NET 8 Web API
- SQL Server
- Dapper
- JWT Authentication
- BCrypt
- Swagger
- Repository Pattern
- Service Layer
- REST API

---

## Current Status

✅ Authentication completed

✅ JWT completed

✅ Refresh Token completed

✅ Notes CRUD completed

✅ Soft Delete completed

✅ Swagger Authorization completed

---

## Next Phase

- Tags CRUD
- Note Categories
- Search Notes
- Pagination
- Sorting
- Global Exception Middleware
- Validation
- Unit Testing
