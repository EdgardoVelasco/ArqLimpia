using Microsoft.EntityFrameworkCore;
using MVCApp.Models.Entities;


namespace MVCApp.Models.DataSource
{
    public class AppDBContext:DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }

        /*Inicializamos las entidades*/
        public DbSet<Product> Products { get; set; }

        /*Añadimos el método para crear el contexto aunque se inyecta  en Program.cs*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}


        /*Se configura las entidades*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Configuramos las entidades*/
            modelBuilder.Entity<Product>().Property(u => u.Id);


            base.OnModelCreating(modelBuilder);
        }

    }
}
