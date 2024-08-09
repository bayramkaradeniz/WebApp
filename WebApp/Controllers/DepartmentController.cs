using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private Context _context;
        public DepartmentController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dep = _context.Departments.Where(x => x.State == true).ToList();
            return View(dep);
        }
        [HttpGet]
        public IActionResult NewDepartment()
        {

            return View();
        }

        [HttpPost]
        public IActionResult NewDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var dep = _context.Departments.Find(id);
            dep.State = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            return View("GetDepartment", department);
        }
        public IActionResult UpdateDepartment(Department d)
        {
            var cat = _context.Departments.Find(d.DepartmentId);
            cat.DepartmentName = d.DepartmentName;
            cat.State = d.State;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var values = _context.Staffs.Where(x => x.DepartmentId == id).ToList();
            var dep = _context.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.Name = dep;
            return View(values);
        }

        public IActionResult DepartmentStaffSale(int id) 
        {
            var values = _context.SaleTransactions.Where(x => x.StaffId == id).ToList();
            var dep = _context.Staffs.Where(x => x.StaffId == id).Select(y => y.StaffFullName).FirstOrDefault();
            ViewBag.Name = dep;
            return View(values); 
        }

    }
}
