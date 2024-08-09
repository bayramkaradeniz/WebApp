using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BillController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
