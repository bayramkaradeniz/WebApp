using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class ToDoController : Controller
    {
        private Context _context;
        public ToDoController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var valueOne = _context.Customers.Count().ToString();
            var valueTwo = _context.Products.Count().ToString();
            var valueThree = _context.Categories.Count().ToString();
            var valueFour = _context.Customers.Select(p => p.CustomerCity).Distinct().Count().ToString();

            ViewBag.ValueOne = valueOne;
            ViewBag.valueTwo = valueTwo;
            ViewBag.valueThree = valueThree;
            ViewBag.valueFour = valueFour;

            var values = _context.Todos.ToList();
            return View(values);
        }
    }
}
