using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    internal class RegistrationConfig : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> entity)
        {
            entity.HasKey(registration => new { registration.customerId, registration.productId});

            entity
                .HasOne(registration => registration.customer)
                .WithMany(customer => customer.registrations)
                .HasForeignKey(registration => registration.customerId);

            entity
                .HasOne(registration => registration.product)
                .WithMany(product => product.registrations)
                .HasForeignKey(registration => registration.productId);

            entity.HasData(
                    new Registration
                    {
                        customerId = 2,
                        productId = 2
                    },
                    new Registration
                    {
                        customerId = 2,
                        productId = 4
                    }
                );
        }
    }
}
