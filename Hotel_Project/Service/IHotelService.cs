using Hotel_Project.Models.Product;

namespace Hotel_Project.Service
{
    public interface IHotelService
    {
        #region BaseHotel
        public IEnumerable<Hotel> GetAllHotels();


        #endregion
    }
}
