using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class LocationBuilder : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            var utcNow = DateTime.UtcNow;
            var adminId = 1;
            builder.HasIndex(u => u.LocationName).IsUnique();
            builder.HasData(
                new Location { LocationId = 1, LocationName = "Sin Locación", Latitude = 0.0, Longitude = 0.0, FullAddress = "Sin datos", Note = "Por defecto", CityId = 5L, Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true }
                );
        }
    }
}
