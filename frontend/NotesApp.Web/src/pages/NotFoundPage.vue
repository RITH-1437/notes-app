<template>
  <div class="flex min-h-screen items-center justify-center bg-gray-50 px-6">
    <div class="max-w-lg text-center">
      <h1 class="text-8xl font-extrabold text-indigo-600">
        404
      </h1>

      <h2 class="mt-6 text-3xl font-bold text-gray-900">
        Page Not Found
      </h2>

      <p class="mt-4 text-gray-500">
        Sorry, the page you are looking for doesn't exist or has been moved.
      </p>

      <RouterLink
        to="/"
        class="mt-8 inline-flex items-center rounded-xl bg-indigo-600 px-6 py-3 font-medium text-white transition hover:bg-indigo-700"
      >
        Back to Dashboard
      </RouterLink>
    </div>
  </div>
</template>
