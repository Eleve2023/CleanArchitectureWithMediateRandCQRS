using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;

namespace Api
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly Dictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(EntityNotFoundException), HandleEntityNotFoundException },
            };
        }

        private void HandleEntityNotFoundException(ExceptionContext context)
        {
            EntityNotFoundException exception = context.Exception as EntityNotFoundException ?? throw new InvalidOperationException("The exception is not of the expected type.");
            ProblemDetails details = new()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The requested resource was not found.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            //Log.Error(context.Exception, "Handling exception:");

            Type type = context.Exception.GetType();
            if (_exceptionHandlers.TryGetValue(type, out Action<ExceptionContext>? value))
            {
                value.Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            ProblemDetails details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            ValidationProblemDetails details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

    }
}
