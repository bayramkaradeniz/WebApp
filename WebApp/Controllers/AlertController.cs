using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class AlertController : Controller
    {
        private Context _context;
        public AlertController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
