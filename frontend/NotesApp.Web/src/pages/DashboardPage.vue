<template>
  <div class="min-h-screen bg-gray-100">
    <header class="bg-white shadow">
      <div class="mx-auto flex max-w-7xl items-center justify-between px-6 py-4">
        <h1 class="text-2xl font-bold text-indigo-600">
          📝 NotesApp
        </h1>

        <button
          @click="logout"
          class="rounded-lg bg-red-500 px-4 py-2 text-white transition hover:bg-red-600"
        >
          Logout
        </button>
      </div>
    </header>

    <main class="mx-auto max-w-7xl p-6">
      <div class="rounded-xl bg-white p-8 shadow">
        <h2 class="text-3xl font-bold">
          Welcome 👋
        </h2>

        <p class="mt-3 text-gray-500">
          You have successfully logged in.
        </p>
      </div>
    </main>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

const router = useRouter()
const auth = useAuthStore()

async function logout() {
  try {
    if (auth.refreshToken) {
      // Call backend logout endpoint
      // (We'll improve this in the next step)
      // await authService.logout(auth.refreshToken)
    }
  } finally {
    auth.logout()
    router.push('/login')
  }
}
</script>
