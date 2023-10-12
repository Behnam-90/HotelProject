using Hotel_Project.Models.Product;
using Hotel_Project.Service;
using Hotel_Project.ViewModels.Product.Hotel;
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


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateHotel(CreateHotelDto hotelDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var hotel = new Hotel()
                    {
                        Titel = hotelDto.Titel,
                        TimeCreate = DateTime.Now,
                        EntriTime = hotelDto.EntriTime,
                        ExitTime = hotelDto.ExitTime,
                        Description = hotelDto.Description,
                        IsActive = true,
                        RommeCount = hotelDto.RommeCount,
                        StageCount = hotelDto.StageCount,

                    };

                    _service.InsertHotel(hotel);
                    _service.SaveChange();

                    var addres = new HotelAddrese()
                    {
                        Address = hotelDto.Address,
                        City = hotelDto.City,
                        PostalCode = hotelDto.PostalCode,
                        State = hotelDto.State,
                        HotelId = hotel.Id,
                    };
                    _service.InsertAddres(addres);
                    _service.SaveChange();

                    return RedirectToAction("GetAllHotel");
                }
                catch (Exception)
                {

                    ModelState.AddModelError(nameof(hotelDto.Titel), "عملیات با خطا مواجه شد");
                    return View(hotelDto);
                }
            }
            ModelState.AddModelError(nameof(hotelDto.Titel), "لطفا تمام فیلد ها را کامل کنید");
            return View(hotelDto);
        }

        public IActionResult EditHotel(int Id)

        {
            if (Id == null)
            {
                return RedirectToAction("GetAllHotel");
            }

            return View(_service.GetEditHotelDto(Id));
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditHotel(int Id, EditHotelDto editHotelDto)

        {
            if (ModelState.IsValid)
            {
                if (Id == editHotelDto.Id)
                {
                    var hotel = _service.GetHotelById(Id);
                    hotel.Titel = editHotelDto.Titel;
                    hotel.Description = editHotelDto.Description;
                    hotel.ExitTime = editHotelDto.ExitTime;
                    hotel.EntriTime = editHotelDto.EntriTime;
                    hotel.IsActive = editHotelDto.IsActive;
                    hotel.RommeCount = editHotelDto.RommeCount;
                    hotel.StageCount = editHotelDto.StageCount;

                    var addres = hotel.HotelAddrese;
                        addres.Address = editHotelDto.Address;
                        addres.City = editHotelDto.City;
                        addres.State= editHotelDto.State;
                        addres.PostalCode = editHotelDto.PostalCode;

                    _service.EditHotel(hotel);
                    _service.EditAddres(addres);
                    _service.SaveChange();
                    return RedirectToAction("GetAllHotel");

                }
                return View(editHotelDto);

            }

            return View(editHotelDto);
        }
    }

}