using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models.Classes;

namespace WebApp.Controllers
{
	public class LoginController : Controller
	{
		private readonly Context _context;

		public LoginController(Context context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult PartialKep()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult PartialKep(Customer customer)
		{
			_context.Customers.Add(customer);
			_context.SaveChanges();

			return PartialView();
		}

		[HttpGet]
		public IActionResult CustomerLogin()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CustomerLogin(Customer customer)
		{
			var infos = _context.Customers.FirstOrDefault(x =>
				x.CustomerEmail == customer.CustomerEmail &&
				x.CustomerPassword == customer.CustomerPassword);

			if (infos != null)
			{
				// Claims oluşturuluyor
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, infos.CustomerEmail)
				};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				// Kimlik doğrulama çerezi ayarlanıyor
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

				// Session'da kullanıcı adını saklamak
				HttpContext.Session.SetString("CustomerEmail", infos.CustomerEmail);


				return RedirectToAction("Index", "CustomerPanel");
			}
			else
			{
				// Hatalı giriş durumunda hata mesajı gösterme
				ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
				return RedirectToAction("Index","Login");
			}

		}
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AdminLogin(Admin admin)
        {
            var infos = _context.Admins.FirstOrDefault(x =>
                x.UserName == admin.UserName &&
                x.Password == admin.Password);

            if (infos != null)
            {
                // Claims oluşturuluyor
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, infos.UserName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Kimlik doğrulama çerezi ayarlanıyor
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Session'da kullanıcı adını saklamak
                HttpContext.Session.SetString("UserName", infos.UserName);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Hatalı giriş durumunda hata mesajı gösterme
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
                return RedirectToAction("Index", "Login");
            }

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
