using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class InformationBuilder : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.HasOne<Weather>().WithOne(w => w.Information).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
