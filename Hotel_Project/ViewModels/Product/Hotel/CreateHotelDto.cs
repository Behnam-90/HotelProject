using System.ComponentModel.DataAnnotations;

namespace Hotel_Project.ViewModels.Product.Hotel
{
    public class CreateHotelDto
    {
        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Titel { get; set; }
        [Display(Name = "توضیحات  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Description { get; set; }
        [Display(Name = "تعداد اتاق ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int RommeCount { get; set; }
        [Display(Name = "تعداد طبقه ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public int StageCount { get; set; }
        [Display(Name = "ساعت ورود  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string EntriTime { get; set; }
        [Display(Name = "ساعت خروج  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string ExitTime { get; set; }

        #region Addrese

        [Display(Name = "آدرس ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Address { get; set; }
        [Display(Name = "شهر ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string City { get; set; }

        [Display(Name = "استان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string State { get; set; }
        [Display(Name = "کد پستی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string? PostalCode { get; set; }

        #endregion
    }
}
