using Micro_Producto.Model.Entities;
using Micro_Producto.Model.Repositories;

namespace Micro_Producto.Model.Services
{
    public class DogServiceImpl : IDogService
    {
        private readonly DogRepository _dogRepository;

        public DogServiceImpl(DogRepository dogRepository) { 
            _dogRepository = dogRepository;
        }


        public int Delete(int id)
        {
           return _dogRepository.DeleteById(id);
        }

        public Dog FindById(int id)
        {
            return _dogRepository.FindById(id);
        }

        public List<Dog> GetAll()
        {
            return _dogRepository.GetAll();
        }

        public int Insert(Dog dog)
        {
            return _dogRepository.Insert(dog);
        }
    }
}
