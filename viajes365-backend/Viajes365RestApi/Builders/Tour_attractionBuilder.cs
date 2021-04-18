using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class Tour_attractionBuilder : IEntityTypeConfiguration<Tour_attraction>
    {
        public void Configure(EntityTypeBuilder<Tour_attraction> builder)
        {
            //builder.HasIndex(u => u.Name).IsUnique();

            builder.HasKey(ta => new { ta.Tour_Id, ta.Attraction_Id });

            //builder.HasOne<Tour>(to => to.Tour)
            //       .WithMany(ta => ta.Tour_Attractions)
            //       .HasForeignKey(to => to.Tour_Id);

            //builder.HasOne<Attraction>(at => at.Attraction)
            //       .WithMany(ta => ta.Tour_Attractions)
            //       .HasForeignKey(at => at.Tour_Id);


            //builder.HasIndex(u => u.Tour_atractionId).IsUnique();

        }
    }
}
