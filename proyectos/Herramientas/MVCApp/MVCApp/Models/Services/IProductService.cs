using MVCApp.Models.Entities;

namespace MVCApp.Models.Services
{
    public interface IProductService
    {
        int Insert(Product pr);
        Product FindById(int id);
        List<Product> GetAll();
        int Delete(int id);

    }
}
