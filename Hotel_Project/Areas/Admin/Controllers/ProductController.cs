using Hotel_Project.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
     

        private IHotelService _service;
        public ProductController(IHotelService service)
        {
                _service = service;
        }
   
        public IActionResult GetAllHotel()
        {
            return View(_service.GetAllHotels());
        }

        public IActionResult CreateHotel() 
        
        {
            return View();
        }
    }
}
