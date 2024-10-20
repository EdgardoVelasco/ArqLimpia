using Microsoft.EntityFrameworkCore;
using RestfulReservas.Business.Entitites;

namespace RestfulReservas.Data
{
    public  class MySQLDBContext:DbContext
    {

        public MySQLDBContext() { }
        public MySQLDBContext(DbContextOptions<MySQLDBContext> options):base(options) {
        }


        /*Se inicializan las entidades*/
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        /*Se inicializa el contexto en Program.cs*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}

        /*Se configuran las entidades para la base de datos*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            /*Configurando los auto increment*/
            modelBuilder.Entity<User>().Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>().Property(y=>y.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Reservation>().Property(u=>u.Id)
                .ValueGeneratedOnAdd();

            /*Constrains*/
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Room>().HasMany(r => r.Reservations)
                                       .WithOne(h => h.Room)
                                       .HasForeignKey(r=>r.RoomId);

            base.OnModelCreating(modelBuilder);

        }

       


    }
}
