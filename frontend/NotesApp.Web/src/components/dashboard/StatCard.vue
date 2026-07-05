<template>
  <div
    class="rounded-2xl border border-gray-200 bg-white p-6 shadow-sm transition duration-200 hover:-translate-y-1 hover:shadow-lg"
  >
    <div class="flex items-center justify-between">
      <div>
        <p class="text-sm text-gray-500">
          {{ title }}
        </p>

        <h2 class="mt-2 text-3xl font-bold">
          {{ value }}
        </h2>
      </div>

      <div
        class="flex h-12 w-12 items-center justify-center rounded-xl bg-indigo-100"
      >
        <slot />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  title: string
  value: string | number
}>()
</script>
