using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Project.Models.Product
{
    public class HotelRule
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "توضیحات  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]

        public string Description { get; set; }






        //// Navigation

        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel hotel { get; set; }

    }
}
