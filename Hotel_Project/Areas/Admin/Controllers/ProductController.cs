using Hotel_Project.Models.Product;
using Hotel_Project.Service;
using Hotel_Project.ViewModels.Product.Hotel;
using Hotel_Project.ViewModels.Product.HotelImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace Hotel_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        #region Hotelbase

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
                    addres.State = editHotelDto.State;
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


        public IActionResult RemoveHotel(int Id)
        {
            if (Id == null)
            {
                return RedirectToAction("GetAllHotel");
            }

            return View(_service.GetEditHotelDto(Id));
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult RemoveHotel(int? Id)
        {
            if (Id != null)
            {
                var hotel = _service.GetHotelById(Id.Value);
                if (hotel != null)
                {
                    _service.RemoveHotel(hotel);
                    _service.RemoveAddres(hotel.HotelAddrese);
                    _service.SaveChange();
                    return RedirectToAction("GetAllHotel");
                }
                return RedirectToAction("GetAllHotel");
            }
            return RedirectToAction("GetAllHotel");
        }
        #endregion

        #region Image
        public IActionResult ShowAllHotelImage(int Id)
        {
            return View(new HotelImageDto() { Id = Id, hotelGalleries = _service.hotelGalleries(Id) });
        }


        public IActionResult InsertHotelImage(int Id)

        {
            return View(new InsertAndRemoveImage { Id = Id });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult InsertHotelImage(InsertAndRemoveImage gallery)

        {
            if (ModelState.IsValid)
            {
                if (gallery.File != null)
                {
                    string ImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(gallery.File.FileName);
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelImages", ImageName);

                    using (var strem = new FileStream(ImagePath, FileMode.Create))
                    {
                        gallery.File.CopyTo(strem);
                    }
                    var image = new HotelGallery()
                    {
                        ImageName = ImageName,
                        HotelId = gallery.Id,

                    };
                    _service.AddHotelIamge(image);
                    _service.SaveChange();
                    return RedirectToAction("ShowAllHotelImage", new { id = gallery.Id });
                }
                return View();
            }
            return View();

        }
        public IActionResult RemoveHotelImage(int Id)
        {
            return View(new InsertAndRemoveImage()
            { Id = Id, ImageName = _service.HotelGalleryId(Id).ImageName });
        }

        public IActionResult RemoveFormHotelImage(int? Id)
        {
            if (Id != null)
            {
                var image = _service.HotelGalleryId(Id.Value);
                if (image != null)
                {
                    if (_service.RemoveImage(image.ImageName))
                    {
                        _service.RemoveHotelGallery(image);
                        _service.SaveChange();
                        return RedirectToAction("ShowAllHotelImage", new { Id = image.HotelId });
                    }
                    else
                    {
                        return View(new HotelImageDto() { Id = Id.Value, hotelGalleries = _service.hotelGalleries(Id.Value) });
                    }

                }
                else
                {
                    return View("GetAllHotel");
                }

            }
            return View("GetAllHotel");

        }
        #endregion
    }

}