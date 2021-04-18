using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class DayBuilder : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.HasOne<Weather>().WithMany(w => w.Days).OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}
