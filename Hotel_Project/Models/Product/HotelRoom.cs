using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Project.Models.Product
{
    public class HotelRoom
    {
         [Key]
        public int ID { get; set; }
         [Display(Name ="نام عکس  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string ImageName { get; set; }
         [Display(Name ="عنوان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string  Titel { get; set; }
        [Display(Name ="توضیحات  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Description { get; set; }
        [Display(Name ="قیمت اتاق ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int RomePrice { get; set; }
        [Display(Name ="تعداد  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int Count   { get; set; }
        [Display(Name ="ظرفیت ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int CapaCity { get; set; }
                [Display(Name ="تعداد تخت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int BedCount { get; set; }
                 [Display(Name ="وضعیت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public bool IsActive { get; set; }


        //// Navigation

        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel hotel { get; set; }

        public ICollection<ReservDate> reservDates { get; set; }
        public ICollection <AdvantageToRoom> advantageToRooms { get; set; }


    }

}
