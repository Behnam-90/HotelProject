using Hotel_Project.Models.Entities.Account;
using Hotel_Project.Models.Entities.Web;
using Hotel_Project.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Project.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvantageToRoom>().HasKey(e => new {e.RoomId , e.AdvantageId});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FisrtBaner> fisrtBaners { get; set; }

        public DbSet<User> users { get; set; }

        #region Product
        public DbSet<AdvantageRoom> advantages { get; set; }
        public DbSet<AdvantageToRoom> advantagesTo { get; set;}

        public DbSet<Hotel> hotels { get; set; }    

        public DbSet<HotelAddrese> hotelAddreses { get; set; }

        public DbSet<HotelGallery> hotelGallerys { get; set;}
        public DbSet<HotelRoom> hotelRooms { get; set;}

        public DbSet<HotelRule> hotelRules { get; set;}

        public DbSet<ReservDate> reservDate { get; set; }   



        #endregion
    }
}
