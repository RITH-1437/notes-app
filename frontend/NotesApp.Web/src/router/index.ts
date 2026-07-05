import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from '@/stores/auth'

import AuthLayout from '@/layouts/AuthLayout.vue'
import AppLayout from '@/layouts/AppLayout.vue'

import LoginPage from '@/pages/auth/LoginPage.vue'
import RegisterPage from '@/pages/auth/RegisterPage.vue'
import DashboardPage from '@/pages/DashboardPage.vue'

const router = createRouter({
  history: createWebHistory(),

  routes: [
    {
      path: '/',
      component: AppLayout,
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
