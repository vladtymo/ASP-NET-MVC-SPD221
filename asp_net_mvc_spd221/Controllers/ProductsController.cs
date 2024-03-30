using asp_net_mvc_spd221.Data;
using asp_net_mvc_spd221.Data.Entities;
using asp_net_mvc_spd221.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace asp_net_mvc_spd221.Controllers
{
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

            LoadCategories();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
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

            LoadCategories();

            var model = mapper.Map<EditProductModel>(item);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditProductModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
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
