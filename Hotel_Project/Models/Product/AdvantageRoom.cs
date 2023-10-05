using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Project.Models.Product
{
    public class AdvantageRoom
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("ویژگی ")]
        [Required(ErrorMessage = "لطفا {0} را کامل کنید")]
        [MaxLength(30, ErrorMessage = "تعداد کاراکتر ها نمیتواند بیشتر از {1} باشد")]
        [MinLength(2, ErrorMessage = "تعداد کاراکتر ها نمیتواند کمتر از {1} باشد")]
        public string Name { get; set; }


        //Navigation

        public ICollection<AdvantageToRoom> advantageToRooms { get; set; }



    }
}
