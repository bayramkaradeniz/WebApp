using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class StatisticController : Controller
    {
        private Context _context;
        public StatisticController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var value1 = _context.Customers.Count().ToString();
            ViewBag.d1 = value1;

            var value2 = _context.Products.Count().ToString();
            ViewBag.d2 = value2;

            var value3 = _context.Staffs.Count().ToString();
            ViewBag.d3 = value3;

            var value4 = _context.Categories.Count().ToString();
            ViewBag.d4 = value4;

            var value5 = _context.Products.Sum(s => s.Stock).ToString();
            ViewBag.d5 = value5;

            var value6 = _context.Products.Select(p => p.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;


            var value7 = _context.Products.Count(x => x.Stock <= 10).ToString();
            ViewBag.d7 = value7;

            var value8 = _context.Products
    .OrderByDescending(p => p.PurchasePrice)
    .FirstOrDefault();

            ViewBag.d8 = value8 != null ? $"{value8.ProductName} {value8.Brand}" : string.Empty;

            var value9 = _context.Products
                .OrderBy(p => p.SalePrice)
                .FirstOrDefault();

            ViewBag.d9 = value9 != null ? $"{value9.ProductName} {value9.Brand}" : string.Empty;

            var value10 = _context.Products.Where(p => p.Category.CategoryName == "Filtreli").Count().ToString();
            ViewBag.d10 = value10;

            var value11 = _context.Products.Where(p => p.Category.CategoryName == "Filtresiz").Count().ToString();
            ViewBag.d11 = value11;

            var value12 = _context.Products.OrderByDescending(p => p.PurchasePrice).FirstOrDefault()?.Brand;
            ViewBag.d12 = value12;

            var value13 = _context.SaleTransactions.Include(x=>x.Product)
    .OrderByDescending(s => s.StockAmount) 
    .FirstOrDefault().Product.ProductName;
            ViewBag.d13 = value13;

            var value14 = _context.SaleTransactions.Sum(c => c.TotalPrice).ToString();
            ViewBag.d14 = value14;

            var todayStart = DateTime.Today;
            var todayEnd = todayStart.AddDays(1).AddTicks(-1);

            var value15 = _context.SaleTransactions.Count(s => s.Date >= todayStart && s.Date <= todayEnd).ToString();
            ViewBag.d15 = value15;

            var value16 = _context.SaleTransactions.Where(s => s.Date >= todayStart && s.Date <= todayEnd).Sum(c => c.TotalPrice).ToString();
            ViewBag.d16 = value16;

            return View();
        }
        public IActionResult SimpleTables()
        {
            var x = _context.Customers
    .GroupBy(c => c.CustomerCity)
    .Select(g => new GroupClass
    {
        Adress = g.Key,
        Count = g.Count()
    })
    .ToList();
            return View(x);
        }
        public PartialViewResult PartialDep()
        {
            var y = _context.Staffs
                .GroupBy(c => c.Department.DepartmentName)
                .Select(g => new GroupClass2
                {
                    Departman = g.Key,
                    Count = g.Count()
                })
                .ToList(); // y: List<GroupClass2>

            return PartialView("PartialDep", y);
        }
        public PartialViewResult PartialPep()
        {
            var y = _context.Customers.ToList(); 

            return PartialView("PartialPep", y);
        }
        public PartialViewResult PartialTep()
        {
            var products = _context.Products.Include(x => x.Category).ToList();

            return PartialView("PartialTep", products);
        }
        public PartialViewResult PartialMep()
        {
            var y = _context.Products
                .GroupBy(c => c.Brand)
                .Select(g => new GroupClass3
                {
                    Brand = g.Key,
                    Count = g.Count()
                })
                .ToList(); // y: List<GroupClass2>
            return PartialView("PartialMep", y);
        }


    }
}
