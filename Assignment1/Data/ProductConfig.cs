using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(product => product.productId);

            entity.HasData(
                    new Product
                    {
                        productId = 1,
                        productCode = "TRNY10",
                        productName = "Tournament Master 1.0",
                        productPrice = 4.99,
                        productReleaseDate = new DateTime(2015, 12, 1) //YYYY/M/d
                    },
                    new Product
                    {
                        productId = 2,
                        productCode = "LEAG10",
                        productName = "League Scheduler 1.0",
                        productPrice = 4.99,
                        productReleaseDate = new DateTime(2016, 5, 1)
                    }, new Product
                    {
                        productId = 3,
                        productCode = "LEAGD10",
                        productName = "League Scheduler Deluxe 1.0",
                        productPrice = 7.99,
                        productReleaseDate = new DateTime(2016, 8, 1)
                    }, new Product
                    {
                        productId = 4,
                        productCode = "DRAFT10",
                        productName = "Draft Manager 1.0",
                        productPrice = 4.99,
                        productReleaseDate = new DateTime(2017, 2, 1)
                    }, new Product
                    {
                        productId = 5,
                        productCode = "TEAM10",
                        productName = "Team Manager 1.0",
                        productPrice = 4.99,
                        productReleaseDate = new DateTime(2017, 5, 1)
                    }, new Product
                    {
                        productId = 6,
                        productCode = "TRNY20",
                        productName = "Tournament Master 2.0",
                        productPrice = 5.99,
                        productReleaseDate = new DateTime(2018, 2, 15)
                    }, new Product
                    {
                        productId = 7,
                        productCode = "DRAFT20",
                        productName = "Draft Manager 2.0",
                        productPrice = 5.99,
                        productReleaseDate = new DateTime(2019, 7, 15),
                    }
                );
        }
    }
}
