using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Project.Models.Product
{
    public class HotelGallery
    {
        public int Id { get; set; }

        public string ImageName { get; set; }




        //// Navigation
        
        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel hotel { get; set; }



    }


}