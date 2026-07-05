import { defineStore } from 'pinia'
import { ref } from 'vue'
import { toast } from 'vue-sonner'

import noteService from '@/services/note.service'
import { getApiErrorMessage } from '@/utils/api-error'

import type {
  Note,
  CreateNoteRequest,
  UpdateNoteRequest,
  NoteQuery
} from '@/types/note'

export const useNoteStore = defineStore('note', () => {
  const notes = ref<Note[]>([])
  const loading = ref(false)
  const error = ref('')

  async function getAll() {
    loading.value = true
    error.value = ''

    try {
      const response = await noteService.getAll()
      notes.value = response.data.data
    } catch (errorResponse) {
      error.value = getApiErrorMessage(errorResponse, 'Unable to load notes.')

      toast.error(error.value)
    } finally {
      loading.value = false
    }
  }

  async function create(data: CreateNoteRequest) {
    try {
      await noteService.create(data)

      toast.success('Note created successfully.')

      await getAll()
    } catch (errorResponse) {
      toast.error(getApiErrorMessage(errorResponse, 'Unable to create note.'))
    }
  }

  async function update(
    id: string,
    data: UpdateNoteRequest
  ) {
    try {
      await noteService.update(id, data)

      toast.success('Note updated successfully.')

      await getAll()
    } catch (errorResponse) {
      toast.error(getApiErrorMessage(errorResponse, 'Unable to update note.'))
    }
  }

  async function remove(id: string) {
    try {
      await noteService.delete(id)

      toast.success('Note deleted successfully.')

      await getAll()
    } catch (errorResponse) {
      toast.error(getApiErrorMessage(errorResponse, 'Unable to delete note.'))
    }
  }

  async function search(query: NoteQuery) {
    loading.value = true

    try {
      const response = await noteService.search(query)

      notes.value = response.data.data
    } catch (errorResponse) {
      toast.error(getApiErrorMessage(errorResponse, 'Search failed.'))
    } finally {
      loading.value = false
    }
  }

  return {
    notes,
    loading,
    error,

    getAll,
    create,
    update,
    remove,
    search
  }
})
