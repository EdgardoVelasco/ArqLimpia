using System.Net;
using System.Text.Json;

namespace GestionTransacciones.Middleware
{
    public class ExcepcionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExcepcionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var respuesta = new
            {
                status = context.Response.StatusCode,
                message = "Ha ocurrido un error en el servidor.",
                details = ex.Message  // En producción puedes omitir los detalles por seguridad
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(respuesta));
        }
    }
}