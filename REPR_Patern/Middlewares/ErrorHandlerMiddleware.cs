using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using REPR_Pattern.ActionResults;
using REPR_Pattern.Exceptions;
using REPR_Pattern.Factories;

namespace REPR_Pattern.Middlewares
{
    public sealed class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IActionResultExecutor<ObjectResult> _actionResultExecutor;

        public ErrorHandlerMiddleware(RequestDelegate next,
            ILogger<ErrorHandlerMiddleware> logger,
            IActionResultExecutor<ObjectResult> actionResultExecutor)
        {
            _next = next;
            _logger = logger;
            _actionResultExecutor = actionResultExecutor;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exceptions.InvalidDataException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                await SendResponseAsync(context, new BadRequestObjectResult(ResponseFactory.Failed(ex.Error)));
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                await SendResponseAsync(context, new NotFoundObjectResult(ResponseFactory.Failed(ex.Error)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception message: {ex.Message}.\nInner exception: {ex.InnerException?.Message}.\nStack trace: {ex.StackTrace}.");
                await SendResponseAsync(context, new InternalServerErrorObjectResult(ResponseFactory.ServerError(ex.Message)));
            }
        }

        /// <summary>
        /// Executes passed action result.
        /// </summary>
        /// <param name="context">HttpContext of current request.</param>
        /// <param name="objectResult">Instance of ObjectResult implementation, contains error data.</param>
        private Task SendResponseAsync(HttpContext context, ObjectResult objectResult) =>
                _actionResultExecutor.ExecuteAsync(new ActionContext() { HttpContext = context }, objectResult);
    }
}
