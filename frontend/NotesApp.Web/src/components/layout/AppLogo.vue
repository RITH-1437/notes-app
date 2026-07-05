<template>
  <RouterLink
    to="/"
    class="flex items-center gap-3"
  >
    <div
      class="flex h-10 w-10 items-center justify-center rounded-xl bg-indigo-600 text-white shadow"
    >
      <DocumentTextIcon class="h-5 w-5" />
    </div>

    <div>
      <h1 class="text-lg font-bold text-gray-900">
        NotesApp
      </h1>

      <p class="text-xs text-gray-500">
        Smart Notes
      </p>
    </div>
  </RouterLink>
</template>

<script setup lang="ts">
import { DocumentTextIcon } from '@heroicons/vue/24/outline'
</script>
