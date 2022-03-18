using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers
{
    public class TechnicianController : Controller
    {
        private IncidentContext context { get; set; }

        public TechnicianController(IncidentContext ctx)
        { // access to dependency injection that gives us the database
            context = ctx;
        }

        // Attribute Routing
        // Change List, HttpGet Add, Edit & Delete to ViewResult
        [Route("[controller]s")]
        public ViewResult List()
        {
            var technican = context.Technician; 
            return View(technican);
        }

        [HttpGet]
        public ViewResult Add()
        {
            // TO DO
            ViewBag.Action = "Add";
            ViewBag.Technician = context.Technician.OrderBy(c => c.technicianFullName.ToList());
            return View("Edit", new Technician()); // // forward to edit view page and an empty value contact page
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            
            var technician = context.Technician
                .FirstOrDefault(context => context.technicianId == id);
            return View(technician);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var technician = context.Technician
                .FirstOrDefault(context => context.technicianId == id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.technicianId==0)?"Add":"Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    TempData["message"] = "Technician: \"" + technician.technicianFullName + "\" was added.";
                    context.Technician.Add(technician);

                }
                else
                {
                    TempData["message"] = "Technician: \"" + technician.technicianFullName + "\" was edited.";
                    context.Technician.Update(technician);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Technician"); // return to technician list
            }
            else //if Model state is not valid
            {
                ViewBag.Action = action;
                ViewBag.Technician = context.Technician.OrderBy(c => c.technicianFullName.ToList());
            }
            return View(technician);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Technician technician)
        {
            TempData["message"] = "Technician: \"" + technician.technicianFullName + "\" was deleted.";
            context.Technician.Remove(technician); // remove technician
            context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }
    }
}