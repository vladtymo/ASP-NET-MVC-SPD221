using asp_net_mvc_spd221.Data;
using asp_net_mvc_spd221.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_mvc_spd221.Controllers
{
    public class ProductsController : Controller
    {
        private ShopDbContext context;

        public ProductsController()
        {
            context = new ShopDbContext();
            //this.context = context;
        }

        public IActionResult Index()
        {
            // get products from db
            var products = context.Products.ToList();

            return View(products);
        }

        [HttpGet] // by default
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            context.Products.Add(model);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = context.Products.Find(id);

            if (item == null) return NotFound();

            context.Products.Remove(item);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
