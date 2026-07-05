import axios from 'axios'

import type { ApiErrorResponse } from '@/types/api'

const statusMessages: Record<number, string> = {
  400: 'Please check the information you entered.',
  401: 'Your session has expired. Please sign in again.',
  403: 'You do not have permission to do that.',
  404: 'The requested item could not be found.',
  500: 'The server encountered an error. Please try again later.'
}

export function getApiErrorMessage(
  error: unknown,
  fallback = 'Something went wrong. Please try again.'
): string {
  if (!axios.isAxiosError<ApiErrorResponse>(error)) {
    return error instanceof Error && error.message ? error.message : fallback
  }

  if (error.code === 'ECONNABORTED') {
    return 'The request took too long. Please try again.'
  }

  if (!error.response) {
    return 'Unable to connect to the server. Check your connection and try again.'
  }

  const validationMessage = Object.values(error.response.data?.errors ?? {})
    .flat()
    .find((message) => message.trim().length > 0)

  return (
    validationMessage ??
    error.response.data?.message ??
    statusMessages[error.response.status] ??
    fallback
  )
}
