using Microsoft.EntityFrameworkCore;
using MVCApp.Models.DataSource;
using MVCApp.Models.Repository;
using MVCApp.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/*Add Context DB Injection*/
builder.Services.AddDbContext<AppDBContext>(
    builder=>builder.UseMySQL("server=localhost;port=3306;user=root;password=1234;database=mvc"));


/*Add Repositories*/
builder.Services.AddScoped<ProductRepository>();

/*Add Services*/
builder.Services.AddScoped<IProductService, ProductServiceImpl>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
