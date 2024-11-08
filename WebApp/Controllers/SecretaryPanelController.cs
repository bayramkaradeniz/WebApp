using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
    public class SecretaryPanelController : Controller
    {
        private Context _context;


        public SecretaryPanelController(Context context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var mail = HttpContext.Session.GetString("StaffMail");

            var fullName = _context.Staffs.FirstOrDefault(x => x.StaffMail == mail).StaffFullName;

            ViewBag.fullName = fullName;
            return View();
        } 
        public IActionResult Customer()
        {
            return View();
        }
    }
}
