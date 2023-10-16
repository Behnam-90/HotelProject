using Hotel_Project.Models.Product;
using Microsoft.CodeAnalysis.Options;

namespace Hotel_Project.ViewModels.Product.HotelImage
{
    public class HotelImageDto
    {
        public int Id { get; set; }

        public IEnumerable<HotelGallery> hotelGalleries  { get; set; }
    }
}
