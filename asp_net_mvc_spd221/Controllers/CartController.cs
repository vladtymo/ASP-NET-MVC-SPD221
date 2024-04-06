using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using asp_net_mvc_spd221.Extensions;
using asp_net_mvc_spd221.Data;
using asp_net_mvc_spd221.Data.Entities;
using AutoMapper;
using asp_net_mvc_spd221.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_net_mvc_spd221.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;

        public CartController(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>(WebConstants.CART_KEY);
            if (ids == null) ids = new List<int>();

            var entities = context.Products
                                    .Include(x => x.Category)
                                    .Where(x => ids.Contains(x.Id))
                                    .ToList();
            var list = mapper.Map<List<ProductCartModel>>(entities);

            return View(list);
        }

        public IActionResult Append(int id)
        {
            // отримуємо дані з корзини
            var ids = HttpContext.Session.Get<List<int>>(WebConstants.CART_KEY);

            // якщо корзина порожня, створюємо список
            if (ids == null) ids = new List<int>();

            // додаємо новий елемент
            ids.Add(id);

            // зберігаємо новий список в корзині
            HttpContext.Session.Set(WebConstants.CART_KEY, ids);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            return View();
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove(WebConstants.CART_KEY);

            return RedirectToAction("Index");
        }
    }
}
