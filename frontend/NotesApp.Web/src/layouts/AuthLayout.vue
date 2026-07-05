<template>
  <div class="min-h-screen bg-gray-100 flex items-center justify-center p-6">
    <div class="w-full max-w-md">
      <div class="text-center mb-8">
        <h1 class="text-4xl font-bold text-indigo-600">
          📝 NotesApp
        </h1>

        <p class="mt-2 text-gray-500">
          Organize your notes effortlessly.
        </p>
      </div>

      <div class="bg-white rounded-2xl shadow-xl p-8">
        <RouterView />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
</script>
