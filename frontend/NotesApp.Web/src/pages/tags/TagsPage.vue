<template>
  <div>
    <!-- Header -->
    <div class="mb-8 flex flex-col gap-4 md:flex-row md:items-center md:justify-between">
      <div>
        <h1 class="text-3xl font-bold text-gray-900">
          Tags
        </h1>

        <p class="mt-2 text-gray-500">
          Organize your notes with tags.
        </p>
      </div>

      <button
        class="rounded-xl bg-indigo-600 px-5 py-3 font-medium text-white transition hover:bg-indigo-700"
        @click="openCreateModal"
      >
        + New Tag
      </button>
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
      Loading tags...
    </div>

    <!-- Empty -->
    <div
      v-else-if="store.tags.length === 0"
      class="rounded-2xl border-2 border-dashed border-gray-300 bg-white p-12 text-center"
    >
      <div class="flex justify-center">
        <TagIcon class="h-16 w-16 text-gray-400" />
      </div>

      <h2 class="mt-6 text-2xl font-bold text-gray-900">
        No tags yet
      </h2>

      <p class="mt-2 text-gray-500">
        Create your first tag to organize your notes.
      </p>
    </div>

    <!-- Tags -->
    <div
      v-else
      class="grid gap-6 md:grid-cols-2 xl:grid-cols-3"
    >
      <TagCard
        v-for="tag in store.tags"
        :key="tag.id"
        :tag="tag"
        @edit="openEditModal"
        @delete="openDeleteModal"
      />
    </div>

    <!-- Create -->
    <TagFormModal
      :show="showCreateModal"
      mode="create"
      @close="closeCreateModal"
      @saved="refreshTags"
    />

    <!-- Edit -->
    <TagFormModal
      :show="showEditModal"
      mode="edit"
      :tag="selectedTag"
      @close="closeEditModal"
      @saved="refreshTags"
    />

    <!-- Delete -->
    <DeleteTagModal
      :show="showDeleteModal"
      :tag="selectedTag"
      @close="closeDeleteModal"
      @deleted="refreshTags"
    />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'

import { TagIcon } from '@heroicons/vue/24/outline'

import { useTagStore } from '@/stores/tag'

import type { Tag } from '@/types/tag'

import TagCard from '@/components/tags/TagCard.vue'
import TagFormModal from '@/components/tags/TagFormModal.vue'
import DeleteTagModal from '@/components/tags/DeleteTagModal.vue'

const store = useTagStore()

const showCreateModal = ref(false)
const showEditModal = ref(false)
const showDeleteModal = ref(false)

const selectedTag = ref<Tag | null>(null)

function openCreateModal() {
  showCreateModal.value = true
}

function closeCreateModal() {
  showCreateModal.value = false
}

function openEditModal(tag: Tag) {
  selectedTag.value = tag
  showEditModal.value = true
}

function closeEditModal() {
  selectedTag.value = null
  showEditModal.value = false
}

function openDeleteModal(tag: Tag) {
  selectedTag.value = tag
  showDeleteModal.value = true
}

function closeDeleteModal() {
  selectedTag.value = null
  showDeleteModal.value = false
}

async function refreshTags() {
  closeCreateModal()
  closeEditModal()
  closeDeleteModal()

  await store.getAll()
}

onMounted(async () => {
  await store.getAll()
})
</script>
