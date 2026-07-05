<template>
  <div>
    <!-- Greeting -->
    <div class="mb-8">
      <h1 class="text-4xl font-bold text-gray-900">
        {{ greeting }} <HandRaisedIcon class="inline-block h-9 w-9 align-middle" />
      </h1>
    </div>

    <!-- Error -->
    <div
      v-if="error"
      role="alert"
      class="mb-6 flex items-center justify-between gap-4 rounded-lg border border-red-200 bg-red-50 p-4 text-sm text-red-700"
    >
      <span>{{ error }}</span>

      <button
        type="button"
        class="shrink-0 font-semibold hover:underline disabled:opacity-50"
        :disabled="loading"
        @click="loadDashboard"
      >
        {{ loading ? 'Retrying...' : 'Try again' }}
      </button>
    </div>

    <!-- Statistics -->
    <div class="grid gap-6 md:grid-cols-3">
      <StatCard
        title="Total Notes"
        :value="notes.length"
      >
        <DocumentTextIcon class="h-6 w-6 text-indigo-600" />
      </StatCard>

      <StatCard
        title="Total Tags"
        :value="tags.length"
      >
        <TagIcon class="h-6 w-6 text-indigo-600" />
      </StatCard>

      <StatCard
        title="Recent Notes"
        :value="recentNotes"
      >
        <CalendarDaysIcon class="h-6 w-6 text-indigo-600" />
      </StatCard>
    </div>

    <!-- Quick Actions -->
    <section class="mt-10">
      <h2 class="mb-4 text-2xl font-bold">
        Quick Actions
      </h2>

      <div class="grid gap-6 md:grid-cols-2">
        <QuickActionCard
          title="Create Note"
          description="Write a new note"
          to="/notes"
        >
          <PlusIcon class="h-7 w-7 text-indigo-600" />
        </QuickActionCard>

        <QuickActionCard
          title="Manage Tags"
          description="Organize your tags"
          to="/tags"
        >
          <TagIcon class="h-7 w-7 text-indigo-600" />
        </QuickActionCard>
      </div>
    </section>

    <!-- Recent Notes -->
    <section class="mt-10">
      <h2 class="mb-4 text-2xl font-bold">
        Recent Notes
      </h2>

      <!-- Loading -->
      <div
        v-if="loading"
        class="rounded-xl border border-gray-200 bg-white p-8 text-center text-gray-500"
      >
        Loading notes...
      </div>

      <!-- Empty -->
      <div
        v-else-if="notes.length === 0"
        class="rounded-xl border-2 border-dashed border-gray-300 bg-white p-8 text-center"
      >
        <h3 class="text-lg font-semibold text-gray-900">
          No notes yet
        </h3>

        <p class="mt-2 text-gray-500">
          Create your first note to get started.
        </p>
      </div>

      <!-- Notes -->
      <div
        v-else
        class="grid gap-5"
      >
        <RecentNoteCard
          v-for="note in notes.slice(0, 5)"
          :key="note.id"
          :note="note"
        />
      </div>
    </section>
  </div>
</template>

<script setup lang="ts">
import { computed, onMounted, ref } from 'vue'

import StatCard from '@/components/dashboard/StatCard.vue'
import QuickActionCard from '@/components/dashboard/QuickActionCard.vue'
import RecentNoteCard from '@/components/dashboard/RecentNoteCard.vue'

import noteService from '@/services/note.service'
import tagService from '@/services/tag.service'

import type { Note } from '@/types/note'
import type { Tag } from '@/types/tag'

import { getApiErrorMessage } from '@/utils/api-error'

import {
  DocumentTextIcon,
  TagIcon,
  CalendarDaysIcon,
  PlusIcon,
  HandRaisedIcon
} from '@heroicons/vue/24/outline'

const notes = ref<Note[]>([])
const tags = ref<Tag[]>([])

const loading = ref(false)
const error = ref('')

const recentNotes = computed(() => Math.min(notes.value.length, 5))

const greeting = computed(() => {
  const hour = new Date().getHours()

  if (hour < 12) return 'Rise & Shine'
  if (hour < 18) return 'Good Afternoon'

  return 'Good Evening'
})

async function loadDashboard() {
  loading.value = true
  error.value = ''

  try {
    const [noteResponse, tagResponse] = await Promise.all([
      noteService.getAll(),
      tagService.getAll()
    ])

    notes.value = noteResponse.data.data
    tags.value = tagResponse.data.data
  } catch (err) {
    error.value = getApiErrorMessage(
      err,
      'Unable to load your dashboard.'
    )
  } finally {
    loading.value = false
  }
}

onMounted(loadDashboard)
</script>
