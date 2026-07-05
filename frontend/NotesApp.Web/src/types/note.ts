export interface Note {
  id: string
  title: string
  content: string
  tagId: string | null
  tagName: string | null
  createdAt: string
  updatedAt: string | null
}

export interface CreateNoteRequest {
  title: string
  content: string
  tagId?: string | null
}

export interface UpdateNoteRequest {
  title: string
  content: string
  tagId?: string | null
}

export interface NoteQuery {
  keyword?: string
  tagId?: string
  sortBy?: string
  descending?: boolean
}
