using System.ComponentModel.DataAnnotations;

namespace Hotel_Project.ViewModels.Product.HotelRule
{
    public class HotelRuleDto
    {
        public int Id { get; set; }

        [Display(Name = "توضیحات  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Description { get; set; }
    }
}
