<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> remotes/origin/develop
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class AttractionBuilder : IEntityTypeConfiguration<Attraction>
    {
        public void Configure(EntityTypeBuilder<Attraction> builder)
        {
<<<<<<< HEAD
            builder.HasIndex(u => u.Name).IsUnique();
        }
=======
            builder.HasIndex(a => a.Name).IsUnique();
            builder.HasData(
                new Attraction { AttractionId = 1L, Name = "Plaza de Mayo", Active = true },
            new Attraction { AttractionId = 2L, Name = "Monumento a Urquiza", Active = true },
                new Attraction { AttractionId = 3L, Name = "Parque Urquiza", Active = true },
                new Attraction { AttractionId = 4L, Name = "Mirador", Active = true }
                );
        }
                
>>>>>>> remotes/origin/develop
    }
}
