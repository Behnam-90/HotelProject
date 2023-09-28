using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Project.Models.Product
{
    public class HotelRoom
    {
        public int ID { get; set; }

        public string  Titel { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Count   { get; set; }








        //// Navigation

        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel hotel { get; set; }



    }

}
