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
			var username =  HttpContext.Session.GetString("CustomerUserName");

			var values = _context.Customers.FirstOrDefault(x=>x.CustomerUserName == username);

            ViewBag.U=username;
            return View(values);
		}

        public IActionResult MyOrders()
        {
            var username = HttpContext.Session.GetString("CustomerUserName");

            var Id = _context.Customers.Where(y=>y.CustomerUserName == username).Select(x=>x.CustomerId).FirstOrDefault();

            var values = _context.SaleTransactions.Include(x=>x.Customer).Include(x => x.Payment).
                Include(x=>x.Product).Include(x => x.Staff)
                .Where(y => y.CustomerId == Id).ToList();

            return View(values);
        }
    }
}
