<template>
  <select
    :value="modelValue"
    aria-label="Filter notes by tag"
    class="w-full rounded-xl border border-gray-300 px-4 py-3 outline-none transition focus:border-indigo-500 md:w-64"
    @change="updateValue"
  >
    <option value="">
      All Tags
    </option>

    <option
      v-for="tag in tags"
      :key="tag.id"
      :value="tag.id"
    >
      {{ tag.name }}
    </option>
  </select>
</template>

<script setup lang="ts">
import type { Tag } from '@/types/tag'

defineProps<{
  modelValue: string
  tags: Tag[]
}>()

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
}>()

function updateValue(event: Event) {
  emit(
    'update:modelValue',
    (event.target as HTMLSelectElement).value
  )
}
</script>
