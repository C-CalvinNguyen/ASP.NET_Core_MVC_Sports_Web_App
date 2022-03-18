using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(customer => customer.customerId);

            entity.HasData(
                    new Customer
                    {
                        customerId = 1,
                        customerFirstName = "Kaitlyn",
                        customerLastName = "Anthoni",
                        customerAddress = "100 Apple Street",
                        customerCity = "San Francisco",
                        customerState = "California",
                        customerPostalCode = "90001",
                        customerCountryId = 1,
                        customerEmail = "kanthoni@pge.com",
                        customerPhone = "555-555-1000"

                    },
                    new Customer
                    {
                        customerId = 2,
                        customerFirstName = "Ana",
                        customerLastName = "Irvin",
                        customerAddress = "200 Banana Street",
                        customerCity = "Washington",
                        customerState = "D.C.",
                        customerPostalCode = "90002",
                        customerCountryId = 2,
                        customerEmail = "ania@mma.nidc.com",
                        customerPhone = "555-555-1001"
                    },
                    new Customer
                    {
                        customerId = 3,
                        customerFirstName = "Gonzalo",
                        customerLastName = "Keeton",
                        customerAddress = "300 Corn Street",
                        customerCity = "Mission Viejo",
                        customerState = "California",
                        customerPostalCode = "90003",
                        customerCountryId = 2,
                        customerEmail = " ",// wireframe shows it to be blank
                        customerPhone = "555-555-1002"
                    },
                    new Customer
                    {
                        customerId = 4,
                        customerFirstName = "Anton",
                        customerLastName = "Mauro",
                        customerAddress = "400 Dingleberry Street",
                        customerCity = "Sacramento",
                        customerState = "Calfiornia",
                        customerPostalCode = "90004",
                        customerCountryId = 2,
                        customerEmail = "amauro@yahoo.org",
                        customerPhone = "555-555-1003"
                    },
                    new Customer
                    {
                        customerId = 5,
                        customerFirstName = "Kendall",
                        customerLastName = "Mayte",
                        customerAddress = "500 Eggfruit Street",
                        customerCity = "Fresno",
                        customerState = "California",
                        customerPostalCode = "90005",
                        customerCountryId = 2,
                        customerEmail = "kmayte@fresno.ca.gov",
                        customerPhone = "555-555-1004"
                    },
                    new Customer
                    {
                        customerId = 6,
                        customerFirstName = "Kenzie",
                        customerLastName = "Quinn",
                        customerAddress = "600 Finger Lime Street",
                        customerCity = "Los Angeles",
                        customerState = "California",
                        customerPostalCode = "90006",
                        customerCountryId = 2,
                        customerEmail = "kenzie@mma.jobtrack.com",
                        customerPhone = "555-555-1005"
                    },
                    new Customer
                    {
                        customerId = 7,
                        customerFirstName = "Marvin",
                        customerLastName = "Quintin",
                        customerAddress = "700 Grape Street",
                        customerCity = "Fresno",
                        customerState = "California",
                        customerPostalCode = "90007",
                        customerCountryId = 2,
                        customerEmail = "marvin@expedata.com",
                        customerPhone = "555-555-1006"
                    }
                );
        }
    }
}
