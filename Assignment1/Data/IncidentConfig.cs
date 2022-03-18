using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    internal class IncidentConfig : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasKey(incident => incident.incidentId);

            entity.HasData(
                    new Incident
                    {
                        incidentId = 1,
                        incidentCustomerId = 5,
                        incidentProductId = 4,
                        incidentTitle = "Could not install",
                        incidentDescription = "Program failed to install with error code 502",
                        incidentTechnicianId = 1, // needed for editing incident page
                        incidentDateOpened = new DateTime(2020, 1, 8),
                        incidentDateClosed = new DateTime(),
                    },
                    new Incident
                    {
                        incidentId = 2,
                        incidentTitle = "Could not install",
                        incidentCustomerId = 3,
                        incidentProductId = 1,
                        incidentDateOpened = new DateTime(2020, 1, 8),
                        incidentDateClosed = new DateTime(),
                        incidentDescription = "Program failed to install with error code 502",
                        incidentTechnicianId = 2,
                    },
                    new Incident
                    {
                        incidentId = 3,
                        incidentTitle = "Error importing data",
                        incidentCustomerId = 2,
                        incidentProductId = 3,
                        incidentDateOpened = new DateTime(2020, 1, 9),
                        incidentDateClosed = new DateTime(),
                        incidentDescription = "Program fails with error code 511, unable to locate database",
                        incidentTechnicianId = 3,
                    },
                    new Incident
                    {
                        incidentId = 4,
                        incidentTitle = "Error launching program",
                        incidentCustomerId = 5,
                        incidentProductId = 2,
                        incidentDateOpened = new DateTime(2020, 1, 10),
                        incidentDateClosed = new DateTime(),
                        incidentDescription = "Program fails with error code 510, unable to open database",
                        incidentTechnicianId = 4,
                    }
                );
        }
    }
}
