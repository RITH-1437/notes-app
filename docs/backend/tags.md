# Tags API

## Overview

The Tags module allows authenticated users to organize their notes into categories.

Each tag belongs to a single user.

---

## Database Structure

| Column | Type |
|---------|------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| Name | nvarchar(100) |
| CreatedAt | datetime2 |
| UpdatedAt | datetime2 |
| IsDeleted | bit |

---

## Endpoints

| Method | Endpoint |
|---------|----------|
| GET | /api/Tags |
| GET | /api/Tags/{id} |
| POST | /api/Tags |
| PUT | /api/Tags/{id} |
| DELETE | /api/Tags/{id} |

---

## Security

- JWT Authentication
- User Ownership
- Soft Delete

---

## CRUD Flow

```
Create
 ↓
Read
 ↓
Update
 ↓
Soft Delete
```

---

## Architecture

```
Controller
    │
Service
    │
Repository
    │
SQL Server
```

---

## Status

✅ Completed
