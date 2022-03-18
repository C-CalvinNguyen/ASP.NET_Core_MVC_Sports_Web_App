using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Assignment1.Controllers
{
    public class TechIncidentController : Controller
    {
        private IncidentContext context { get; set; }

        public TechIncidentController(IncidentContext ctx)
        {
            context = ctx;
        }


        public IActionResult Get(int id)
        {
            if (id == -1)
            {
                ViewBag.message = "true";
            }

            var technician = context.Technician.ToList();
            return View(technician);
        }

        [HttpGet]
        public IActionResult List(int id)
        {

            if (id == -1)
            {
                return RedirectToAction("Get", "TechIncident", new { id = id });
            }
            else
            {
                HttpContext.Session.SetInt32("newId", id);
            }

            var viewModel = new IncidentListViewModel
            {
                incidents = context.Incident.Where(context => context.incidentDateClosed == null && context.incidentTechnicianId == id).ToList()
            };

            ViewBag.Technician = context.Technician.Where(context => context.technicianId == id).ToList();
            ViewBag.Customer = context.Customer.OrderBy(context => context.customerId).ToList();
            ViewBag.Product = context.Product.OrderBy(context => context.productId).ToList();
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Session = HttpContext.Session.GetInt32("newId");
            var viewModel = new IncidentEditViewModel
            {
                currAction = "Edit",
                currIncident = context.Incident.FirstOrDefault(context => context.incidentId == id),
                customers = context.Customer.ToList(),
                products = context.Product.ToList(),
                technicians = context.Technician.ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(IncidentEditViewModel vm)
        {

            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32("newId") != null)
                {
                    int? id = HttpContext.Session.GetInt32("newId");
                    context.Incident.Update(vm.currIncident);
                    context.SaveChanges();
                    return RedirectToAction("List", "TechIncident", new { id = id });
                }
                else
                {
                    context.Incident.Update(vm.currIncident);
                    context.SaveChanges();
                    return RedirectToAction("List", "TechIncident");
                }
            }
            else
            {
                var viewModel = new IncidentEditViewModel
                {
                    currAction = "Edit",
                    customers = context.Customer.ToList(),
                    products = context.Product.ToList(),
                    technicians = context.Technician.ToList(),
                };
                return View(viewModel);
            }
        }
    }
}

