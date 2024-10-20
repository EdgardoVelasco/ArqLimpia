using MVCApp.Models.Entities;
using MVCApp.Models.Repository;

namespace MVCApp.Models.Services
{
    public class ProductServiceImpl : IProductService
    {
        private readonly ProductRepository _repository;

        public ProductServiceImpl(ProductRepository repository) { 
            _repository = repository;
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Product FindById(int id)
        {
            return _repository.FindById(id);
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Product pr)
        {
            return _repository.Insert(pr);
        }
    }
}
