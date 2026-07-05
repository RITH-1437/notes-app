<template>
  <header
    class="flex h-16 items-center justify-between border-b border-gray-200 bg-white px-6"
  >
    <div>
      <h2 class="text-2xl font-bold text-gray-900">
        {{ pageTitle }}
      </h2>
    </div>

    <div class="relative flex items-center gap-3">
      <button
        type="button"
        class="flex items-center gap-3 rounded-lg p-1 transition-colors hover:bg-gray-100"
        @click.stop="toggleDropdown"
      >
        <div
          class="flex h-10 w-10 items-center justify-center rounded-full bg-indigo-600 font-semibold text-white"
        >
          {{ avatar }}
        </div>

        <div class="hidden text-left md:block">
          <p class="font-semibold text-gray-900">
            {{ username }}
          </p>

          <p class="text-xs text-gray-500">
            NotesApp User
          </p>
        </div>
      </button>

      <!-- Dropdown -->
      <div
        v-if="dropdownOpen"
        class="absolute right-0 top-14 z-50 w-44 rounded-lg border border-gray-200 bg-white py-1 shadow-lg"
      >
        <button
          type="button"
          class="flex w-full items-center gap-2 px-4 py-2 text-sm text-red-600 transition-colors hover:bg-red-50"
          @click="handleLogout"
        >
          <ArrowRightOnRectangleIcon class="h-4 w-4" />
          Sign out
        </button>
      </div>
    </div>
  </header>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted } from 'vue'
import { useRoute } from 'vue-router'
import { ArrowRightOnRectangleIcon } from '@heroicons/vue/24/outline'
import { useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const authStore = useAuthStore()
const router = useRouter()
const route = useRoute()

const dropdownOpen = ref(false)

const username = computed(() => authStore.username || 'User')
const avatar = computed(() => username.value.charAt(0).toUpperCase())

const pageTitle = computed(() => {
  const titles: Record<string, string> = {
    '/': 'Dashboard',
    '/notes': 'Notes',
    '/tags': 'Tags'
  }

  return titles[route.path] || 'NotesApp'
})

function toggleDropdown() {
  dropdownOpen.value = !dropdownOpen.value
}

function closeDropdown() {
  dropdownOpen.value = false
}

async function handleLogout() {
  dropdownOpen.value = false
  await authStore.logout()
  router.push('/login')
}

onMounted(() => document.addEventListener('click', closeDropdown))
onUnmounted(() => document.removeEventListener('click', closeDropdown))
</script>
