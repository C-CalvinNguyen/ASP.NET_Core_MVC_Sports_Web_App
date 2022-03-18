using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class IncidentController : Controller
    {
        private IncidentContext context { get; set; }

        public IncidentController(IncidentContext ctx)
        {
            context = ctx;
        }

        // Attribute Routing
        // Change List, HttpGet Add, Edit & Delete to ViewResult
        // Added View Model for Incident Manager List Page
        [Route("[controller]s")]
        public ViewResult List(string filter)
        {

            var viewModel = new IncidentListViewModel { };

            // If the string filter is not null (Used one of the filter anchor tags) it creates a list of incidents based on the filter
            if (filter != null)
            {

                viewModel.filter = filter;

                if (filter == "all")
                {
                    viewModel.incidents = context.Incident.ToList();
                }
                if (filter == "unassigned")
                {
                    // Unassigned gets incidents where the technicianId is null
                    viewModel.incidents = context.Incident.Where(context => context.incidentTechnicianId == null).ToList();
                }
                if (filter == "open")
                {
                    // Open gets incidents where the date closed is null
                    viewModel.incidents = context.Incident.Where(context => context.incidentDateClosed == null).ToList();
                }
            }
            else
            {
                // If filter is null it defaults to ALL incidents
                viewModel.incidents = context.Incident.ToList();
            }

            ViewBag.filter = filter;
            ViewBag.Customer = context.Customer.OrderBy(context => context.customerId).ToList();
            ViewBag.Product = context.Product.OrderBy(context => context.productId).ToList();
            return View(viewModel);
        }

        // Added View Model for Add & Edit Pages
        [HttpGet]
        public ViewResult Add()
        {
            // TO DO

            var viewModel = new IncidentEditViewModel
            {
                currAction = "Add",
                customers = context.Customer.ToList(),
                products = context.Product.ToList(),
                technicians = context.Technician.ToList(),

            };
            return View("Edit", viewModel);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
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

        [HttpGet]
        public ViewResult Delete(int id)
        {
            ViewBag.Customer = context.Customer.OrderBy(context => context.customerId).ToList();
            ViewBag.Product = context.Product.OrderBy(context => context.productId).ToList();
            ViewBag.Technician = context.Technician.OrderBy(context => context.technicianId).ToList();

            var incident = context.Incident
                .FirstOrDefault(context => context.incidentId == id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(IncidentEditViewModel vm)
        {
            string action = (vm.currIncident.incidentId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    TempData["message"] = "Incident ID: \"" + vm.currIncident.incidentId + "\" was added.";
                    context.Incident.Add(vm.currIncident);
                }
                else
                {
                    TempData["message"] = "Incident ID: \"" + vm.currIncident.incidentId + "\" was edited.";
                    context.Incident.Update(vm.currIncident);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                var viewModel = new IncidentEditViewModel
                {
                    currAction = action,
                    customers = context.Customer.ToList(),
                    products = context.Product.ToList(),
                    technicians = context.Technician.ToList(),
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Incident incident)
        {
            TempData["message"] = "Incident ID: \"" + incident.incidentId + "\" was deleted.";
            context.Incident.Remove(incident); // remove 
            context.SaveChanges();
            return RedirectToAction("List", "Incident");


        }
    }
}