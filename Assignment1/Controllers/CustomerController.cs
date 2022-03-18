using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Assignment1.Controllers
{
    public class CustomerController : Controller
    {
        private IncidentContext context { get; set; }

        public CustomerController(IncidentContext ctx)
        {
            context = ctx;
        }

        // Attribute Routing
        // Change List, HttpGet Add, Edit & Delete to ViewResult
        [Route("[controller]s")]
        public ViewResult List()
        {
            var customer = context.Customer;
            return View(customer);
        }

        [HttpGet]
        public ViewResult Add()
        {
            // TO DO
            ViewBag.Action = "Add";
            ViewBag.Country = context.Country.OrderBy(context => context.countryName).ToList();

            return View("Edit", new Customer());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Country = context.Country.OrderBy(context => context.countryName).ToList();

            var customer = context.Customer
                .Include(context => context.customerCountry)
                .FirstOrDefault(context => context.customerId == id);
            return View(customer);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var customer = context.Customer
                .FirstOrDefault(context => context.customerId == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.customerId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    TempData["message"] = "Customer: \"" + customer.customerFullName + "\" was added.";
                    context.Customer.Add(customer);
                }
                else
                {
                    TempData["message"] = "Customer: \"" + customer.customerFullName + "\" was edited.";
                    context.Customer.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Country = context.Country.OrderBy(context => context.countryName).ToList();
                return View(customer);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Customer customer)
        {
            TempData["message"] = "Customer: \"" + customer.customerFullName + "\" was deleted.";
            context.Customer.Remove(customer); // remove 
            context.SaveChanges();
            return RedirectToAction("List", "Customer");

        }

        //[AllowAnonymous]
        //public async Task<JsonResult> UserAlreadyExistsAsync(string customerEmail)
        //{ trying to implement "Email already exists" 
        //  https://stackoverflow.com/questions/28505294/how-to-check-if-user-already-exists-on-client-side-in-asp-net-mvc-5
        //    var result =
        //        await UserManager.FindByNameAsync(customerEmail) ??
        //        await UserManager.FindByEmailAsync(customerEmail);
        //    return Json(result == null, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //}
    }
}