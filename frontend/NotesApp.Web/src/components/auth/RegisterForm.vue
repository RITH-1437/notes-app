<template>
  <div>
    <h2 class="text-2xl font-bold text-gray-800">
      Create Account ✨
    </h2>

    <p class="mt-2 text-sm text-gray-500">
      Join NotesApp today.
    </p>

    <form class="mt-8 space-y-5" @submit.prevent="handleRegister">
      <input
        v-model="form.fullName"
        type="text"
        placeholder="Full Name"
        class="w-full rounded-lg border border-gray-300 px-4 py-3 focus:outline-none focus:ring-2 focus:ring-indigo-500"
      />

      <input
        v-model="form.username"
        type="text"
        placeholder="Username"
        class="w-full rounded-lg border border-gray-300 px-4 py-3 focus:outline-none focus:ring-2 focus:ring-indigo-500"
      />

      <input
        v-model="form.email"
        type="email"
        placeholder="Email"
        class="w-full rounded-lg border border-gray-300 px-4 py-3 focus:outline-none focus:ring-2 focus:ring-indigo-500"
      />

      <div class="relative">
        <input
          v-model="form.password"
          :type="showPassword ? 'text' : 'password'"
          placeholder="Password"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 pr-12 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />

        <button
          type="button"
          class="absolute right-3 top-1/2 -translate-y-1/2"
          @click="showPassword = !showPassword"
        >
          {{ showPassword ? '🙈' : '👁️' }}
        </button>
      </div>

      <div class="relative">
        <input
          v-model="confirmPassword"
          :type="showConfirmPassword ? 'text' : 'password'"
          placeholder="Confirm Password"
          class="w-full rounded-lg border border-gray-300 px-4 py-3 pr-12 focus:outline-none focus:ring-2 focus:ring-indigo-500"
        />

        <button
          type="button"
          class="absolute right-3 top-1/2 -translate-y-1/2"
          @click="showConfirmPassword = !showConfirmPassword"
        >
          {{ showConfirmPassword ? '🙈' : '👁️' }}
        </button>
      </div>

      <p
        v-if="error"
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
import { toast } from 'vue-sonner'

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
    toast.error(error.value)
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
