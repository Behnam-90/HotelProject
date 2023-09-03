namespace Hotel_Project.Models.Product
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Description { get; set; }

        public int RommeCount { get; set; }

        public int StageCount { get; set; }

        public string EntriTime { get; set; }

        public string ExitTime { get; set; }

        public DateTime TimeCreate { get; set; }

        public bool  IsActive { get; set; }


        //Navigation
        public ICollection<HotelGallery> HotelGalleries { get; set; }
        public ICollection<HotelRoom> HotelRooms { get; }
        public  ICollection<HotelRule> HotelRules { get; set; }


    }
}
