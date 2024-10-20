using GestionTransacciones.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddSingleton<GestionTransacciones.Interfaces.ITransaccionService, GestionTransacciones.Services.TransaccionService>();

var app = builder.Build();

// Middleware de manejo de excepciones
app.UseMiddleware<ExcepcionMiddleware>();

// Configurar la API
app.MapControllers();

app.Run();