using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Models.Classes;
using X.PagedList.Extensions;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private Context _context;
        public CategoryController(Context context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var categories = _context.Categories.ToPagedList(page, 2); // IPagedList<Category> döner
            return View(categories);
        }
        [HttpGet]
        public IActionResult NewCategory() {

            return View();
        }

        [HttpPost]
        public IActionResult NewCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetCategory(int id) 
        {
            var cat = _context.Categories.Find(id);
            return View("GetCategory",cat);
        }
        public IActionResult UpdateCategory(Category c)
        {
            var cat = _context.Categories.Find(c.CategoryId);
            cat.CategoryName = c.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
