using asp_net_mvc_spd221.Data;
using asp_net_mvc_spd221.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            // .Include() - LEFT JOIN
            var products = context.Products.Include(x => x.Category).ToList();

            return View(products);
        }

        [HttpGet] // by default
        public IActionResult Create()
        {
            // ViewBag - transfer data from action to view

            var categories = new SelectList(context.Categories.ToList(), nameof(Product.Id), nameof(Product.Name));
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            // TODO: add model validation

            context.Products.Add(model);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = context.Products.Find(id);
            if (item == null) return NotFound();

            var categories = new SelectList(context.Categories.ToList(), nameof(Product.Id), nameof(Product.Name));
            ViewBag.Categories = categories;

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            // TODO: add model validation

            context.Products.Update(model);
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
