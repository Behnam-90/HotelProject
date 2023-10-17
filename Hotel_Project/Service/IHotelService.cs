using Hotel_Project.Models.Product;
using Hotel_Project.ViewModels.Product.Hotel;

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

        public EditHotelDto GetEditHotelDto(int Id);

        public void RemoveHotel(Hotel hotel);

        public void RemoveAddres(HotelAddrese addres);

        #endregion
        #region Image

        public IEnumerable<HotelGallery> hotelGalleries(int Id);

        public void AddHotelIamge(HotelGallery hotelGallery);

        public HotelGallery HotelGalleryId(int Id);

        public void RemoveHotelGallery(HotelGallery hotelGallery);
        public bool RemoveImage(string ImageName);


        #endregion



        public void SaveChange();
    }
}
