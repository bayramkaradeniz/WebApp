using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class TechnicalSupportController : Controller
    {
        private Context _context;
        public TechnicalSupportController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.TechnicalSupports
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }
        public IActionResult Installation()
        {
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == false && x.TechnicalCategoryId == 1)
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }
        public IActionResult CompletedInstallation()
        {
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == true && x.TechnicalCategoryId == 1)
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }

        public IActionResult GetForCompleteInstallation(int id)
        {
            List<SelectListItem> values = (from x in _context.Staffs
                                           where x.DepartmentId == 2
                                           select new SelectListItem
                                           {
                                               Text = x.StaffFullName,
                                               Value = x.StaffId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            var pro = _context.TechnicalSupports.Find(id);
            return View("GetForCompleteInstallation", pro);
        } 
        public IActionResult CompleteInstallation(TechnicalSupport technicalSupport)
        {
            var pro = _context.TechnicalSupports
                  .Include(ts => ts.Product) // Product nesnesini dahil edin
                  .FirstOrDefault(ts => ts.TechnicalSupportId == technicalSupport.TechnicalSupportId);



           

            // Devamında diğer işlemler...
            pro.Description = technicalSupport.Description;
            pro.IsComplete = true;
            pro.CompletionDate = DateTime.Now;
            pro.TransactionFee = technicalSupport.TransactionFee;
            pro.StaffId = technicalSupport.StaffId;

            var maintenanceDate = DateTime.Now.AddMonths(pro.Product.MaintenanceIntervalInMonths);
            // Bakım işlemi için yeni bir kayıt ekleyin
            var maintenanceSupport = new TechnicalSupport
            {
                TechnicalCategoryId = 2,
                ProductId = pro.ProductId,
                CustomerId = pro.CustomerId, // Müşteri ID'sini uygun şekilde almanız gerekir
                StaffId = technicalSupport.StaffId, // Personel ID'sini uygun şekilde almanız gerekir
                IsComplete = false,//
                TransactionDate = maintenanceDate,
                // Diğer gerekli alanlar...
            };

            _context.TechnicalSupports.Add(maintenanceSupport);
            _context.SaveChanges();

            return RedirectToAction("CompletedInstallation");
        }

        public IActionResult Maintenance()
        {
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == false && x.TechnicalCategoryId == 2)
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }
        public IActionResult CompletedMaintenance()
        {
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == true && x.TechnicalCategoryId == 2)
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }

        public IActionResult GetForCompleteMaintenance(int id)
        {
            List<SelectListItem> values = (from x in _context.Staffs
                                           where x.DepartmentId == 2
                                           select new SelectListItem
                                           {
                                               Text = x.StaffFullName,
                                               Value = x.StaffId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            var pro = _context.TechnicalSupports.Find(id);
            return View("GetForCompleteMaintenance", pro);
        }
        public IActionResult CompleteMaintenance(TechnicalSupport technicalSupport)
        {
            var pro = _context.TechnicalSupports
                 .Include(ts => ts.Product) // Product nesnesini dahil edin
                 .FirstOrDefault(ts => ts.TechnicalSupportId == technicalSupport.TechnicalSupportId);

            // Devamında diğer işlemler...
            pro.Description = technicalSupport.Description;
            pro.IsComplete = true;
            pro.CompletionDate = DateTime.Now;
            pro.TransactionFee = technicalSupport.TransactionFee;
            pro.StaffId = technicalSupport.StaffId;

            var maintenanceDate = DateTime.Now.AddMonths(pro.Product.MaintenanceIntervalInMonths);
            // Bakım işlemi için yeni bir kayıt ekleyin
            var maintenanceSupport = new TechnicalSupport
            {
                TechnicalCategoryId = 2,
                ProductId = pro.ProductId,
                CustomerId = pro.CustomerId, // Müşteri ID'sini uygun şekilde almanız gerekir
                StaffId = technicalSupport.StaffId, // Personel ID'sini uygun şekilde almanız gerekir
                IsComplete = false,//
                TransactionDate = maintenanceDate,
                // Diğer gerekli alanlar...
            };

            _context.TechnicalSupports.Add(maintenanceSupport);
            _context.SaveChanges();

            return RedirectToAction("CompletedMaintenance");
        }
        [HttpGet]
        public IActionResult CreateAFaultRecord(int saleTransactionId)
        {
            if (saleTransactionId == 0)
            {
                // Hatalı ID geldiğinde uygun bir işlem yapın
                return BadRequest("Invalid SaleTransactionId.");
            }

            FaultRecord faultRecord = new FaultRecord();
            
            faultRecord.SaleTransactionId = saleTransactionId;

            return View();
        }


        public IActionResult CreateRepair(FaultRecord faultRecord)
        {
            if (faultRecord == null)
            {
                return BadRequest("FaultRecord is null.");
            }

            var saleTransaction = _context.SaleTransactions.Find(faultRecord.SaleTransactionId);

            if (saleTransaction == null)
            {
                return NotFound($"SaleTransaction with ID {faultRecord.SaleTransactionId} not found.");
            }

            var technicalSupport = new TechnicalSupport
            {
                TechnicalCategoryId = 3,
                TransactionDate = saleTransaction.InstallationDate,
                ProductId = saleTransaction.ProductId,
                CustomerId = saleTransaction.CustomerId,
                StaffId = saleTransaction.StaffId,
                IsComplete = false,
                Description = faultRecord.Issue
            };

            _context.TechnicalSupports.Add(technicalSupport);
            _context.SaveChanges();

            return RedirectToAction("Repair");
        }


        public IActionResult Repair()
        {
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == false && x.TechnicalCategoryId == 3)
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }
        public IActionResult CompletedRepair()
        {
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == true && x.TechnicalCategoryId == 3)
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }

        public IActionResult GetForCompleteRepair(int id)
        {
            List<SelectListItem> values = (from x in _context.Staffs
                                           where x.DepartmentId ==2
                                           select new SelectListItem
                                           {
                                               Text = x.StaffFullName,
                                               Value = x.StaffId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            var pro = _context.TechnicalSupports.Find(id);
            return View("GetForCompleteRepair", pro);
        }
        public IActionResult CompleteRepair(TechnicalSupport technicalSupport)
        {
            var pro = _context.TechnicalSupports
                 .Include(ts => ts.Product) // Product nesnesini dahil edin
                 .FirstOrDefault(ts => ts.TechnicalSupportId == technicalSupport.TechnicalSupportId);

            // Devamında diğer işlemler...
            pro.Description = technicalSupport.Description;
            pro.IsComplete = true;
            pro.CompletionDate = DateTime.Now;
            pro.TransactionFee = technicalSupport.TransactionFee;
            pro.StaffId = technicalSupport.StaffId;

            _context.SaveChanges();

            return RedirectToAction("CompletedRepair");
        }
    }
}
