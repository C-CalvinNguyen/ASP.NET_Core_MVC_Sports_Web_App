using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; } // primary key is mandatory so no need to put required

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid Customer First Name")]
        public string customerFirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid Customer Last Name")]
        public string customerLastName { get; set; }

        public string customerFullName
        {
            get
            {
                return string.Format(customerFirstName + " " + customerLastName);
            }
        }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid Customer Address")]
        public string customerAddress { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid Customer City")]
        public string customerCity { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid Customer State")]
        public string customerState { get; set; }

        [Required(ErrorMessage = "Please enter a valid Customer Postal Code")]
        [StringLength(20, MinimumLength = 1)]
        public string customerPostalCode { get; set; }

        [Required(ErrorMessage = "Please select a Country")]
        public int? customerCountryId { get; set; }
        
        public Country customerCountry { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Address")]
        [Remote("UserAlreadyExistsAsync", "Account", ErrorMessage = "User with this Email already exists")]

        public string customerEmail { get; set; }

        [Required(ErrorMessage = "Phone number must be in (999) 999-9999 format")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number must be in (999) 999-9999 format")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be in (999) 999-9999 format")]
        public string customerPhone { get; set; } 

        // navigation to linking entity
        public ICollection<Registration> registrations { get; set; }
    }
}
