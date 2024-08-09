using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
