using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Registration
    {
        public int customerId { get; set; }

        public Customer customer { get; set; }

        public int productId { get; set; }

        public Product product { get; set; }
    }
}
