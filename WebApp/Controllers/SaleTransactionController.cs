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
        }
        public IActionResult CancelledSales()
        {
            var sales = _context.SaleTransactions.Where(x => x.State == false).Include(x => x.Product).Include(x => x.Staff).Include(x => x.Customer).ToList();
            return View(sales);
        }
        [HttpGet]
        public IActionResult NewSale()
        {
            List<SelectListItem> valueFP = _context.Products
                .Select(x => new SelectListItem
                {
                    Text = $"Name: {x.ProductName} Model: {x.ProductModel}",
                    Value = x.ProductId.ToString()
                }).ToList();

            List<SelectListItem> valueFC = _context.Customers
                .Select(x => new SelectListItem
                {
                    Text = $"{x.CustomerName} {x.CustomerSurname}",
                    Value = x.CustomerId.ToString()
                }).ToList();

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

            ViewBag.valueFP = valueFP;
            ViewBag.valueFC = valueFC;
            ViewBag.valueFS = valueFS;
            ViewBag.valuePM = valuePM;
            ViewBag.valuePD = valuePD;

            return View();
        }


        [HttpPost]
        public IActionResult NewSale(SaleTransaction saleTransaction)
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

            // Satış ID'sini al
            var saleId = saleTransaction.SaleTransactionId;

            // Kullanıcıyı ödeme sayfasına yönlendir
            return RedirectToAction("Index");
        }

        public IActionResult CancelSale(int id)
        {
            var sale = _context.SaleTransactions
        .Include(s => s.Product)
        .FirstOrDefault(s => s.SaleTransactionId == id);

            var product = _context.Products.Find(sale.ProductId);

            product.Stock += sale.StockAmount;

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

            product.Stock += sale.StockAmount;

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
        public IActionResult PaymentDetails(int id)
        {
            var values = _context.SaleTransactions.Include(x => x.Payment).ThenInclude(x => x.PaymentCategory).Where(x => x.SaleTransactionId == id).ToList();
            return View(values);
        }
        public IActionResult InstallmentDetails(int id)
        {
            var values = _context.Installments.Where(x => x.PaymentId == id).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CompleteInstallmentPayment(int id)
        {

            var valuePD = Enum.GetValues(typeof(InstallmentPaymentType))
       .Cast<PaymentTypeForDownPayment>()
       .Select(e => new SelectListItem
       {
           Text = e.ToString(), // Enum değerinin ismini kullanıyoruz
           Value = ((int)e).ToString() // Enum değerinin int karşılığını kullanıyoruz
       })
       .ToList();
            ViewBag.valuePD = valuePD;
            var ins = _context.Installments.Find(id);
            return View("CompleteInstallmentPayment", ins);
        }
        [HttpPost]
        public IActionResult CompleteInstallmentPayment(Installment installment)
        {
            var ins = _context.Installments.Find(installment.InstallmentId);
            var pay = _context.Payments.Find(ins.PaymentId);

            ins.InstallmentIsPaid= true;
            ins.InstallmentPaymentType = installment.InstallmentPaymentType;
            pay.PaidPrice += ins.InstallmentAmount;
            ins.PaymentDate=DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("PaymentDetails", new { id = ins.PaymentId });

        }

    }
}
