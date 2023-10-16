using System.ComponentModel.DataAnnotations;

namespace Hotel_Project.ViewModels.Product.HotelImage
{
    public class InsertAndRemoveImage
    {
        public int Id { get; set; }

        public string? ImageName { get; set; }
        [Display(Name = "تصویر ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public IFormFile File { get; set; }

    }
}
