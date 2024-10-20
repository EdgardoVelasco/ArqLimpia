using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestionTransacciones.Interfaces;
using GestionTransacciones.Services;

namespace GestionTransacciones
{
    public class Startup  // La clase Startup debe ser pública
    {
        // Este método configura los servicios que utilizará la aplicación
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ITransaccionService, TransaccionService>();  // Registro del servicio
        }

        // Este método configura el pipeline de peticiones HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // Página de excepción en desarrollo
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  // Mapeo de controladores
            });
        }
    }
}