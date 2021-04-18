using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class PhotoBuilder : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasIndex(a => a.Path).IsUnique();
            builder.HasData(
                new Photo { PhotoId = 1L, Name = "Plaza de Mayo", Description ="esta es una foto de tal", Active = true },
            new Photo { PhotoId = 2L, Name = "Monumento a Urquiza", Description ="esta es una foto de tal",Active = true },
                new Photo { PhotoId = 3L, Name = "Parque Urquiza", Description ="esta es una foto de tal", Active = true },
                new Photo { PhotoId = 4L, Name = "Mirador", Description ="esta es una foto de tal", Active = true }
                );
        }
        
        

                
    }
}