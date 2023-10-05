using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Project.Models.Entities.Account
{
    public class UserAddres
    {
        public string HomeAddres  { get; set; }

        public string WorkAdres { get; set; }


        public string MobailNumber { get; set; }


        public int PostalCode { get; set; }




    }

}
