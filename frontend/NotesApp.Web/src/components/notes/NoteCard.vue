<template>
  <div
    class="rounded-2xl border border-gray-200 bg-white p-6 shadow-sm transition duration-200 hover:-translate-y-1 hover:shadow-lg"
  >
    <div class="flex items-start justify-between">
      <div>
        <h3 class="text-lg font-semibold text-purple-700">
          {{ note.title }}
        </h3>

        <span
          v-if="note.tagName"
          class="mt-2 inline-flex rounded-full bg-indigo-100 px-3 py-1 text-xs font-medium text-indigo-700"
        >
          {{ note.tagName }}
        </span>
      </div>
    </div>

    <p class="mt-4 min-h-[72px] whitespace-pre-line text-sm text-gray-600">
      {{ note.content }}
    </p>

    <div
      class="mt-6 flex items-center justify-between border-t border-gray-100 pt-4"
    >
      <span class="text-xs text-gray-400">
        {{ formatDate(note.updatedAt ?? note.createdAt) }}
      </span>

      <div class="flex gap-2">
        <button
          class="rounded-lg bg-blue-50 px-3 py-2 text-sm font-medium text-blue-600 transition hover:bg-blue-100"
          @click="emit('edit', note)"
        >
          Edit
        </button>

        <button
          class="rounded-lg bg-red-50 px-3 py-2 text-sm font-medium text-red-600 transition hover:bg-red-100"
          @click="emit('delete', note)"
        >
          Delete
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import dayjs from 'dayjs'
import relativeTime from 'dayjs/plugin/relativeTime'

import type { Note } from '@/types/note'

dayjs.extend(relativeTime)

defineProps<{
  note: Note
}>()

const emit = defineEmits<{
  edit: [note: Note]
  delete: [note: Note]
}>()

function formatDate(date: string | Date) {
  return dayjs(date).fromNow()
}
</script>
