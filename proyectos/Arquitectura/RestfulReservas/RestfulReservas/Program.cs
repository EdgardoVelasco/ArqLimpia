using Microsoft.EntityFrameworkCore;
using RestfulReservas.Business.Services;
using RestfulReservas.Data;
using RestfulReservas.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Inyección Contexto de base de datos*/
builder.Services.AddDbContext<MySQLDBContext>(builder => {
    builder.UseMySQL("server=localhost;port=3306;user=root;password=1234;database=reservas");
    
    });

/*Inyección de Repositorios*/
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoomRepository>();

/*Inyección Servicios*/
builder.Services.AddScoped<IReservationService, ReservationService>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
