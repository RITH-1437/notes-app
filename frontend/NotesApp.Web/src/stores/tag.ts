import { defineStore } from 'pinia'
import { ref } from 'vue'
import { toast } from 'vue-sonner'

import tagService from '@/services/tag.service'

import type {
  Tag,
  CreateTagRequest,
  UpdateTagRequest
} from '@/types/tag'

export const useTagStore = defineStore('tag', () => {
  const tags = ref<Tag[]>([])
  const loading = ref(false)
  const error = ref('')

  async function getAll() {
    loading.value = true
    error.value = ''

    try {
      const response = await tagService.getAll()

      tags.value = response.data.data
    } catch (err: any) {
      error.value =
        err.response?.data?.message ??
        'Unable to load tags.'

      toast.error(error.value)
    } finally {
      loading.value = false
    }
  }

  async function create(data: CreateTagRequest) {
    loading.value = true

    try {
      await tagService.create(data)

      toast.success('Tag created successfully.')

      await getAll()
    } catch (err: any) {
      toast.error(
        err.response?.data?.message ??
        'Unable to create tag.'
      )
    } finally {
      loading.value = false
    }
  }

  async function update(
    id: string,
    data: UpdateTagRequest
  ) {
    loading.value = true

    try {
      await tagService.update(id, data)

      toast.success('Tag updated successfully.')

      await getAll()
    } catch (err: any) {
      toast.error(
        err.response?.data?.message ??
        'Unable to update tag.'
      )
    } finally {
      loading.value = false
    }
  }

  async function remove(id: string) {
    loading.value = true

    try {
      await tagService.remove(id)

      toast.success('Tag deleted successfully.')

      await getAll()
    } catch (err: any) {
      toast.error(
        err.response?.data?.message ??
        'Unable to delete tag.'
      )
    } finally {
      loading.value = false
    }
  }

  return {
    tags,
    loading,
    error,

    getAll,
    create,
    update,
    remove
  }
})
