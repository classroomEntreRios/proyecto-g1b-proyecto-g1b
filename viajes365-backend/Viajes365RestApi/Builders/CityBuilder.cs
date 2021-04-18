using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class CityBuilder : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            var utcNow = DateTime.UtcNow;
            var adminId = 1;
            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasData(
                new City { CityId = 1L, Name = "Colón", Code = 43437, Created = utcNow,Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true },
                new City { CityId = 2L, Name = "Concordia", Code = 42923, Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true },
                new City { CityId = 3L, Name = "Federación", Code = 42987, Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true },
                new City { CityId = 4L, Name = "Gualeguaychú", Code = 43034, Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true },
                new City { CityId = 5L, Name = "Paraná", Code = 43214, Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true }
                );
        }
       
    }
}
