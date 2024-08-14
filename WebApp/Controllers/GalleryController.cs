using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class GalleryController : Controller
    {
        private Context _context;
        public GalleryController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Products.ToList();
            return View(values);
        }
    }
}
