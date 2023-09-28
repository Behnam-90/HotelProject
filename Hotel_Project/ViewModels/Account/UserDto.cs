using System.ComponentModel.DataAnnotations;

namespace Hotel_Project.ViewModels.Account
{
    public class UserDto
    {
        public int id { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }
  

        [Display(Name = "نام")]
        public string? Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name ="موبایل")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(11)]
        
        public string Mobail { get; set; }

    }
}
