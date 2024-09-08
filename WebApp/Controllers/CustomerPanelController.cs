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
			var username =  HttpContext.Session.GetString("CustomerEmail");

			var values = _context.Customers.FirstOrDefault(x=>x.CustomerEmail == username);

            ViewBag.U=username;
            return View(values);
		}
        
        public IActionResult MyOrders()
        {
            var username = HttpContext.Session.GetString("CustomerEmail");

            var Id = _context.Customers.Where(y=>y.CustomerEmail == username).Select(x=>x.CustomerId).FirstOrDefault();

            var values = _context.SaleTransactions.Include(x=>x.Customer).
                Include(x=>x.Product)
                .Where(y => y.CustomerId == Id).ToList();

            return View(values);
        }
       
        // Gelen mesajlar
        public IActionResult IncomingMessages()
        {
            var username = HttpContext.Session.GetString("CustomerEmail");

            var cus = _context.Customers.FirstOrDefault(x => x.CustomerEmail == username);
            // Alıcıya göre mesajları filtreleyin (Receiver)
            var values = _context.Messages.Where(y => y.Receiver == username).OrderByDescending(x=>x.MessageId).ToList();

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
            message.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("OutgoingMessages");
        }
    }
}


