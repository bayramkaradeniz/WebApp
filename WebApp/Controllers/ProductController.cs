using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(x=>x.Category).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult NewProduct() 
        {
            List<SelectListItem> values = (from x in _context.Categories.ToList() 
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
        return View();
        }
        [HttpPost]
        public IActionResult NewProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            product.State = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetProduct(int id)
        {

            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            var pro = _context.Products.Find(id);
            return View("GetProduct", pro);
        }
        public IActionResult UpdateProduct(Product product)
        {
            var pro = _context.Products.Find(product.ProductId);

            pro.ProductName = product.ProductName;
            pro.Stock = product.Stock;
            pro.State = product.State;
            pro.SalePrice = product.SalePrice;
            pro.PurchasePrice = product.PurchasePrice;
            pro.ProductModel = product.ProductModel;
            pro.Brand = product.Brand;
            pro.MaintenanceIntervalInMonths=product.MaintenanceIntervalInMonths;
            pro.CategoryId = product.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
