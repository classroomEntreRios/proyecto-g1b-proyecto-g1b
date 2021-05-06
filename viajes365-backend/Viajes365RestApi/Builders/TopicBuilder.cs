using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class TopicBuilder : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasIndex(t => t.Name).IsUnique();
            builder.HasMany(t => t.Comments).WithOne(c => c.Topic).HasForeignKey(c => c.TopicId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.User).WithMany(u => u.Topics).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    } 
}

