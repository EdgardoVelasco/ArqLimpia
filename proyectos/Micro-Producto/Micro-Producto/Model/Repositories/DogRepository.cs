using Micro_Producto.Model.DataSource;
using Micro_Producto.Model.Entities;

namespace Micro_Producto.Model.Repositories
{
    public class DogRepository
    {
        private readonly AppDBContext _dbContext;
        public DogRepository(AppDBContext dBContext) {
            _dbContext = dBContext;
            _dbContext.Database.EnsureCreated();   
        }

        public int Insert(Dog dog) {
            _dbContext.Dogs.Add(dog);
            return _dbContext.SaveChanges();
        }

        public List<Dog> GetAll() { 
           return _dbContext.Dogs.ToList();
        }

        public Dog FindById(int id) {
            var search=_dbContext.Dogs.Find(id);
            return search??throw new Exception($"Dog with id {id} doesn't exists");
        }

        public int DeleteById(int id) { 
            var dog= _dbContext.Dogs.Find(id);
            if (dog!=null) { 
                var dogR= _dbContext.Dogs.Remove(dog);
                _dbContext.SaveChanges();
                return dogR != null ? 1 : 0;
            }
            throw new Exception($"no existe el perro");
        }
    }
}
