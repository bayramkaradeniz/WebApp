using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class BillController : Controller
    {
        private Context _context;
        public BillController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Bills.Include(x => x.BillItems).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewBill(){return View();}
        [HttpPost]
        public IActionResult NewBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetBill(int id)
        {

            var bill = _context.Bills.Find(id);
            return View("GetBill", bill);
        }
        public IActionResult UpdateBill(Bill bill)
        {
            var bl = _context.Bills.Find(bill.BillId);

            bl.BillSequenceNo = bill.BillSequenceNo;
            bl.BillSerialNo = bill.BillSerialNo;
            bl.TaxOffice = bill.TaxOffice;
            bl.Date = bill.Date;
            bl.Hour = bill.Hour;
            bl.Sender = bill.Sender;
            bl.Receiver = bill.Receiver;
            bl.Total = bill.Total;
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var values = _context.BillItems.Where(x => x.BillId == id).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewItem(BillItem billItem)
        {
            _context.BillItems.Add(billItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
