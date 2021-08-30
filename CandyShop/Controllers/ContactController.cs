using Microsoft.AspNetCore.Mvc;

namespace CandyShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
