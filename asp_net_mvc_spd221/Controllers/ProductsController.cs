using asp_net_mvc_spd221.Data;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_mvc_spd221.Controllers
{
    public class ProductsController : Controller
    {
        private ShopDbContext context;

        public ProductsController()
        {
            context = new ShopDbContext();
        }

        public IActionResult Index()
        {
            // get products from db
            var products = context.Products.ToList();

            return View(products);
        }

        // create/edit/delete/find
    }
}
