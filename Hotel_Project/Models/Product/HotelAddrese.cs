using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Project.Models.Product
{
    public class HotelAddrese
    {
        [Display(Name ="آدرس ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Address { get; set; }
        [Display(Name ="شهر ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string City { get; set; }

        [Display(Name ="استان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string  State { get; set; }
        [Display(Name ="کد پستی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string? PostalCode { get; set; }




        ///Navigation

        [Key]
        public int HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]
        public int MyProperty { get; set; }

    }

}
