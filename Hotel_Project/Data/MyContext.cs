using Hotel_Project.Models.Entities.Account;
using Hotel_Project.Models.Entities.Web;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Project.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
                
        }

        public DbSet<FisrtBaner> fisrtBaners { get; set; }

        public DbSet<User> users { get; set; }
    }
}
