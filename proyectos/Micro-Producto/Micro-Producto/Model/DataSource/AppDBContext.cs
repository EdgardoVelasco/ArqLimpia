using Micro_Producto.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Micro_Producto.Model.DataSource
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }


        /*Se inicializan las entidades*/
        public DbSet<Dog> Dogs { get; set; }


        /*Se inicializa el context en Program.cs*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}

        /*Se configuran las entidades*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*Configurando los auto_increment*/
            modelBuilder.Entity<Dog>().Property(u=>u.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }


    }
}
