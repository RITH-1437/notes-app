<template>
  <select
    :value="modelValue"
    class="w-full rounded-xl border border-gray-300 bg-white px-4 py-3 outline-none transition focus:border-indigo-500 md:w-56"
    @change="updateValue"
  >
    <option value="updatedAt-desc">
      Newest First
    </option>

    <option value="updatedAt-asc">
      Oldest First
    </option>

    <option value="title-asc">
      Title (A-Z)
    </option>

    <option value="title-desc">
      Title (Z-A)
    </option>
  </select>
</template>

<script setup lang="ts">
defineProps<{
  modelValue: string
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
