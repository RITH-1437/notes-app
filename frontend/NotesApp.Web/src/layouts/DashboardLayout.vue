<template>
  <div class="flex min-h-screen bg-gray-100">

    <AppSidebar />

    <div class="flex flex-1 flex-col pl-64">
      <AppHeader />

      <main class="flex-1 p-6">
        <RouterView />
      </main>
    </div>

  </div>
</template>

<script setup lang="ts">
import AppHeader from '@/components/layout/AppHeader.vue'
import AppSidebar from '@/components/layout/AppSidebar.vue'
</script>
