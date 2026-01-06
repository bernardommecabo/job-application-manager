using FluentValidation;
using ProjectShared.DTOs;
using System.Net;
using System.Text.Json;

namespace ProjectAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var responseModel = new ErrorResponse();

            switch (exception)
            {
                case ValidationException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Message = "Houve erros de validação nos dados enviados.";
                    responseModel.Errors = e.Errors.Select(x => x.ErrorMessage).ToList();
                    break;

                case KeyNotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = exception.Message;
                    break;

                default:
                    Console.WriteLine($"ERRO CRÍTICO DETALHADO: {exception}");
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Message = "Ocorreu um erro interno no servidor.";
                    break;
            }

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var result = JsonSerializer.Serialize(responseModel, options);

            return context.Response.WriteAsync(result);
        }
    }
}