using Hotel_Project.Data;
using Hotel_Project.Models.Product;
using Hotel_Project.ViewModels.Product.Hotel;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Project.Service
{
    public class HotelService : IHotelService
    {
        private MyContext _context;
        public HotelService(MyContext context)
        {
            _context = context; 
        }

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
                Id=eh.Id,
                Titel=eh.Titel,
                Description=eh.Description,
                EntriTime=eh.EntriTime,
                ExitTime=eh.ExitTime,
                IsActive=eh.IsActive,
                RommeCount=eh.RommeCount,
                StageCount=eh.StageCount,
                Address=eh.HotelAddrese.Address,
                City=eh.HotelAddrese.City,
                State=eh.HotelAddrese.State,
                PostalCode=eh.HotelAddrese.PostalCode,


            }).SingleOrDefault();
        }
        public Hotel GetHotelById(int id)
        {
            return _context.hotels.Include(a=> a.HotelAddrese).SingleOrDefault(h=> h.Id == id) ?? throw new Exception();
        }

         
        public void InsertAddres(HotelAddrese hotelAddrese)
        {
            _context.hotelAddreses.Add(hotelAddrese);
        }

        public void InsertHotel(Hotel hotel)
        {
            _context.hotels.Add(hotel);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
