using Microsoft.AspNetCore.Mvc;
using MVCApp.Models.DataSource.DTO_s;
using MVCApp.Models.Services;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductService _service;

        public HomeController(IProductService service) {
            _service = service; 
        }


        
        public IActionResult Index()
        {
            ViewData["Products"] = _service.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Save([Bind("Name", "Description", "price")] ProductDTO product) {
            int result=_service.Insert(new Models.Entities.Product()
            {
                Name = product.Name,
                Description = product.Description,
                price = product.price
            });

            return RedirectToAction("Index");
        }


        public IActionResult Delete([FromQuery] int id)
        {
           int result=_service.Delete(id);
           return RedirectToAction("Index");
        }

    }

    
    
}
