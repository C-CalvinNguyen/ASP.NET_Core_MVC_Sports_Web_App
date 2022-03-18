using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class IncidentListViewModel
    {
        public int IncidentListViewModelId { get; set; }
        public List<Incident> incidents { get; set; }

        public string filter { get; set; } = "all";
    }
}
