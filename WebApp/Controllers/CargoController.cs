using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class CargoController : Controller
    {
        private Context _context;
        public CargoController(Context context)
        {
            _context = context;
        }
        public IActionResult Index(string c)
        {
            var carg = _context.CargoDetails.AsQueryable();

            if (!string.IsNullOrEmpty(c))
            {
                carg = carg.Where(y => y.TrackingCode.Contains(c));
            }
            return View(carg.ToList());
        }
        [HttpGet]
        public IActionResult NewCargo()
        {
            Random rnd = new Random();
            string[] chars = { "A", "B", "C", "D" };
            int k1,k2,k3;
            k1 = rnd.Next(0,4);
            k2 = rnd.Next(0,4);
            k3 = rnd.Next(0,4);
            int s1,s2,s3;
            s1=rnd.Next(100,999);
            s2=rnd.Next(10,99);
            s3=rnd.Next(10,99);

            string code = s1 + chars[k1]+s2 + chars[k2]+s3+ chars[k3];
            ViewBag.TrackingCode = code;
            return View();
        }
        [HttpPost]
        public IActionResult NewCargo(CargoDetail cargoDetail)
        {
            _context.CargoDetails.Add(cargoDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(string id)
        {
            var values = _context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
    }
}
