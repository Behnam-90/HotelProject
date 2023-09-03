using System.ComponentModel.DataAnnotations;

namespace Hotel_Project.ViewModels.Account
{
    public class UserDto
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        public string Email { get; set; }
  

        [Display(Name = "نام")]
        public string? Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        public bool Admin { get; set; } = false;
    }
}
