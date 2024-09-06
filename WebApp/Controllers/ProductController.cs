using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
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
        [HttpGet]
        public IActionResult SellProduct(int id)
        {
            

            List<SelectListItem> valueFS = _context.Staffs
    .Where(x => x.Department.DepartmentName == "Satış") // Filter by department name
    .Select(x => new SelectListItem
    {
        Text = x.StaffFullName,
        Value = x.StaffId.ToString()
    }).ToList();
            List<SelectListItem> valuePM = _context.PaymentCategories
                .Select(x => new SelectListItem
                {
                    Text = x.PaymentCategoryName,
                    Value = x.PaymentCategoryId.ToString()
                }).ToList();

            var valuePD = Enum.GetValues(typeof(PaymentTypeForDownPayment))
        .Cast<PaymentTypeForDownPayment>()
        .Select(e => new SelectListItem
        {
            Text = e.ToString(), // Enum değerinin ismini kullanıyoruz
            Value = ((int)e).ToString() // Enum değerinin int karşılığını kullanıyoruz
        })
        .ToList();

            
            ViewBag.valueFS = valueFS;
            ViewBag.valuePM = valuePM;
            ViewBag.valuePD = valuePD;

            var prod= _context.Products.Find(id);

            ViewBag.pro = prod.ProductId;
            ViewBag.pri = prod.SalePrice;
            return View();
        }
        [HttpPost]
        public IActionResult SellProduct(SaleTransaction saleTransaction )
        {
            if (saleTransaction == null)
            {
                return BadRequest("Satış verileri eksik.");
            }

            saleTransaction.Date = DateTime.Now;

            if (saleTransaction.Payment.PaymentCategoryId == 1 || saleTransaction.Payment.PaymentCategoryId == 2)
            {
                // Nakit veya kredi kartı ödemesi
                saleTransaction.Payment.IsPaid = true;
                saleTransaction.Payment.PaidPrice = saleTransaction.TotalPrice;
                saleTransaction.Payment.Installments = null;
                saleTransaction.Payment.TotalPrice = saleTransaction.TotalPrice;
                saleTransaction.Payment.PaymentDate = DateTime.Now;
            }
            else
            {
                // Taksitli ödeme hesaplamaları
                decimal downPayment = saleTransaction.Payment.DownPayment ?? 0;
                saleTransaction.Payment.PaidPrice = downPayment;
                saleTransaction.Payment.TotalPrice = saleTransaction.TotalPrice;
                decimal amountPerInstallment = (saleTransaction.TotalPrice - downPayment) / saleTransaction.Payment.InstallmentCount.Value;

                saleTransaction.Payment.Installments = new List<Installment>();
                DateTime installmentDate = saleTransaction.Payment.FirstInstallmentDate.Value;

                for (int i = 0; i < saleTransaction.Payment.InstallmentCount.Value; i++)
                {
                    saleTransaction.Payment.Installments.Add(new Installment
                    {
                        InstallmentAmount = amountPerInstallment,
                        InstallmentDate = installmentDate,
                        InstallmentIsPaid = false
                    });

                    installmentDate = installmentDate.AddMonths(saleTransaction.Payment.InstallmentPeriodMonths.Value);
                }
            }
            // Satış işlemini veritabanına ekle
            _context.SaleTransactions.Add(saleTransaction);

            // Ürünü güncelle
            var product = _context.Products.Find(saleTransaction.ProductId);
            if (product != null)
            {
                product.Stock -= saleTransaction.StockAmount;
            }

            // Teknik destek kaydını oluştur
            var technicalSupport = new TechnicalSupport
            {
                TechnicalCategoryId = 1,
                TransactionDate = saleTransaction.InstallationDate,
                ProductId = saleTransaction.ProductId,
                CustomerId = saleTransaction.CustomerId,
                StaffId = saleTransaction.StaffId,
                IsComplete = false
            };

            // Teknik destek kaydını veritabanına ekle
            _context.TechnicalSupports.Add(technicalSupport);

            // Veritabanına değişiklikleri kaydet
            _context.SaveChanges();


            // Kullanıcıyı ödeme sayfasına yönlendir
            return RedirectToAction("Index","SaleTransaction");

        }

    }
}
