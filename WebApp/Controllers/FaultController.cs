﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using WebApp.Models.Classes;
using Fault = WebApp.Models.Classes.Fault;

namespace WebApp.Controllers
{
    public class FaultController : Controller
    {
        private Context _context;
        public FaultController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Faults.Where(x => x.IsComplete == false).Include(x => x.Product).Include(x => x.Customer).Include(x => x.Staff).ToList();
            return View(values);
        }
        public IActionResult CompletedFault()
        {
            var values = _context.Faults.Where(x => x.IsComplete == true).Include(x => x.Product).Include(x => x.Customer).Include(x => x.Staff).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewFault()
        {
            List<SelectListItem> valueFP = _context.Products
                .Select(x => new SelectListItem
                {
                    Text = $"Name: {x.ProductName} Model: {x.ProductModel}",
                    Value = x.ProductId.ToString()
                }).ToList();

            List<SelectListItem> valueFC = _context.Customers
                .Select(x => new SelectListItem
                {
                    Text = $"{x.CustomerName} {x.CustomerSurname}",
                    Value = x.CustomerId.ToString()
                }).ToList();

            List<SelectListItem> valueFS = _context.Staffs
    .Select(x => new SelectListItem
    {
        Text = x.StaffFullName,
        Value = x.StaffId.ToString()
    }).ToList();
            List<SelectListItem> valuePM = _context.PaymentCategories
                .Select(x => new SelectListItem
                {
                    Text = x.PaymentCategoryName,
                    Value = x.PaymentCategoryId.ToString()
                }).ToList();

            ViewBag.valueFP = valueFP;
            ViewBag.valueFC = valueFC;
            ViewBag.valueFS = valueFS;

            return View();
        }
        [HttpPost]
        public IActionResult NewFault(Fault fault)
        {
            fault.Timestamp = DateTime.Now;
            fault.Status = FaultStatuEnum.Yeni;

            _context.Faults.Add(fault);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetFault(int id)
        {
            List<SelectListItem> valueFS = _context.Staffs
    .Select(x => new SelectListItem
    {
        Text = x.StaffFullName,
        Value = x.StaffId.ToString()
    }).ToList();

            var valuePD = Enum.GetValues(typeof(FaultStatuEnum))
               .Cast<FaultStatuEnum>()
               .Select(e => new SelectListItem
               {
                   Text = e.ToString(), // Enum değerinin ismini kullanıyoruz
                   Value = ((int)e).ToString() // Enum değerinin int karşılığını kullanıyoruz
               }).ToList();


            ViewBag.valueFS = valueFS;
            ViewBag.valuePD = valuePD;

            var pro = _context.Faults.Include(x => x.Customer).Include(x => x.Product).FirstOrDefault(x => x.FaultId == id);
            return View("GetFault", pro);
        }
        public IActionResult UpdateFault(Fault fault)
        {
            var flt = _context.Faults.Find(fault.FaultId);

            flt.IsComplete = true;

            var newFault = new Fault()
            {
                CustomerId = flt.CustomerId,
                ProductId = flt.ProductId,
                Description = fault.Description,
                StaffId = fault.StaffId,
                Status = fault.Status,
                Timestamp = DateTime.Now,
                IsComplete = false
            };

            _context.Faults.Add(newFault);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetDetails(int id)
        {
            var value = _context.Faults
        .Include(s => s.Product)
        .Include(s => s.Customer)
        .FirstOrDefault(s => s.FaultId == id);

            if (value == null)
            {
                return NotFound(); 
            }

            var relatedFaults = _context.Faults
                .Where(f => f.ProductId == value.ProductId || f.CustomerId == value.CustomerId).Include(s => s.Product).Include(s => s.Customer).Include(s => s.Staff)
                .ToList();

            return View(relatedFaults);
        }
    }
}
