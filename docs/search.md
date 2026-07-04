# Search, Filter & Sort Notes

## Overview

This feature allows authenticated users to search, filter, and sort their notes.

Only notes belonging to the authenticated user are returned.

---

## Endpoint

GET /api/Notes/search

Authorization: Bearer Token Required

---

## Query Parameters

| Parameter | Type | Description |
|------------|------|-------------|
| Search | string | Search by note title or content |
| Title | string | Filter by exact or partial title (optional) |
| TagId | Guid | Filter notes by tag |
| SortBy | string | Sort by createdAt, updatedAt, or title |
| Descending | bool | Sort descending (true) or ascending (false) |

---

## Search

Example

GET /api/Notes/search?search=sql

Returns all notes containing "sql" in either:

- Title
- Content

---

## Filter by Tag

Example

GET /api/Notes/search?tagId=YOUR_TAG_ID

Returns notes that belong to the specified tag.

---

## Search + Filter

Example

GET /api/Notes/search?search=api&tagId=YOUR_TAG_ID

Returns notes matching the keyword and selected tag.

---

## Sorting

Newest First

GET /api/Notes/search

Oldest First

GET /api/Notes/search?descending=false

Sort by Title

GET /api/Notes/search?sortBy=title

Sort by Updated Date

GET /api/Notes/search?sortBy=updatedAt

---

## Search Flow

User

↓

NotesController

↓

NoteService

↓

NoteRepository

↓

SQL Server

---

## SQL Features

- LIKE search
- Dynamic WHERE clause
- Dynamic ORDER BY
- LEFT JOIN with Tags
- Soft Delete support

---

## Security

- JWT Authentication required
- Only returns notes belonging to the authenticated user
- Tag ownership is validated before filtering

---

## Completed Features

- Search by title
- Search by content
- Filter by tag
- Sort by title
- Sort by created date
- Sort by updated date
- Ascending / Descending sorting
- Soft Delete support
