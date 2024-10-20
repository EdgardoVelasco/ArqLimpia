using RestfulReservas.Business.Entitites;

namespace RestfulReservas.Data.Repositories
{
    public class UserRepository
    {
        private readonly MySQLDBContext _dbContext;

        public UserRepository(MySQLDBContext dbContext) { 
            _dbContext=dbContext; 
            _dbContext.Database.EnsureCreated();// Se asegura que las tablas se hayan creado
        }


        public User GetById(int id) {
            var user = _dbContext.Users.Find(id);
            if (user!=null) {
                return user;
            }
            throw null;
        }


        public List<User> FindAll() {
            return _dbContext.Users.ToList();
        }

        public int Save(User user) {
            _dbContext.Users.Add(user);
            int result=_dbContext.SaveChanges();
            return result;
        }

    }
}
