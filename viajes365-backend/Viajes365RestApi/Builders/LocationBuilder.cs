using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class LocationBuilder : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasIndex(u => u.LocationName).IsUnique();
            builder.HasData(
                new Location {LocationId = 1, LocationName = "Plaza de Mayo" }
                );
        }
    }
}
