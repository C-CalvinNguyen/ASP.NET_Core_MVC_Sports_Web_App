using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Assignment1.Models
{
    public class Technician
    {
        [Key]
        public int technicianId { get; set; } // nullable type for technicianid mentioned in instructions
        //• To make the Technician field optional, make sure to specify a nullable int type (?int) for the TechnicianID
        //property of the Incident entity class.
        [Required(ErrorMessage = "Please enter a valid Technician Full Name")]
        public string technicianFullName { get; set; }
        [Required(ErrorMessage = "Please enter a valid Technician Email")]
        public string technicianEmail { get; set; }
        [Required(ErrorMessage = "Please enter a valid Technician Phone Number")]
        public string technicianPhone { get; set; }
     


    }
}
