using asp_net_mvc_spd221.Data;
using asp_net_mvc_spd221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace asp_net_mvc_spd221.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopDbContext context;

        public HomeController(ShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var items = context.Products.Include(x => x.Category).ToList();
            return View(items); // ~/Views/Home/Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
