using Hotel_Project.Data;
using Hotel_Project.Models.Product;

namespace Hotel_Project.Service
{
    public class HotelService : IHotelService
    {
        private MyContext _context;
        public HotelService(MyContext context)
        {
            _context = context; 
        }
        public IEnumerable<Hotel> GetAllHotels()
        {
            return _context.hotels.ToList();
        }
    }
}
