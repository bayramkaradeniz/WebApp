using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class ProductDetailController : Controller
    {
        private Context _context;
        public ProductDetailController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var values = _context.Products.Include(x=>x.Category).Where(x=>x.ProductId == 1).ToList();
            ProductDetailModel productDetailModel = new ProductDetailModel();   

            productDetailModel.ValueOne = _context.Products.Where(x=>x.ProductId == 1).ToList();
            productDetailModel.ValueTwo = _context.Details.Where(x=>x.DetailId == 1).ToList();

            return View(productDetailModel);
        }
    }
}
