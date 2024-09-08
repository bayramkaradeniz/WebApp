using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class StaffController : Controller
    {
        private Context _context;
        public StaffController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var stf = _context.Staffs.Include(x => x.Department).ToList();
            return View(stf);
        }
        [HttpGet]
        public IActionResult NewStaff()
        {
            List<SelectListItem> values = (from x in _context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewStaff(Staff stf)
        {
            _context.Staffs.Add(stf);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var stf = _context.Staffs.Find(id);
            _context.Remove(stf);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetStaff(int id)
        {

            List<SelectListItem> values = (from x in _context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            var stf = _context.Staffs.Find(id);
            return View("GetStaff", stf);
        }
        public IActionResult UpdateStaff(Staff staff)
        {
            var stf = _context.Staffs.Find(staff.StaffId);

            stf.StaffFullName = staff.StaffFullName;
            stf.StaffMail = staff.StaffMail;
            stf.StaffPassword = staff.StaffPassword;
            stf.StaffImage = staff.StaffImage;
            stf.DepartmentId = staff.DepartmentId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult StaffList()
        {
            var stf = _context.Staffs.Include(x => x.Department).ToList();
            return View(stf);
        }
    }
}
