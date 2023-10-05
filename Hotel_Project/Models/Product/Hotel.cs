using System.ComponentModel.DataAnnotations;

namespace Hotel_Project.Models.Product
{
    public class Hotel
    {
         [Key]
        public int Id { get; set; }
        [Display(Name ="عنوان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Titel { get; set; }
        [Display(Name ="توضیحات  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Description { get; set; }
        [Display(Name ="تعداد اتاق ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int RommeCount { get; set; }
        [Display(Name ="تعداد طبقه ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int StageCount { get; set; }
        [Display(Name ="ساعت ورود  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string EntriTime { get; set; }
        [Display(Name ="ساعت خروج  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string ExitTime { get; set; }

        public DateTime TimeCreate { get; set; }
        [Display(Name ="وضعیت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public bool  IsActive { get; set; }





        //Navigation

        public HotelAddrese HotelAddrese { get; set; }
        public ICollection<HotelGallery> HotelGalleries { get; set; }
        public ICollection<HotelRoom> HotelRooms { get; }
        public  ICollection<HotelRule> HotelRules { get; set; }


    }
}
