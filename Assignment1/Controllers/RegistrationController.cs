using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Assignment1.Controllers
{
    public class RegistrationController : Controller
    {
        private IncidentContext context { get; set; }

        public RegistrationController(IncidentContext ctx)
        {
            context = ctx;
        }

        public IActionResult GetCustomer(int id)
        {
            if (id == -1)
            {
                ViewBag.message = "true";
            }

            var customers = context.Customer.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            if (id == -1)
            {
                return RedirectToAction("GetCustomer", "Registration", new { id = id });
            }

            HttpContext.Session.SetInt32("customerId", id);
            ViewBag.customer = context.Customer.Where(context => context.customerId == id).ToList();
            var registration = context.Registration.Where(context => context.customerId == id).ToList();
            ViewBag.products = context.Product.ToList();

            return View(registration);
        }
        
        [HttpPost]
        public IActionResult Add(int productId)
        {
            int? cusId = HttpContext.Session.GetInt32("customerId");

            Registration temp = new Registration
            {
                customerId = (int)cusId,
                productId = productId
            };
            context.Registration.Add(temp);
            context.SaveChanges();
            return RedirectToAction("Index", "Registration", new { id = cusId });
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            var cusId = HttpContext.Session.GetInt32("customerId");
            var registration = context.Registration.Where(context => context.customerId == cusId && context.productId == productId).ToList();
            foreach(Registration regis in registration)
            {
                context.Registration.Remove(regis);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Registration", new { id = cusId });
        }
    }
}
