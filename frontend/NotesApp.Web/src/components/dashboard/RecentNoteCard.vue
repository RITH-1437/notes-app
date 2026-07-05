<template>
  <div
    class="rounded-xl border border-gray-200 bg-white p-5 shadow-sm transition duration-200 hover:-translate-y-1 hover:shadow-lg"
  >
    <h3 class="font-semibold text-purple-700">
      {{ note.title }}
    </h3>

    <p class="mt-2 min-h-[42px] line-clamp-2 text-sm text-gray-500">
      {{ note.content }}
    </p>

    <p class="mt-4 text-xs text-gray-400">
      {{ formatDate(note.updatedAt ?? note.createdAt) }}
    </p>
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

function formatDate(date: string | Date) {
  return dayjs(date).fromNow()
}
</script>
