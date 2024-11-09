using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using WebApp.DTO;
using WebApp.Extensions;
using WebApp.Models.Classes;
using WebApp.Models.ViewModels;
using Fault = WebApp.Models.Classes.Fault;

namespace WebApp.Controllers
{
    public class FaultController : Controller
    {
        private Context _context;
        public FaultController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Faults.Where(x => x.IsComplete == false).Include(x => x.Product).Include(x => x.Customer).Include(x => x.Staff).ToList();
            return View(values);
        }
        public IActionResult CompletedFault()
        {
            var values = _context.Faults.Where(x => x.IsComplete == true).Include(x => x.Product).Include(x => x.Customer).Include(x => x.Staff).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewFault()
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

            ViewBag.valueFP = valueFP;
            ViewBag.valueFC = valueFC;
            ViewBag.valueFS = valueFS;

            return View();
        }
        [HttpPost]
        public IActionResult NewFault(Fault fault)
        {
            fault.Timestamp = DateTime.Now;
            fault.Status = FaultStatuEnum.Ariza;

            _context.Faults.Add(fault);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetFault(int id)
        {
            List<SelectListItem> valueFS = _context.Staffs
    .Select(x => new SelectListItem
    {
        Text = x.StaffFullName,
        Value = x.StaffId.ToString()
    }).ToList();

            var valuePD = Enum.GetValues(typeof(FaultStatuEnum))
               .Cast<FaultStatuEnum>()
               .Select(e => new SelectListItem
               {
                   Text = e.ToString(), // Enum değerinin ismini kullanıyoruz
                   Value = ((int)e).ToString() // Enum değerinin int karşılığını kullanıyoruz
               }).ToList();


            ViewBag.valueFS = valueFS;
            ViewBag.valuePD = valuePD;

            var pro = _context.Faults.Include(x => x.Customer).Include(x => x.Product).FirstOrDefault(x => x.FaultId == id);
            return View("GetFault", pro);
        }
        public IActionResult UpdateFault(Fault fault)
        {
            var flt = _context.Faults.Find(fault.FaultId);

            flt!.IsComplete = true;

            var newFault = new Fault()
            {
                CustomerId = flt.CustomerId,
                ProductId = flt.ProductId,
                Description = fault.Description,
                StaffId = fault.StaffId,
                Status = fault.Status,
                Timestamp = DateTime.Now,
                IsComplete = false
            };

            _context.Faults.Add(newFault);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetDetails(int id)
        {
            var value = _context.Faults
        .Include(s => s.Product)
        .Include(s => s.Customer)
        .FirstOrDefault(s => s.FaultId == id);

            if (value == null)
            {
                return NotFound();
            }

            var relatedFaults = _context.Faults
                .Where(f => f.ProductId == value.ProductId || f.CustomerId == value.CustomerId).Include(s => s.Product).Include(s => s.Customer).Include(s => s.Staff)
                .ToList();

            return View(relatedFaults);
        }
        public IActionResult FullCalendarEvents()
        {

            var Faults = _context.Faults.ToList();

            return new JsonResult(Faults);

        }
        public IActionResult FullCalendar(int id)
        {
            // SaleTransactionId'ye göre ürünleri almak
            var saleTransaction = _context.SaleTransactions
                .Include(st => st.Product) // SaleTransaction ile ilişkili ürünler
                .FirstOrDefault(st => st.SaleTransactionId == id);

            ViewBag.Customer = saleTransaction?.CustomerId;

            if (saleTransaction == null)
            {
                return NotFound();
            }

            // FaultDetails verisini alıyoruz
            var faultDetails = (from fault in _context.Faults
                                join customer in _context.Customers on fault.CustomerId equals customer.CustomerId into customerJoin
                                from customer in customerJoin.DefaultIfEmpty()
                                join product in _context.Products on fault.ProductId equals product.ProductId into productJoin
                                from product in productJoin.DefaultIfEmpty()
                                select new FaultDetailsDto
                                {
                                    FaultId = fault.FaultId,
                                    Status = fault.Status.GetStatusString(),
                                    Timestamp = fault.Timestamp,
                                    IsComplete = fault.IsComplete,
                                    Description = fault.Description,
                                    StartDate = fault.StartDate,
                                    EndDate = fault.EndDate,
                                    CustomerName = customer.CustomerName,
                                    CustomerAddress = customer.CustomerAdress,
                                    ProductName = product.ProductName
                                }).ToList();

            // ViewData'ya FaultDetails'ı ekliyoruz
            ViewData["FaultDetails"] = JsonConvert.SerializeObject(faultDetails);

            var faultViewModel = new FaultViewModel
            {
                ProductList = new List<ProductDTO>
    {
        new ProductDTO
        {
            ProductId = saleTransaction.Product.ProductId,
            ProductName = saleTransaction.Product.ProductName
        }
    },
                CustomerId = saleTransaction.CustomerId,
                Description = "",
                // StatusList'i FaultStatuEnum türünde geçiriyoruz
                StatusList = Enum.GetValues(typeof(FaultStatuEnum))
                     .Cast<FaultStatuEnum>()
                     .ToList()
            };


            // ViewData'ya JSON formatında FaultViewModel verisini ekliyoruz
            ViewData["FaultViewModel"] = JsonConvert.SerializeObject(faultViewModel);

            return View();
        }
        public async Task<IActionResult> AddFC([FromBody] FaultEventDTO eventData)
        {
            if (eventData == null)
            {
                return Json(new { success = false, message = "Veri boş geldi." });
            }

            try
            {
                // StartDate'ı DateTime'a dönüştürme
                if (!DateTime.TryParse(eventData.StartDate, out DateTime startDate))
                {
                    return Json(new { success = false, message = "Geçersiz başlangıç tarihi." });
                }

                // Event duration'ı dakika olarak ekliyoruz
                DateTime endDate = startDate.AddMinutes(eventData.Duration);

                // Status enum string değerini int'e dönüştürme
                if (!Enum.TryParse(eventData.Status, true, out FaultStatuEnum statusEnum))
                {
                    return Json(new { success = false, message = "Geçersiz FaultStatuEnum değeri." });
                }

                // Enum değerini integer olarak alıyoruz
                int statusIntValue = (int)statusEnum;

                // Yeni FaultEvent oluşturuluyor
                var faultEvent = new Fault
                {
                    Status = statusEnum,  // Enum değeri veritabanına kaydedilecek
                    ProductId = eventData.ProductId,
                    IsComplete = false,
                    Timestamp = DateTime.Now,
                    StartDate = startDate,
                    EndDate = endDate,
                    CustomerId = eventData.CustomerId,
                    StaffId = null,
                    SaleTransactionId = null,
                    Description = "Amk", // Burada açıklama değeri veritabanına kaydediliyor
                };

                // Veritabanına kaydetme işlemi
                _context.Faults.Add(faultEvent);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = $"Hata oluştu: {ex.Message}"
                });
            }
        }



    }
}
