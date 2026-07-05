<template>
  <div
    class="rounded-2xl border border-gray-200 bg-white p-6 shadow-sm transition duration-200 hover:-translate-y-1 hover:shadow-lg"
  >
    <div class="flex items-center justify-between">
      <div>
        <span
          class="inline-flex rounded-full bg-indigo-100 px-3 py-1 text-xs font-semibold text-indigo-700"
        >
          Tag
        </span>

        <h3 class="mt-3 text-xl font-semibold text-gray-900">
          {{ tag.name }}
        </h3>
      </div>
    </div>

    <div class="mt-6 border-t border-gray-100 pt-4">
      <div class="flex justify-end gap-2">
        <button
          type="button"
          :aria-label="`Edit tag: ${tag.name}`"
          class="rounded-lg bg-blue-50 px-4 py-2 text-sm font-medium text-blue-600 transition hover:bg-blue-100"
          @click="emit('edit', tag)"
        >
          Edit
        </button>

        <button
          type="button"
          :aria-label="`Delete tag: ${tag.name}`"
          class="rounded-lg bg-red-50 px-4 py-2 text-sm font-medium text-red-600 transition hover:bg-red-100"
          @click="emit('delete', tag)"
        >
          Delete
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  tag: {
    id: string
    name: string
    createdAt: string
    updatedAt: string | null
  }
}>()

const emit = defineEmits<{
  edit: [tag: { id: string, name: string, createdAt: string, updatedAt: string | null }]
  delete: [tag: { id: string, name: string, createdAt: string, updatedAt: string | null }]
}>()
</script>
