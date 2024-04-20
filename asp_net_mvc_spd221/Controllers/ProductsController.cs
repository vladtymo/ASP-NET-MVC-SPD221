using asp_net_mvc_spd221.Data;
using asp_net_mvc_spd221.Data.Entities;
using asp_net_mvc_spd221.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace asp_net_mvc_spd221.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class ProductsController : Controller
    {
        private ShopDbContext context;
        private readonly IMapper mapper;

        public ProductsController(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            // get products from db
            // .Include() - LEFT JOIN
            var products = context.Products.Include(x => x.Category).ToList();

            LoadCategories();

            return View(products);
        }

        public IActionResult Filter(int? categoryId)
        {
            if (categoryId == null)
                return RedirectToAction("Index");

            var products = context.Products
                            .Include(x => x.Category)
                            .Where(x => x.CategoryId == categoryId)
                            .ToList();

            LoadCategories();
            return View("Index", products);
        }

        [HttpGet] // by default
        public IActionResult Create()
        {
            // ViewBag - transfer data from action to view

            ViewBag.Creation = true;
            LoadCategories();

            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                ViewBag.Creation = true;
                return View("Upsert", model);
            }

            //var entity = new Product()
            //{
            //    Name = model.Name,
            //    CategoryId = model.CategoryId,
            //    Description = model.Description,
            //    Discount = model.Discount,
            //    ImageUrl = model.ImageUrl,
            //    InStock = model.InStock,
            //    Price = model.Price
            //};
            var entity = mapper.Map<Product>(model);

            context.Products.Add(entity);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = context.Products.Find(id);
            if (item == null) return NotFound();

            ViewBag.Creation = false;
            LoadCategories();

            var model = mapper.Map<ProductFormModel>(item);

            return View("Upsert", model);
        }

        [HttpPost]
        public IActionResult Edit(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                ViewBag.Creation = false;
                return View("Upsert", model);
            }

            var entity = mapper.Map<Product>(model);

            context.Products.Update(entity);
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

        private void LoadCategories()
        {
            var categories = new SelectList(context.Categories.ToList(), nameof(Product.Id), nameof(Product.Name));
            ViewBag.Categories = categories;
        }
    }
}
