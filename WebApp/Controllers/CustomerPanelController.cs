using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class CustomerPanelController : Controller
    {
        private Context _context;


        public CustomerPanelController(Context context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("CustomerEmail");

            var values = _context.Customers.FirstOrDefault(x => x.CustomerEmail == username);

            ViewBag.U = username;
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var username = HttpContext.Session.GetString("CustomerEmail");

            var cus = _context.Customers.Where(y => y.CustomerEmail == username).FirstOrDefault();

            if (cus != null)
            {
                cus.CustomerName = customer.CustomerName;
                cus.CustomerSurname = customer.CustomerSurname;
                cus.CustomerUserName = customer.CustomerUserName;
                cus.CustomerPassword = customer.CustomerPassword;
                cus.CustomerEmail = customer.CustomerEmail;
                cus.CustomerCity = customer.CustomerCity;
                cus.CustomerPhone = customer.CustomerPhone;
                cus.CustomerAdress = customer.CustomerAdress;
                cus.CustomerDistrict = customer.CustomerDistrict;
                _context.SaveChanges();
            }

            // Redirect to MyProfile with query parameter to select the "settings" tab
            return RedirectToAction("MyProfile", new { tab = "settings" });
        }
        public IActionResult MyProfile()
        {
            var mail = HttpContext.Session.GetString("CustomerEmail");

            var customerId = _context.Customers
                .Where(c => c.CustomerEmail == mail)
                .Select(c => c.CustomerId)
                .FirstOrDefault();

            if (customerId == 0)
            {
                // Handle case when no customer is found
                return NotFound();
            }

            var customer = _context.Customers.Find(customerId);

            if (customer == null)
            {
                // Handle case when customer is not found
                return NotFound();
            }

            // Pass the entire customer object to ViewData
            ViewData["Customer"] = customer;

            var saleTransactions = _context.SaleTransactions
                .Include(st => st.Customer)
                .Include(st => st.Product)
                .Include(st => st.Staff)
                .Include(st => st.Payment)
                .Where(st => st.CustomerId == customerId)
                .ToList();

            return View(saleTransactions);
        }

        public IActionResult MyOrders()
        {
            var username = HttpContext.Session.GetString("CustomerEmail");

            var Id = _context.Customers.Where(y => y.CustomerEmail == username).Select(x => x.CustomerId).FirstOrDefault();

            var customer = _context.Customers.Find(Id);

            // Pass the entire customer object to ViewData
            ViewData["Customer"] = customer;

            var values = _context.SaleTransactions.Include(x => x.Customer).
                Include(x => x.Product).Include(x => x.Staff).Include(x => x.Payment)
                .Where(y => y.CustomerId == Id).ToList();

            return View(values);
        }

        // Gelen mesajlar
        public IActionResult IncomingMessages()
        {
            var username = HttpContext.Session.GetString("CustomerEmail");

            var cus = _context.Customers.FirstOrDefault(x => x.CustomerEmail == username);
            // Alıcıya göre mesajları filtreleyin (Receiver)
            var values = _context.Messages.Where(y => y.Receiver == username).OrderByDescending(x => x.MessageId).ToList();

            // İstatistikleri hesaplayın
            var incoming = _context.Messages.Count(y => y.Receiver == username).ToString();
            var outgoing = _context.Messages.Count(y => y.Sender == username).ToString();

            ViewBag.incoming = incoming;
            ViewBag.outgoing = outgoing;
            return View(values);
        }

        // Gönderilen mesajlar
        public IActionResult OutgoingMessages()
        {
            var username = HttpContext.Session.GetString("CustomerEmail");
            var cus = _context.Customers.FirstOrDefault(x => x.CustomerEmail == username);

            // Göndericiye göre mesajları filtreleyin (Sender)
            var values = _context.Messages.Where(y => y.Sender == username).OrderByDescending(x => x.MessageId).ToList();

            // İstatistikleri hesaplayın
            var incoming = _context.Messages.Count(y => y.Receiver == username).ToString();
            var outgoing = _context.Messages.Count(y => y.Sender == username).ToString();

            ViewBag.incoming = incoming;
            ViewBag.outgoing = outgoing;
            return View(values);
        }

        [HttpGet("/CustomerPanel/MessageDetail/{messageId}")]
        public IActionResult MessageDetail(int messageId)
        {

            var values = _context.Messages.FirstOrDefault(x => x.MessageId == messageId);


            var username = HttpContext.Session.GetString("CustomerEmail");
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerUserName == username);


            var incoming = _context.Messages.Count(y => y.Receiver == username).ToString();
            var outgoing = _context.Messages.Count(y => y.Sender == username).ToString();

            ViewBag.incoming = incoming;
            ViewBag.outgoing = outgoing;

            return View(values);
        }
        [HttpGet("/CustomerPanel/MessageDetailOut/{messageId}")]
        public IActionResult MessageDetailOut(int messageId)
        {

            var values = _context.Messages.FirstOrDefault(x => x.MessageId == messageId);


            var username = HttpContext.Session.GetString("CustomerEmail");
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerUserName == username);


            var incoming = _context.Messages.Count(y => y.Receiver == username).ToString();
            var outgoing = _context.Messages.Count(y => y.Sender == username).ToString();

            ViewBag.incoming = incoming;
            ViewBag.outgoing = outgoing;

            return View(values);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            var username = HttpContext.Session.GetString("CustomerEmail");
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerUserName == username);


            var incoming = _context.Messages.Count(y => y.Receiver == username).ToString();
            var outgoing = _context.Messages.Count(y => y.Sender == username).ToString();

            ViewBag.incoming = incoming;
            ViewBag.outgoing = outgoing;


            message.Sender = username;
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("OutgoingMessages");
        }
        public IActionResult CargoTracking(string c)
        {
            var carg = _context.CargoDetails.AsQueryable();

            if (!string.IsNullOrEmpty(c))
            {
                carg = carg.Where(y => y.TrackingCode.Contains(c));
            }
            return View(carg.ToList());
        }
        public IActionResult CargoDetail(string id)
        {
            var values = _context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewCargo()
        {
            Random rnd = new Random();
            string[] chars = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 999);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string code = s1 + chars[k1] + s2 + chars[k2] + s3 + chars[k3];
            ViewBag.TrackingCode = code;
            return View();
        }
        [HttpPost]
        public IActionResult NewCargo(CargoDetail cargoDetail)
        {
            _context.CargoDetails.Add(cargoDetail);
            _context.SaveChanges();
            return RedirectToAction("CargoTracking");
        }
        public IActionResult Detail(string id)
        {
            var values = _context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Kullanıcının oturumunu kapat
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Session'ı temizle
            HttpContext.Session.Clear();

            // Giriş sayfasına yönlendir
            return RedirectToAction("Index", "Login");
        }
    }
}


