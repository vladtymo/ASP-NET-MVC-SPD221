using asp_net_mvc_spd221.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_mvc_spd221.Controllers
{
    public class ContactsController : Controller
    {
        public ContactsController()
        {  
        }

        public IActionResult Index()
        {
            // load data from db...
            var items = MockData.GetContacts();

            return View(items);
        }
    }
}
