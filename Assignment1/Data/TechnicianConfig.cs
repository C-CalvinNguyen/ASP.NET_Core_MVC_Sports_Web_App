using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    internal class TechnicianConfig : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasKey(technician => technician.technicianId);

            entity.HasData(
                    new Technician
                    {
                        technicianId = 1,
                        technicianFullName = "Alison Diaz",
                        technicianEmail = "alison@sportsprosoftware.com",
                        technicianPhone = "800-555-0443",
                    },
                    new Technician
                    {
                        technicianId = 2,
                        technicianFullName = "Andrew Wilson",
                        technicianEmail = "awilson@sportsprosoftware.com",
                        technicianPhone = "800-555-0449",
                    },
                    new Technician
                    {
                        technicianId = 3,
                        technicianFullName = "Gina Fiori",
                        technicianEmail = "gfiori@sportsprosoftware.com",
                        technicianPhone = "800-555-0459",
                    },
                    new Technician
                    {
                        technicianId = 4,
                        technicianFullName = "Gunter Wendt",
                        technicianEmail = "gunter@sportsprosoftware.com",
                        technicianPhone = "800-555-0400",
                    },
                    new Technician
                    {
                        technicianId = 5,
                        technicianFullName = "Jason Lee",
                        technicianEmail = "jason@sportsprosoftware.com",
                        technicianPhone = "800-555-0444",
                    }
                );
        }
    }
}
