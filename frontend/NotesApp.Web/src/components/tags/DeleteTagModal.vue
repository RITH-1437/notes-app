<template>
  <Teleport to="body">
    <div
      v-if="show"
      class="fixed inset-0 z-50 flex items-center justify-center bg-black/50 p-4"
    >
      <div class="w-full max-w-md rounded-2xl bg-white p-6 shadow-xl">
        <!-- Header -->
        <div class="flex items-center gap-3">
          <div
            class="flex h-12 w-12 items-center justify-center rounded-full bg-red-100 text-red-600"
          >
            <TrashIcon class="h-6 w-6" />
          </div>

          <div>
            <h2 class="text-xl font-bold text-gray-900">
              Delete Tag
            </h2>

            <p class="text-sm text-gray-500">
              This action cannot be undone.
            </p>
          </div>
        </div>

        <!-- Content -->
        <div class="mt-6">
          <p class="text-gray-700">
            Are you sure you want to delete
            <strong class="font-semibold">
              {{ tag?.name }}
            </strong>
            ?
          </p>
        </div>

        <!-- Footer -->
        <div class="mt-8 flex justify-end gap-3">
          <button
            type="button"
            class="rounded-xl border border-gray-300 px-5 py-2 transition hover:bg-gray-100"
            @click="close"
          >
            Cancel
          </button>

          <button
            type="button"
            :disabled="loading"
            class="rounded-xl bg-red-600 px-5 py-2 text-white transition hover:bg-red-700 disabled:cursor-not-allowed disabled:opacity-50"
            @click="remove"
          >
            {{ loading ? 'Deleting...' : 'Delete' }}
          </button>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<script setup lang="ts">
import { ref } from 'vue'

import { TrashIcon } from '@heroicons/vue/24/outline'

import { useTagStore } from '@/stores/tag'

import type { Tag } from '@/types/tag'

const props = defineProps<{
  show: boolean
  tag: Tag | null
}>()

const emit = defineEmits<{
  close: []
  deleted: []
}>()

const tagStore = useTagStore()

const loading = ref(false)

function close() {
  emit('close')
}

async function remove() {
  if (!props.tag) return

  loading.value = true

  try {
    await tagStore.remove(props.tag.id)

    emit('deleted')
  } finally {
    loading.value = false
  }
}
</script>
