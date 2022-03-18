using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class IncidentEditViewModel
    {
        public int IncidentEditViewModelId { get; set; }

        public Incident? currIncident { get; set; }

        public List<Customer> customers { get; set; }

        public List<Product> products { get; set; }

        public List<Technician> technicians { get; set; }

        public string currAction { get; set; }
    }
}
