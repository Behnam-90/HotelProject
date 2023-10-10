using Hotel_Project.Models.Product;

namespace Hotel_Project.Service
{
    public interface IHotelService
    {
        #region BaseHotel
        public IEnumerable<Hotel> GetAllHotels();

        public void InsertHotel(Hotel hotel);

        public void InsertAddres(HotelAddrese hotelAddrese);

        public void EditHotel(Hotel hotel);
        public void EditAddres(HotelAddrese hotelAddrese);
        public Hotel GetHotelById(int id);

        #endregion



        public void SaveChange();
    }
}
