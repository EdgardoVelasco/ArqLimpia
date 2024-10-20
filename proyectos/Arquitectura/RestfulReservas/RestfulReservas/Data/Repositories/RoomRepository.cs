using RestfulReservas.Business.Entitites;

namespace RestfulReservas.Data.Repositories
{
    public class RoomRepository
    {
        private readonly MySQLDBContext _dbContext;

        public RoomRepository(MySQLDBContext dbContext) {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();// Se asegura que las tablas se hayan creado
        }

        public Room GetById(int id) {
            return _dbContext.Rooms.Find(id)??new Room();
        }

        public int Insert(Room room) {
            _dbContext.Rooms.Add(room);
            int result=_dbContext.SaveChanges();
            return result;
        }

        public int Update(Room room) {
            var roomSearch = _dbContext.Rooms.Find(room.Id);
            if (roomSearch != null)
            {
                _dbContext.Rooms.Update(room);
                int result = _dbContext.SaveChanges();
                return result;
            }

            throw new Exception($"Room {room.RoomId} no existe!!!");
        }

        public List<Room> GetAvailable() {
            return _dbContext.Rooms.Where(t => t.Available).ToList();
        }

    }
}
