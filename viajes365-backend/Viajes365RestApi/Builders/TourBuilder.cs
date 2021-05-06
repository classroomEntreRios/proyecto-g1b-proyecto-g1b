using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class TourBuilder : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();
            builder.HasMany(t => t.Attractions).WithMany(a => a.Tours);
        }
    }
}
