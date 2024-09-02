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
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == false)
     .Include(x => x.TechnicalCategory)
     .Include(x => x.Product)
     .Include(x => x.Customer)
     .Include(x => x.Staff)
     .ToList();
            return View(values);
        }
        public IActionResult CompletedTech()
        {
            var values = _context.TechnicalSupports.Where(x => x.IsComplete == true)
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
                                           where x.Department.DepartmentName == "Teknik Destek"
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
                                           where x.Department.DepartmentName == "Teknik Destek"
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
     //  

        public IActionResult CancelTech(int id)
        {
            var tech = _context.TechnicalSupports
        .FirstOrDefault(s => s.TechnicalSupportId == id);

            tech.IsComplete = false;
            tech.Description = "";
            tech.TransactionFee = 0;
            tech.CompletionDate = null;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
