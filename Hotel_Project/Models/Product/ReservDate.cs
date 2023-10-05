using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Project.Models.Product
{
    public class ReservDate
    {
         [Key]
        public int Id { get; set; }
        [Display(Name ="تاریخ رزرو ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public DateTime ReservTime {  get; set; }
                [Display(Name =" اتاق تعداد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Count { get; set; }
                [Display(Name ="قیمت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int Price { get; set; }
                [Display(Name ="وضعیت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public bool IsReserve { get; set; }

        public int RoomId { get; set; }

        //Navigation


        [ForeignKey(nameof(RoomId))]
        public HotelRoom hotelRoom { get; set; }
    }
}
