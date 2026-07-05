<template>
  <div>
    <h2 class="text-2xl font-bold text-gray-800">
      Welcome Back 👋
    </h2>

    <p class="mt-2 text-sm text-gray-500">
      Sign in to continue to NotesApp.
    </p>

    <form class="mt-8 space-y-5" @submit.prevent="handleLogin">
      <div>
        <label class="block text-sm font-medium text-gray-700 mb-2">
          Email
        </label>

        <input
          v-model="form.email"
          type="email"
          placeholder="you@example.com"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />
      </div>

      <div>
        <label class="block text-sm font-medium text-gray-700 mb-2">
          Password
        </label>

        <div class="relative">
          <input
            v-model="form.password"
            :type="showPassword ? 'text' : 'password'"
            placeholder="••••••••"
            class="w-full rounded-lg border border-gray-300 px-4 py-3 pr-12 focus:outline-none focus:ring-2 focus:ring-indigo-500"
          />

          <button
            type="button"
            @click="showPassword = !showPassword"
            class="absolute right-3 top-1/2 -translate-y-1/2 text-gray-500"
          >
            {{ showPassword ? '🙈' : '👁️' }}
          </button>
        </div>
      </div>

      <p
        v-if="error"
        class="rounded-lg bg-red-50 border border-red-200 p-3 text-sm text-red-600"
      >
        {{ error }}
      </p>

      <button
        type="submit"
        :disabled="auth.loading"
        class="w-full rounded-lg bg-indigo-600 py-3 font-semibold text-white transition hover:bg-indigo-700 disabled:opacity-50"
      >
        {{ auth.loading ? 'Signing In...' : 'Login' }}
      </button>
    </form>

    <p class="mt-6 text-center text-sm text-gray-500">
      Don't have an account?

      <RouterLink
        to="/register"
        class="font-semibold text-indigo-600 hover:underline"
      >
        Register
      </RouterLink>
    </p>
  </div>
</template>

<script setup lang="ts">
import { onMounted, reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import { toast } from 'vue-sonner'

import { useAuthStore } from '@/stores/auth'
import { getApiErrorMessage } from '@/utils/api-error'

const router = useRouter()
const auth = useAuthStore()

const showPassword = ref(false)
const error = ref('')

const form = reactive({
  email: '',
  password: ''
})

onMounted(() => {
  const notification = sessionStorage.getItem('authNotification')

  if (notification) {
    sessionStorage.removeItem('authNotification')
    toast.warning(notification)
  }
})

async function handleLogin() {
  error.value = ''

  try {
    await auth.login(form)

    await router.push('/')
  } catch (err) {
    error.value = getApiErrorMessage(err, 'Unable to sign in. Please try again.')
  }
}
</script>
