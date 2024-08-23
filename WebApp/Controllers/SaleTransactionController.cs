using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class SaleTransactionController : Controller
    {

        private Context _context;
        public SaleTransactionController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sales = _context.SaleTransactions.Where(x => x.State == true).Include(x => x.Product).Include(x => x.Staff).Include(x => x.Customer).ToList();
            return View(sales);
        }public IActionResult CancelledSales()
        {
            var sales = _context.SaleTransactions.Where(x => x.State == false).Include(x => x.Product).Include(x => x.Staff).Include(x => x.Customer).ToList();
            return View(sales);
        }
        [HttpGet]
        public IActionResult NewSale()
        {
            List<SelectListItem> valueFP = (from x in _context.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = "Name:" + x.ProductName + " " + "Model :" + x.ProductModel,
                                                Value = x.ProductId.ToString()
                                            }).ToList();
            List<SelectListItem> valueFC = (from x in _context.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CustomerName + " " + x.CustomerSurname,
                                                Value = x.CustomerId.ToString()
                                            }).ToList();
            List<SelectListItem> valueFS = (from x in _context.Staffs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.StaffFullName,
                                                Value = x.StaffId.ToString()
                                            }).ToList();
            ViewBag.valueFP = valueFP;
            ViewBag.valueFC = valueFC;
            ViewBag.valueFS = valueFS;
            return View();
        }
        [HttpPost]
        public IActionResult NewSale(SaleTransaction saleTransaction)
        {
            saleTransaction.Date = DateTime.Parse(DateTime.Now.ToShortTimeString());
            _context.SaleTransactions.Add(saleTransaction);

            var product = _context.Products.Find(saleTransaction.ProductId);
            product.Stock -= saleTransaction.Amount;

            var technicalSupport = new TechnicalSupport
            {
                TechnicalCategoryId = 1,
                TransactionDate = saleTransaction.InstallationDate,
                ProductId = saleTransaction.ProductId,
                CustomerId = saleTransaction.CustomerId, // Müşteri ID'sini uygun şekilde almanız gerekir
                StaffId = saleTransaction.StaffId, // Personel ID'sini uygun şekilde almanız gerekir
                IsComplete = false // Başlangıçta tamamlanmamış olarak ayarlanır
            };

            // TechnicalSupport kaydını veritabanına ekle
            _context.TechnicalSupports.Add(technicalSupport);


            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CancelSale(int id)
        {
            var sale = _context.SaleTransactions
        .Include(s => s.Product)
        .FirstOrDefault(s => s.SaleTransactionId == id);

            var product = _context.Products.Find(sale.ProductId);

            product.Stock += sale.Amount;

            if (sale == null)
            {
                return NotFound();
            }
            sale.State = false;
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Restore(int id)
        {
            var sale = _context.SaleTransactions
        .Include(s => s.Product)
        .FirstOrDefault(s => s.SaleTransactionId == id);

            var product = _context.Products.Find(sale.ProductId);

            product.Stock += sale.Amount;

            if (sale == null)
            {
                return NotFound();
            }
            sale.State = true;
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var values = _context.SaleTransactions.Include(x => x.Product).Include(x => x.Customer).Include(x => x.Staff).Where(x => x.SaleTransactionId == id).ToList();
            return View(values);
        }
    }
}
