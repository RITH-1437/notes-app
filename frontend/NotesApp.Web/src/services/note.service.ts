import api from '@/api/axios'

import type {
  ApiResponse
} from '@/types/api'

import type {
  Note,
  CreateNoteRequest,
  UpdateNoteRequest,
  NoteQuery
} from '@/types/note'

export default {
  getAll() {
    return api.get<ApiResponse<Note[]>>('/Notes')
  },

  getById(id: string) {
    return api.get<ApiResponse<Note>>(`/Notes/${id}`)
  },

  create(data: CreateNoteRequest) {
    return api.post<ApiResponse<Note>>(
      '/Notes',
      data
    )
  },

  update(id: string, data: UpdateNoteRequest) {
    return api.put<ApiResponse<Note>>(
      `/Notes/${id}`,
      data
    )
  },

  delete(id: string) {
    return api.delete<ApiResponse<null>>(
      `/Notes/${id}`
    )
  },

  search(params: NoteQuery) {
    return api.get<ApiResponse<Note[]>>(
      '/Notes/search',
      {
        params
      }
    )
  }
}
