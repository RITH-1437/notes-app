<template>
  <RouterLink
    :to="`/notes`"
    :aria-label="`View note: ${note.title}`"
    role="link"
    class="block rounded-xl border border-gray-200 bg-white p-5 shadow-sm transition duration-200 hover:-translate-y-1 hover:shadow-lg focus:outline-none focus:ring-2 focus:ring-indigo-500"
  >
    <h3 class="font-semibold text-purple-700">
      {{ note.title }}
    </h3>

    <p class="mt-2 min-h-[40px] line-clamp-2 text-sm text-gray-500">
      {{ note.content }}
    </p>
  </RouterLink>
</template>

<script setup lang="ts">
defineProps<{
  note: {
    id: string
    title: string
    content: string
    tagId: string | null
    tagName: string | null
    createdAt: string
    updatedAt: string | null
  }
}>()
</script>
