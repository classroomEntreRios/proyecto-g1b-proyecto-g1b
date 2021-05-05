using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class PhotoBuilder : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            var utcNow = DateTime.UtcNow;
            var adminId = 1;
            builder.HasIndex(a => a.Path).IsUnique();
            builder.HasData(
                new Photo { PhotoId = 1L, Name = "UserAvatar1", Summary = "Avatar Sin Foto", Description = "Imagén de Perfil", Path = "StaticFiles\\Images\\Avatars\\user-avatar1.png", Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true },
                new Photo { PhotoId = 2L, Name = "UserAvatar2", Summary = "Avatar Sin Foto", Description = "Imagén de Perfil", Path = "StaticFiles\\Images\\Avatars\\user-avatar2.png", Created = utcNow, Updated = utcNow, CreatorId = adminId, LastId = adminId, Active = true }
                );
        }
    }
}