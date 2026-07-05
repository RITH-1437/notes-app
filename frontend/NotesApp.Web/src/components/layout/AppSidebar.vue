<template>
  <aside
    class="fixed inset-y-0 left-0 z-40 flex h-screen w-64 flex-col border-r border-gray-200 bg-white"
  >
    <div class="border-b border-gray-200 p-6">
      <AppLogo />
    </div>

    <nav class="flex-1 space-y-2 p-4">
      <RouterLink
        to="/"
        class="flex items-center gap-3 rounded-xl px-4 py-3 transition hover:bg-indigo-50"
        active-class="bg-indigo-100 text-indigo-600"
      >
        <HomeIcon class="h-5 w-5" />
        Dashboard
      </RouterLink>

      <RouterLink
        to="/notes"
        class="flex items-center gap-3 rounded-xl px-4 py-3 transition hover:bg-indigo-50"
        active-class="bg-indigo-100 text-indigo-600"
      >
        <DocumentTextIcon class="h-5 w-5" />
        Notes
      </RouterLink>

      <RouterLink
        to="/tags"
        class="flex items-center gap-3 rounded-xl px-4 py-3 transition hover:bg-indigo-50"
        active-class="bg-indigo-100 text-indigo-600"
      >
        <TagIcon class="h-5 w-5" />
        Tags
      </RouterLink>
    </nav>
  </aside>
</template>

<script setup lang="ts">
import AppLogo from './AppLogo.vue'

import {
  HomeIcon,
  DocumentTextIcon,
  TagIcon
} from '@heroicons/vue/24/outline'
</script>
