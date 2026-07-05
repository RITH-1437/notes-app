# Notes & Tags Integration

## Overview

This phase integrates the Notes and Tags modules, allowing each note to optionally belong to a tag.

A user can:

- Create notes with or without a tag.
- Assign an existing tag to a note.
- Change the tag when updating a note.
- Retrieve the tag name together with note information.

Only tags owned by the authenticated user can be assigned to a note.

---

# Database Relationship

```
Users
  │
  ├── Notes
  │      │
  │      └── TagId (Nullable)
  │
  └── Tags
```

Relationship:

```
One User
    ├── Many Notes
    └── Many Tags

One Tag
    └── Many Notes
```

---

# Notes Table

| Column | Type |
|---------|------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| TagId | uniqueidentifier (Nullable) |
| Title | nvarchar |
| Content | nvarchar |
| CreatedAt | datetime2 |
| UpdatedAt | datetime2 |
| IsDeleted | bit |

---

# Tags Table

| Column | Type |
|---------|------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| Name | nvarchar |
| CreatedAt | datetime2 |
| UpdatedAt | datetime2 |
| IsDeleted | bit |

---

# Features

## Create Note

A note may be created:

- With a tag
- Without a tag

Example:

```json
{
    "title": "Math Homework",
    "content": "Finish Chapter 5",
    "tagId": "TAG_GUID"
}
```

Without tag:

```json
{
    "title": "Shopping",
    "content": "Buy milk"
}
```

---

## Update Note

A note can:

- Change its title
- Change its content
- Change its tag
- Remove its tag by sending:

```json
{
    "tagId": null
}
```

---

## Get Notes

Each note returns its associated tag information.

Example:

```json
{
    "id": "...",
    "title": "Math Homework",
    "content": "Finish Chapter 5",
    "tagId": "...",
    "tagName": "Study",
    "createdAt": "...",
    "updatedAt": null
}
```

---

# SQL Join

The Notes API retrieves tag information using a LEFT JOIN.

```sql
SELECT
    n.*,
    t.Name AS TagName
FROM Notes n
LEFT JOIN Tags t
    ON n.TagId = t.Id;
```

Using a LEFT JOIN ensures notes without a tag are still returned.

---

# Security

The service validates ownership before assigning a tag.

Validation rules:

- Tag must exist.
- Tag must belong to the authenticated user.
- Invalid tags are rejected.

Example error:

```
Invalid tag.
```

---

# Architecture

```
Controller
      │
      ▼
NoteService
      │
      ├── NoteRepository
      │
      └── TagRepository
              │
              ▼
         SQL Server
```

---

# API Flow

```
Create Tag
      │
      ▼
Create Note
      │
      ▼
Assign Tag
      │
      ▼
Save Note
      │
      ▼
Retrieve Note
      │
      ▼
Return TagName
```

---

# Testing Checklist

- ✅ Create note with tag
- ✅ Create note without tag
- ✅ Get all notes with TagName
- ✅ Get note by ID with TagName
- ✅ Update note tag
- ✅ Remove tag from note
- ✅ Reject invalid TagId
- ✅ Restrict access to user-owned tags

---

# Status

✅ Completed

Phase 4 successfully integrates Notes and Tags while maintaining JWT authentication, user ownership validation, soft delete behavior, and a clean Repository-Service architecture.
