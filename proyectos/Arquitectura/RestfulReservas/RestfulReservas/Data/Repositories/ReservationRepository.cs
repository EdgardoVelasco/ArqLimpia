using Microsoft.EntityFrameworkCore;
using RestfulReservas.Business.Entitites;


namespace RestfulReservas.Data.Repositories
{
    public class ReservationRepository
    {
        private readonly MySQLDBContext _dbcontext;

        public ReservationRepository(MySQLDBContext dbcontext) {
            _dbcontext = dbcontext;
            _dbcontext.Database.EnsureCreated();// Se asegura que las tablas se hayan creado
        }


        public Reservation GetById(int id) {
            return _dbcontext.Reservations.Find(id)??new Reservation();
        }

        public int Insert(Reservation reservation) {
            _dbcontext.Reservations.Add(reservation);
            int result=_dbcontext.SaveChanges();
            return result;
        }


        public List<Reservation> GetAll() {
            return _dbcontext.Reservations.Include(r => r.User)//añadiendo relaciones
                                          .Include(r=>r.Room)//añadiendo relaciones
                                          .ToList();
        
        }
    }
}
