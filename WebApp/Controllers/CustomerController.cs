using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private Context _context;
        public CustomerController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cus = _context.Customers.ToList();
            return View(cus);
        }
        [HttpGet]
        public IActionResult NewCustomer() { return View(); }
        [HttpPost]
        public IActionResult NewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetCustomer(int id) 
        {  
            var cus = _context.Customers.Find(id);
            return View("GetCustomer",cus); 
        }
        public IActionResult UpdateCustomer(Customer customer)
        {
            var cus = _context.Customers.Find(customer.CustomerId);

            cus.CustomerName = customer.CustomerName;
            cus.CustomerSurname = customer.CustomerSurname;
            cus.CustomerEmail = customer.CustomerEmail;
            cus.CustomerCity = customer.CustomerCity;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SaleHistory(int id)
        {
            var values = _context.SaleTransactions.Include(x=>x.Customer).Include(x => x.Staff).Include(x => x.Product).Where(x=>x.CustomerId == id).ToList();

            var dep = _context.Customers.Where(x => x.CustomerId == id).Select(y => y.CustomerName + " " +y.CustomerSurname).FirstOrDefault();
            ViewBag.Name = dep;
            return View(values);
        }
    }
}
