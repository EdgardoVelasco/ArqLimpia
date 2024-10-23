using Micro_Producto.Model.DataSource;
using Micro_Producto.Model.Repositories;
using Micro_Producto.Model.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var ConnectionString = Environment.GetEnvironmentVariable("CONN_STR");

/*Add Db Context con variable de ambiente y cadena de conexión*/
builder.Services.AddDbContext<AppDBContext>(
    obj => {
        obj.UseMySQL(
            ConnectionString??
            builder.Configuration.GetConnectionString("DefaultConnection")
            ??"");
          }
    );

/*Allow Origins*/
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllOrigins",
        configurePolicy: policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
}); 

/*Injection Services*/
builder.Services.AddScoped<DogRepository>();

builder.Services.AddScoped<IDogService, DogServiceImpl>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

/*activar globalmente*/
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
