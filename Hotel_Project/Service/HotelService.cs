using Hotel_Project.Data;
using Hotel_Project.Models.Product;
using Hotel_Project.ViewModels.Product.Hotel;
using Hotel_Project.ViewModels.Product.HotelImage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace Hotel_Project.Service
{
    public class HotelService : IHotelService
    {
        private MyContext _context;


        public HotelService(MyContext context)
        {
            _context = context;
        }
        #region BaseHotel
        public void EditAddres(HotelAddrese hotelAddrese)
        {
            _context.hotelAddreses.Update(hotelAddrese);
        }

        public void EditHotel(Hotel hotel)
        {
            _context.hotels.Update(hotel);
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _context.hotels.ToList();
        }

        public EditHotelDto GetEditHotelDto(int Id)
        {
            return _context.hotels.Include(a => a.HotelAddrese).Where(h => h.Id == Id).Select(eh => new EditHotelDto
            {
                Id = eh.Id,
                Titel = eh.Titel,
                Description = eh.Description,
                EntriTime = eh.EntriTime,
                ExitTime = eh.ExitTime,
                IsActive = eh.IsActive,
                RommeCount = eh.RommeCount,
                StageCount = eh.StageCount,
                Address = eh.HotelAddrese.Address,
                City = eh.HotelAddrese.City,
                State = eh.HotelAddrese.State,
                PostalCode = eh.HotelAddrese.PostalCode,


            }).SingleOrDefault();
        }
        public Hotel GetHotelById(int id)
        {
            return _context.hotels.Include(a => a.HotelAddrese).SingleOrDefault(h => h.Id == id) ?? throw new Exception();
        }

   
        public void InsertAddres(HotelAddrese hotelAddrese)
        {
            _context.hotelAddreses.Add(hotelAddrese);
        }

        public void InsertHotel(Hotel hotel)
        {
            _context.hotels.Add(hotel);
        }

        public void RemoveAddres(HotelAddrese addres)
        {
            _context.hotelAddreses.Remove(addres);

         }

  

        public void RemoveHotel(Hotel hotel)
        {
            _context?.hotels.Remove(hotel);
        }
        #endregion

        #region HotelImage
        public IEnumerable<HotelGallery> hotelGalleries(int Id)
        {
           return _context.hotelGallerys.Where(a=>a.HotelId == Id).ToList();
        }
        public void AddHotelIamge(HotelGallery hotelGallery)
        {
            _context.hotelGallerys.Add(hotelGallery);
        }

        public HotelGallery HotelGalleryId(int Id)
        {
            return _context.hotelGallerys.Find(Id)?? throw new Exception();
        }

        public void RemoveHotelGallery(HotelGallery Gallery)
        {
            _context.hotelGallerys.Remove(Gallery);
        }
        public bool RemoveImage(string ImageName)
        {
            try
            {
                string ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/asset/img/HotelImages", ImageName);
                File.Delete(ImagePath);
                return true;
            }
            catch 
            {

               return false;
            }
        }
        #endregion


        #region Rule
        public IEnumerable<HotelRule> GetAllRules(int Id)
        {
           return _context.hotelRules.Where(e=> e.HotelId==Id).ToList();
        }

        public void InsertRule(HotelRule hotelrule)
        {
           _context.hotelRules.Add(hotelrule);
        }

        #endregion

        public void SaveChange()
        {
            _context.SaveChanges();
        }

  
    }
}
