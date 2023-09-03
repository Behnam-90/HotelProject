using Hotel_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        MyContext _context;
        public DashboardController(MyContext context)
        {
            _context = context;
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult Alluser()
        {
            return View(_context.users.ToListAsync());
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
    }

}
