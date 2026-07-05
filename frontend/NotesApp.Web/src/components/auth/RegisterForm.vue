<template>
  <div>
    <h2 class="text-2xl font-bold text-gray-800">
      Create Account
    </h2>

    <p class="mt-2 text-sm text-gray-500">
      Join NotesApp today.
    </p>

    <form class="mt-8 space-y-5" @submit.prevent="handleRegister">
      <div>
        <label for="fullName" class="block text-sm font-medium text-gray-700 mb-2">
          Full Name
        </label>

        <input
          id="fullName"
          v-model="form.fullName"
          type="text"
          autocomplete="name"
          placeholder="Full Name"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />
      </div>

      <div>
        <label for="username" class="block text-sm font-medium text-gray-700 mb-2">
          Username
        </label>

        <input
          id="username"
          v-model="form.username"
          type="text"
          autocomplete="username"
          placeholder="Username"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />
      </div>

      <div>
        <label for="registerEmail" class="block text-sm font-medium text-gray-700 mb-2">
          Email
        </label>

        <input
          id="registerEmail"
          v-model="form.email"
          type="email"
          autocomplete="email"
          placeholder="Email"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />
      </div>

      <div class="relative">
        <label for="registerPassword" class="block text-sm font-medium text-gray-700 mb-2">
          Password
        </label>

        <input
          id="registerPassword"
          v-model="form.password"
          :type="showPassword ? 'text' : 'password'"
          autocomplete="new-password"
          placeholder="Password"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 pr-12 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />

        <button
          type="button"
          aria-label="Toggle password visibility"
          class="absolute right-3 top-1/2 -translate-y-1/2 text-gray-500"
          @click="showPassword = !showPassword"
        >
          {{ showPassword ? '🙈' : '👁️' }}
        </button>
      </div>

      <div class="relative">
        <label for="confirmPassword" class="block text-sm font-medium text-gray-700 mb-2">
          Confirm Password
        </label>

        <input
          id="confirmPassword"
          v-model="confirmPassword"
          :type="showConfirmPassword ? 'text' : 'password'"
          autocomplete="new-password"
          placeholder="Confirm Password"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 pr-12 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />

        <button
          type="button"
          aria-label="Toggle confirm password visibility"
          class="absolute right-3 top-1/2 -translate-y-1/2 text-gray-500"
          @click="showConfirmPassword = !showConfirmPassword"
        >
          {{ showConfirmPassword ? '🙈' : '👁️' }}
        </button>
      </div>

      <p
        v-if="error"
        role="alert"
        class="rounded-lg border border-red-200 bg-red-50 p-3 text-sm text-red-600"
      >
        {{ error }}
      </p>

      <button
        type="submit"
        :disabled="auth.loading"
        class="w-full rounded-lg bg-indigo-600 py-3 font-semibold text-white hover:bg-indigo-700 disabled:opacity-50"
      >
        {{ auth.loading ? 'Creating...' : 'Create Account' }}
      </button>
    </form>

    <p class="mt-6 text-center text-sm text-gray-500">
      Already have an account?

      <RouterLink
        to="/login"
        class="font-semibold text-indigo-600 hover:underline"
      >
        Login
      </RouterLink>
    </p>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue'
import { useRouter } from 'vue-router'

import { useAuthStore } from '@/stores/auth'
import { getApiErrorMessage } from '@/utils/api-error'

const router = useRouter()
const auth = useAuthStore()

const error = ref('')

const showPassword = ref(false)
const showConfirmPassword = ref(false)

const confirmPassword = ref('')

const form = reactive({
  fullName: '',
  username: '',
  email: '',
  password: ''
})

async function handleRegister() {
  error.value = ''

  if (form.password !== confirmPassword.value) {
    error.value = 'Passwords do not match.'

    return
  }

  try {
    await auth.register(form)

    await router.push('/')
  } catch (err) {
    error.value = getApiErrorMessage(err, 'Unable to create your account. Please try again.')
  }
}
</script>
