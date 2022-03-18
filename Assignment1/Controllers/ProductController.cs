using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {
        private IncidentContext context { get; set; }

        public ProductController(IncidentContext ctx)
        {
            context = ctx;
        }

        // Attribute Routing
        // Change List, HttpGet Add, Edit & Delete to ViewResult
        [Route("[controller]s")]
        public ViewResult List()
        {
            var product = context.Product;
            return View(product);
        }

        [HttpGet]
        public ViewResult Add()
        {
            // TO DO
            ViewBag.Action = "Add";
            ViewBag.Product = context.Product.OrderBy(c => c.productName.ToList());
            return View("Edit", new Product());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var product = context.Product
                .FirstOrDefault(context => context.productId == id);
            return View(product);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Product
                .FirstOrDefault(context => context.productId == id);
            return View(product);
        }

        /* 
         * HttpPost Edit keeps the IActionResult
         * due to Redirecting if completing add or edit action
         * OR it stays on the page if modelstate is not valid
         */
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string action = (product.productId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    TempData["message"] = "Product: \"" + product.productName + "\" was added.";
                    context.Product.Add(product);
                }
                else
                {
                    TempData["message"] = "Product: \"" + product.productName + "\" was edited.";
                    context.Product.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Product");
            }
            else
            {

                ViewBag.Action = action;
                return View(product);
            }
        }

        // Change HttpPost Delete to RedirectToActionResult
        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            TempData["message"] = "Product: \"" + product.productName + "\" was deleted.";
            context.Product.Remove(product); // remove 
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
