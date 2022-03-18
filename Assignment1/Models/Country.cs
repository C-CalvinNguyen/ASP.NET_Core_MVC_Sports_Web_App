using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Country
    {
        [Key]
        public int countryId { get; set; }

        public string countryName { get; set; }
    }
}
