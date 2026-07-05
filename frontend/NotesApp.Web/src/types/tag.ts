export interface Tag {
  id: string
  name: string
  createdAt: string
  updatedAt: string | null
}

export interface CreateTagRequest {
  name: string
}

export interface UpdateTagRequest {
  name: string
}
