using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class RoleBuilder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var utcNow = DateTime.UtcNow;
            var adminId = 1;
            builder.HasIndex(u => u.RoleName).IsUnique();
            builder.HasData(
                new Role { RoleId = 1L, RoleName = "Usuario", Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true },
                new Role { RoleId = 2L, RoleName = "Administrador", Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true },
                new Role { RoleId = 3L, RoleName = "Moderador", Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = false },
                new Role { RoleId = 4L, RoleName = "Anónimo", Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = false }
                );
        }
    }
}
