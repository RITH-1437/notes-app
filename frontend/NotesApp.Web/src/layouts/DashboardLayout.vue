<template>
  <div class="flex min-h-screen bg-gray-100">

    <AppSidebar
      :open="sidebarOpen"
      @close="sidebarOpen = false"
    />

    <div
      class="flex flex-1 flex-col transition-all duration-200 lg:pl-64"
      :class="{ 'pl-0': !sidebarOpen }"
    >
      <AppHeader @toggle-sidebar="toggleSidebar" />

      <main class="flex-1 p-4 sm:p-6">
        <RouterView />
      </main>
    </div>

    <div
      v-if="sidebarOpen"
      class="fixed inset-0 z-40 bg-black/50 lg:hidden"
      @click="sidebarOpen = false"
    />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

import AppHeader from '@/components/layout/AppHeader.vue'
import AppSidebar from '@/components/layout/AppSidebar.vue'

const sidebarOpen = ref(false)

function toggleSidebar() {
  sidebarOpen.value = !sidebarOpen.value
}
</script>
