<template>
  <Teleport to="body">
    <div
      v-if="show"
      class="fixed inset-0 z-50 flex items-center justify-center bg-black/50 p-4"
    >
      <div class="w-full max-w-md rounded-2xl bg-white p-6 shadow-xl">
        <!-- Header -->
        <div class="mb-6 flex items-center justify-between">
          <h2 class="text-2xl font-bold">
            {{ mode === 'create' ? 'Create Tag' : 'Edit Tag' }}
          </h2>

          <button
            class="text-gray-400 transition hover:text-gray-700"
            @click="close"
          >
            <XMarkIcon class="h-6 w-6" />
          </button>
        </div>

        <!-- Form -->
        <form
          class="space-y-5"
          @submit.prevent="submit"
        >
          <div>
            <label class="mb-2 block text-sm font-medium">
              Tag Name
            </label>

            <input
              v-model="form.name"
              type="text"
              placeholder="Enter tag name"
              class="w-full rounded-xl border border-gray-300 px-4 py-3 outline-none transition focus:border-indigo-500"
              required
            />
          </div>

          <!-- Footer -->
          <div class="flex justify-end gap-3 pt-2">
            <button
              type="button"
              class="rounded-xl border border-gray-300 px-5 py-2 transition hover:bg-gray-100"
              @click="close"
            >
              Cancel
            </button>

            <button
              type="submit"
              :disabled="saving"
              class="rounded-xl bg-indigo-600 px-5 py-2 text-white transition hover:bg-indigo-700 disabled:cursor-not-allowed disabled:opacity-50"
            >
              {{
                saving
                  ? 'Saving...'
                  : mode === 'create'
                    ? 'Create Tag'
                    : 'Update Tag'
              }}
            </button>
          </div>
        </form>
      </div>
    </div>
  </Teleport>
</template>

<script setup lang="ts">
import { reactive, ref, watch } from 'vue'

import { XMarkIcon } from '@heroicons/vue/24/outline'

import { useTagStore } from '@/stores/tag'

import type { Tag } from '@/types/tag'

const props = defineProps<{
  show: boolean
  mode: 'create' | 'edit'
  tag?: Tag | null
}>()

const emit = defineEmits<{
  close: []
  saved: []
}>()

const tagStore = useTagStore()

const saving = ref(false)

const form = reactive({
  name: ''
})

watch(
  () => props.show,
  (visible) => {
    if (!visible) return

    if (props.mode === 'edit' && props.tag) {
      form.name = props.tag.name
    } else {
      resetForm()
    }
  }
)

function resetForm() {
  form.name = ''
}

function close() {
  resetForm()
  emit('close')
}

async function submit() {
  saving.value = true

  try {
    if (props.mode === 'create') {
      await tagStore.create({
        name: form.name
      })
    } else if (props.tag) {
      await tagStore.update(props.tag.id, {
        name: form.name
      })
    }

    resetForm()

    emit('saved')
  } finally {
    saving.value = false
  }
}
</script>
