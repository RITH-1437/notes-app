import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

import AuthLayout from '@/layouts/AuthLayout.vue'
import DashboardLayout from '@/layouts/DashboardLayout.vue'

import LoginPage from '@/pages/auth/LoginPage.vue'
import RegisterPage from '@/pages/auth/RegisterPage.vue'
import DashboardPage from '@/pages/DashboardPage.vue'
import NotesPage from '@/pages/notes/NotesPage.vue'
import TagsPage from '@/pages/tags/TagsPage.vue'
import NotFoundPage from '@/pages/NotFoundPage.vue'

const router = createRouter({
  history: createWebHistory(),

  routes: [
    {
      path: '/',
      component: DashboardLayout,
      children: [
        {
          path: '',
          component: DashboardPage
        }
      ]
    },

    {
      path: '/login',
      component: AuthLayout,
      children: [
        {
          path: '',
          component: LoginPage
        }
      ]
    },

    {
      path: '/register',
      component: AuthLayout,
      children: [
        {
          path: '',
          component: RegisterPage
        }
      ]
    },

    {
      path: '/notes',
      component: DashboardLayout,
      children: [
        {
          path: '',
          component: NotesPage
        }
      ]
    },

    {
      path: '/tags',
      component: DashboardLayout,
      children: [
        {
          path: '',
          component: TagsPage
        }
      ]
    },

    {
      path: '/:pathMatch(.*)*',
      component: NotFoundPage
    }
  ]
})

router.beforeEach((to) => {
  const auth = useAuthStore()

  // User is not logged in
  if (
    !auth.isAuthenticated &&
    to.path !== '/login' &&
    to.path !== '/register'
  ) {
    return '/login'
  }

  // User is already logged in
  if (
    auth.isAuthenticated &&
    (to.path === '/login' || to.path === '/register')
  ) {
    return '/'
  }
})

export default router
