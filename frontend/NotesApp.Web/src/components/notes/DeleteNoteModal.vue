<template>
  <Teleport to="body">
    <div
      v-if="show"
      class="fixed inset-0 z-50 flex items-center justify-center bg-black/50 p-4"
    >
      <div class="w-full max-w-md rounded-2xl bg-white p-6 shadow-xl">
        <div class="flex items-center gap-3">
          <div
            class="flex h-12 w-12 items-center justify-center rounded-full bg-red-100 text-red-600"
          >
            <TrashIcon class="h-6 w-6" />
          </div>

          <div>
            <h2 class="text-xl font-bold">
              Delete Note
            </h2>

            <p class="text-sm text-gray-500">
              This action cannot be undone.
            </p>
          </div>
        </div>

        <div class="mt-6">
          <p class="text-gray-700">
            Are you sure you want to delete
            <strong>{{ note?.title }}</strong>?
          </p>
        </div>

        <div class="mt-8 flex justify-end gap-3">
          <button
            type="button"
            class="rounded-xl border px-5 py-2 hover:bg-gray-100"
            @click="emit('close')"
          >
            Cancel
          </button>

          <button
            type="button"
            :disabled="loading"
            class="rounded-xl bg-red-600 px-5 py-2 text-white hover:bg-red-700 disabled:opacity-50"
            @click="remove"
          >
            {{ loading ? 'Deleting...' : 'Delete' }}
          </button>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<script setup lang="ts">
import { ref } from 'vue'

import { TrashIcon } from '@heroicons/vue/24/outline'

import { useNoteStore } from '@/stores/note'

import type { Note } from '@/types/note'

const props = defineProps<{
  show: boolean
  note: Note | null
}>()

const emit = defineEmits<{
  close: []
  deleted: []
}>()

const store = useNoteStore()

const loading = ref(false)

async function remove() {
  if (!props.note) return

  loading.value = true

  try {
    await store.remove(props.note.id)

    emit('deleted')
  } finally {
    loading.value = false
  }
}
</script>
