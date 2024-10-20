using MVCApp.Models.DataSource;
using MVCApp.Models.Entities;

namespace MVCApp.Models.Repository
{
    public class ProductRepository
    {
        private readonly AppDBContext _dbContext;

        public ProductRepository(AppDBContext dBContext) {
            _dbContext = dBContext;
            _dbContext.Database.EnsureCreated();
        }


        public int Insert(Product pr) {
            _dbContext.Add(pr);
            int result = _dbContext.SaveChanges();
            return result;
        }


        public int Delete(int id) {
            var product = _dbContext.Products.Find(id);
            if (product != null) {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<Product> GetAll(){
            return _dbContext.Products.ToList();
        }

        public Product FindById(int id) { 
            var product=_dbContext.Products.Find(id);
            if (product != null) { 
                return product;
            }
            throw new Exception($"No existe product {id}");
        }


    }
}
