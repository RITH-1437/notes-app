<template>
  <div class="flex flex-col gap-4 md:flex-row">
    <input
      :value="modelValue"
      type="text"
      placeholder="Search notes..."
      aria-label="Search notes"
      class="flex-1 rounded-xl border border-gray-300 px-4 py-3 outline-none transition focus:border-indigo-500"
      @input="updateValue"
    />

    <button
      type="button"
      class="rounded-xl bg-indigo-600 px-6 py-3 text-white transition hover:bg-indigo-700"
      @click="$emit('search')"
    >
      Search
    </button>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  modelValue: string
}>()

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
  (e: 'search'): void
}>()

function updateValue(event: Event) {
  emit(
    'update:modelValue',
    (event.target as HTMLInputElement).value
  )
}
</script>
