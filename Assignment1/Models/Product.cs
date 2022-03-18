using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Assignment1.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Code")]
        public string productCode { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Name")]
        public string productName { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Price")]
        public double productPrice { get; set; }

        public DateTime productReleaseDate { get; set; } //Validate the data the user enters in the Add/Edit 
        //Product page to be sure that the user enters a product code, name,
        //and price.If this data isn’t provided, the app should display a summary of the validation errors above the form.

        // navigation to linking entity
        public ICollection<Registration> registrations { get; set; }
    }
}
