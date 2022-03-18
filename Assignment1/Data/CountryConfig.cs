using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    internal class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasKey(country => country.countryId);

            entity.HasData(
                    new Country
                    {
                        countryId = 1,
                        countryName = "Canada"
                    },
                    new Country
                    {
                        countryId = 2,
                        countryName = "United States of America"
                    },
                    new Country
                    {
                        countryId = 3,
                        countryName = "United Kingdom"
                    },
                    new Country
                    {
                        countryId = 4,
                        countryName = "France"
                    },
                    new Country
                    {
                        countryId = 5,
                        countryName = "Mexico"
                    }
                );
        }
    }
}
