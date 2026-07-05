<template>
  <div
    class="rounded-2xl border-2 border-dashed border-gray-300 bg-white p-12 text-center"
  >
    <div class="flex justify-center">
      <DocumentTextIcon class="h-16 w-16 text-gray-400" />
    </div>

    <h2 class="mt-6 text-2xl font-bold text-gray-900">
      No notes yet
    </h2>

    <p class="mt-2 text-gray-500">
      Create your first note to organize your ideas.
    </p>
  </div>
</template>

<script setup lang="ts">
import { DocumentTextIcon } from '@heroicons/vue/24/outline'
</script>
