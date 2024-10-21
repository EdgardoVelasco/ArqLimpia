using Micro_Producto.Model.Entities;

namespace Micro_Producto.Model.Services
{
    public interface IDogService
    {
        List<Dog> GetAll();
        int Insert(Dog dog);
        int Delete(int id);
        Dog FindById(int id);

    }
}
