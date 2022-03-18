using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Assignment1.Models
{
    public class Incident
    {
        [Key]
        public int incidentId { get; set; }
        [Required(ErrorMessage = "Please enter a valid Incident Title")]
        public string incidentTitle { get; set; }
        [Required(ErrorMessage = "Please enter a valid Incident Description")]
        public string incidentDescription { get; set; }

        // Customer
        [Range(1, 100000, ErrorMessage = "Please select a valid Customer")]
        public int incidentCustomerId { get; set; } // in add/edit incidents page user must select customer and product from dropdown
        public Customer incidentCustomer { get; set; }

        // Product
        [Range(1, 100000, ErrorMessage = "Please select a valid Incident Product")]
        public int incidentProductId { get; set; }
        public Product incidentProduct { get; set; }

        // Technician
        public int? incidentTechnicianId { get; set; }
        public Technician incidentTechnician { get; set; }

        // Dates
        public DateTime incidentDateOpened { get; set; } 

        // Removed the requirement due to dateclosed being nullable (Used for Open Incidents filter)
        public DateTime? incidentDateClosed { get; set; }
    }
}
