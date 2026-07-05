import { defineStore } from 'pinia'
import { ref } from 'vue'
import { toast } from 'vue-sonner'

import tagService from '@/services/tag.service'
import { getApiErrorMessage } from '@/utils/api-error'

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
    } catch (err) {
      const message = getApiErrorMessage(err, 'Unable to load tags.')

      toast.error(message)
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
    } catch (err) {
      toast.error(getApiErrorMessage(err, 'Unable to create tag.'))
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
    } catch (err) {
      toast.error(getApiErrorMessage(err, 'Unable to update tag.'))
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
    } catch (err) {
      toast.error(getApiErrorMessage(err, 'Unable to delete tag.'))
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
