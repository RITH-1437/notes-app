<template>
  <Teleport to="body">
    <div
      v-if="show"
      class="fixed inset-0 z-50 flex items-center justify-center bg-black/50 p-4"
    >
      <div class="w-full max-w-xl rounded-2xl bg-white p-6 shadow-xl">
        <div class="mb-6 flex items-center justify-between">
          <h2 class="text-2xl font-bold">
            {{ mode === 'create' ? 'Create Note' : 'Edit Note' }}
          </h2>

          <button
            type="button"
            aria-label="Close modal"
            class="text-gray-400 transition hover:text-gray-700"
            @click="close"
          >
            <XMarkIcon class="h-6 w-6" />
          </button>
        </div>

        <form
          class="space-y-5"
          @submit.prevent="submit"
        >
          <div>
            <label for="noteTitle" class="mb-2 block text-sm font-medium">
              Title
            </label>

            <input
              id="noteTitle"
              v-model="form.title"
              type="text"
              class="w-full rounded-xl border border-gray-300 px-4 py-3 outline-none transition focus:border-indigo-500"
              placeholder="Enter note title"
              autocomplete="off"
              required
            />
          </div>

          <div>
            <label for="noteContent" class="mb-2 block text-sm font-medium">
              Content
            </label>

            <textarea
              id="noteContent"
              v-model="form.content"
              rows="6"
              class="w-full rounded-xl border border-gray-300 px-4 py-3 outline-none transition focus:border-indigo-500"
              placeholder="Write your note..."
              required
            />
          </div>

          <div>
            <label for="noteTag" class="mb-2 block text-sm font-medium">
              Tag
            </label>

            <select
              id="noteTag"
              v-model="form.tagId"
              class="w-full rounded-xl border border-gray-300 px-4 py-3 outline-none transition focus:border-indigo-500"
            >
              <option value="">
                No Tag
              </option>

              <option
                v-for="tag in tagStore.tags"
                :key="tag.id"
                :value="tag.id"
              >
                {{ tag.name }}
              </option>
            </select>
          </div>

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
              {{ saving
                ? 'Saving...'
                : mode === 'create'
                  ? 'Create Note'
                  : 'Update Note'
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

import { useNoteStore } from '@/stores/note'
import { useTagStore } from '@/stores/tag'

import type { Note } from '@/types/note'

const props = defineProps<{
  show: boolean
  mode: 'create' | 'edit'
  note?: Note | null
}>()

const emit = defineEmits<{
  close: []
  saved: []
}>()

const noteStore = useNoteStore()
const tagStore = useTagStore()

const saving = ref(false)

const form = reactive({
  title: '',
  content: '',
  tagId: ''
})

watch(
  () => props.show,
  async (visible) => {
    if (!visible) return

    if (props.mode === 'edit' && props.note) {
      form.title = props.note.title
      form.content = props.note.content
      form.tagId = props.note.tagId ?? ''
    } else {
      resetForm()
    }
  }
)

function resetForm() {
  form.title = ''
  form.content = ''
  form.tagId = ''
}

function close() {
  resetForm()
  emit('close')
}

async function submit() {
  saving.value = true

  try {
    if (props.mode === 'create') {
      await noteStore.create({
        title: form.title,
        content: form.content,
        tagId: form.tagId || null
      })
    } else if (props.note) {
      await noteStore.update(props.note.id, {
        title: form.title,
        content: form.content,
        tagId: form.tagId || null
      })
    }

    resetForm()
    emit('saved')
  } finally {
    saving.value = false
  }
}
</script>
