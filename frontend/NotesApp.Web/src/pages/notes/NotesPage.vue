<template>
  <div>
    <!-- Header -->
    <div class="mb-8 flex flex-col gap-4 md:flex-row md:items-center md:justify-between">
      <div>
        <h1 class="text-3xl font-bold text-gray-900">
          Notes
        </h1>

        <p class="mt-2 text-gray-500">
          Manage all your personal notes.
        </p>
      </div>

      <button
        class="rounded-xl bg-indigo-600 px-5 py-3 font-medium text-white transition hover:bg-indigo-700"
        @click="openCreateModal"
      >
        + New Note
      </button>
    </div>

    <!-- Search & Filter -->
    <div
      class="mb-8 grid gap-4 rounded-2xl border border-gray-200 bg-white p-5 shadow-sm lg:grid-cols-3"
    >
      <SearchBar
        v-model="keyword"
        @search="searchNotes"
      />

      <TagFilter
        v-model="selectedTag"
        :tags="tagStore.tags"
      />

      <SortSelect
        v-model="sortOption"
      />
    </div>

    <!-- Error -->
    <div
      v-if="store.error"
      class="mb-6 rounded-xl border border-red-200 bg-red-50 p-4 text-red-700"
    >
      {{ store.error }}
    </div>

    <!-- Loading -->
    <div
      v-if="store.loading"
      class="rounded-xl bg-white p-10 text-center shadow-sm"
    >
      Loading notes...
    </div>

    <!-- Empty -->
    <EmptyNote
      v-else-if="store.notes.length === 0"
    />

    <!-- Notes -->
    <div
      v-else
      class="grid gap-6 md:grid-cols-2 xl:grid-cols-3"
    >
      <NoteCard
        v-for="note in store.notes"
        :key="note.id"
        :note="note"
        @edit="openEditModal"
        @delete="openDeleteModal"
      />
    </div>

    <!-- Create -->
    <NoteFormModal
      :show="showCreateModal"
      mode="create"
      @close="closeCreateModal"
      @saved="refreshNotes"
    />

    <!-- Edit -->
    <NoteFormModal
      :show="showEditModal"
      mode="edit"
      :note="selectedNote"
      @close="closeEditModal"
      @saved="refreshNotes"
    />

    <!-- Delete -->
    <DeleteNoteModal
      :show="showDeleteModal"
      :note="selectedNote"
      @close="closeDeleteModal"
      @deleted="refreshNotes"
    />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'

import { useNoteStore } from '@/stores/note'
import { useTagStore } from '@/stores/tag'

import type { Note } from '@/types/note'

import EmptyNote from '@/components/notes/EmptyNote.vue'
import NoteCard from '@/components/notes/NoteCard.vue'
import NoteFormModal from '@/components/notes/NoteFormModal.vue'
import DeleteNoteModal from '@/components/notes/DeleteNoteModal.vue'

import SearchBar from '@/components/notes/SearchBar.vue'
import TagFilter from '@/components/notes/TagFilter.vue'
import SortSelect from '@/components/notes/SortSelect.vue'

const store = useNoteStore()
const tagStore = useTagStore()

const showCreateModal = ref(false)
const showEditModal = ref(false)
const showDeleteModal = ref(false)

const selectedNote = ref<Note | null>(null)

const keyword = ref('')
const selectedTag = ref('')
const sortOption = ref('updatedAt-desc')

function openCreateModal() {
  showCreateModal.value = true
}

function closeCreateModal() {
  showCreateModal.value = false
}

function openEditModal(note: Note) {
  selectedNote.value = note
  showEditModal.value = true
}

function closeEditModal() {
  selectedNote.value = null
  showEditModal.value = false
}

function openDeleteModal(note: Note) {
  selectedNote.value = note
  showDeleteModal.value = true
}

function closeDeleteModal() {
  selectedNote.value = null
  showDeleteModal.value = false
}

async function refreshNotes() {
  closeCreateModal()
  closeEditModal()
  closeDeleteModal()

  await searchNotes()
}

async function searchNotes() {
  const [sortBy, direction] = sortOption.value.split('-')

  await store.search({
    keyword: keyword.value || undefined,
    tagId: selectedTag.value || undefined,
    sortBy,
    descending: direction === 'desc'
  })
}

watch(
  [selectedTag, sortOption],
  async () => {
    await searchNotes()
  }
)

onMounted(async () => {
  await tagStore.getAll()
  await searchNotes()
})
</script>
