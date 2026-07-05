# Validation & Exception Handling

## Overview

Phase 6 improves the quality of the backend by introducing request validation, custom exceptions, and global exception handling.

---

# Features

## FluentValidation

The API validates incoming requests before they reach the service layer.

### Implemented Validators

- RegisterRequestValidator
- LoginRequestValidator
- CreateNoteRequestValidator
- UpdateNoteRequestValidator
- CreateTagRequestValidator
- UpdateTagRequestValidator

Example:

```json
{
    "title": "",
    "content": ""
}
```

Response:

```json
{
    "errors": {
        "Title": [
            "Title is required."
        ]
    }
}
```

---

## Custom Exceptions

The application uses custom exception classes instead of generic exceptions.

### Exceptions

- BadRequestException
- UnauthorizedException
- ForbiddenException
- NotFoundException

Examples:

- Invalid Tag → BadRequestException
- Invalid Login → UnauthorizedException
- Access Another User's Note → ForbiddenException
- Note Not Found → NotFoundException

---

## Global Exception Middleware

A centralized middleware handles all unhandled exceptions.

Instead of returning stack traces, the API returns a clean JSON response.

Example:

```json
{
    "success": false,
    "message": "Note not found."
}
```

HTTP Status Codes:

| Status | Description |
|---------|-------------|
| 400 | Bad Request |
| 401 | Unauthorized |
| 403 | Forbidden |
| 404 | Not Found |
| 500 | Internal Server Error |

---

## Benefits

- Centralized error handling
- Consistent API responses
- Cleaner controllers
- Better separation of concerns
- Easier maintenance
- Production-ready error handling

---

## Architecture

```text
Controller
      │
      ▼
Service
      │
      ├── Success
      │       │
      │       ▼
      │   Return Result
      │
      └── Error
              │
              ▼
     Throw Custom Exception
              │
              ▼
 ExceptionMiddleware
              │
              ▼
 JSON Error Response
```

---

## Phase Summary

Completed in Phase 6:

- FluentValidation
- Request Validation
- Custom Exceptions
- Exception Middleware
- Clean Controllers
- Improved Service Layer
