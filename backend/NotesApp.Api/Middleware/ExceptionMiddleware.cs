using System.Text.Json;
using NotesApp.Api.Exceptions;

namespace NotesApp.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            // The client disconnected. There is no response left to write.
            _logger.LogDebug("Request {TraceId} was cancelled by the client.", context.TraceIdentifier);
        }
        catch (Exception ex)
        {
            if (context.Response.HasStarted)
            {
                _logger.LogError(ex, "An error occurred after the response had started. TraceId: {TraceId}",
                    context.TraceIdentifier);
                throw;
            }

            if (IsExpectedException(ex))
            {
                _logger.LogWarning("Request {TraceId} failed: {Message}",
                    context.TraceIdentifier, ex.Message);
            }
            else
            {
                _logger.LogError(ex, "Unhandled error while processing request {TraceId}.",
                    context.TraceIdentifier);
            }

            await HandleExceptionAsync(context, ex);
        }
    }

    private static bool IsExpectedException(Exception exception) => exception is
        BadRequestException or
        UnauthorizedException or
        UnauthorizedAccessException or
        ForbiddenException or
        NotFoundException;

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            ForbiddenException => StatusCodes.Status403Forbidden,
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        context.Response.StatusCode = statusCode;

        var response = new
        {
            success = false,
            message = statusCode == StatusCodes.Status500InternalServerError
                ? "An unexpected error occurred. Please try again later."
                : exception.Message,
            traceId = context.TraceIdentifier
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response),
            context.RequestAborted);
    }
}
