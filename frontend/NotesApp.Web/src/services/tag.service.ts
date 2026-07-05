import api from '@/api/axios'

import type { ApiResponse } from '@/types/api'

import type {
  Tag,
  CreateTagRequest,
  UpdateTagRequest
} from '@/types/tag'

export default {
  getAll() {
    return api.get<ApiResponse<Tag[]>>(
      '/Tags'
    )
  },

  getById(id: string) {
    return api.get<ApiResponse<Tag>>(
      `/Tags/${id}`
    )
  },

  create(data: CreateTagRequest) {
    return api.post<ApiResponse<Tag>>(
      '/Tags',
      data
    )
  },

  update(
    id: string,
    data: UpdateTagRequest
  ) {
    return api.put<ApiResponse<Tag>>(
      `/Tags/${id}`,
      data
    )
  },

  remove(id: string) {
    return api.delete<ApiResponse<null>>(
      `/Tags/${id}`
    )
  }
}
