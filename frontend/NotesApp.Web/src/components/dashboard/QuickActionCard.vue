<template>
  <RouterLink
    :to="to"
    class="flex items-center justify-between rounded-2xl border border-gray-200 bg-white p-5 shadow-sm transition hover:-translate-y-1 hover:shadow-md"
  >
    <div>
      <h3 class="text-lg font-semibold">
        {{ title }}
      </h3>

      <p class="mt-1 text-sm text-gray-500">
        {{ description }}
      </p>
    </div>

    <div
  class="flex h-14 w-14 items-center justify-center rounded-xl bg-indigo-100 text-2xl"
>
      <slot />
    </div>
  </RouterLink>
</template>

<script setup lang="ts">
defineProps<{
  title: string
  description: string
  to: string
}>()
</script>
