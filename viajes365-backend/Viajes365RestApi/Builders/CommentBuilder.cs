using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class CommentBuilder : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // builder.HasOne<Topic>().WithMany(t => t.Comments).HasForeignKey(c => c.TopicId).OnDelete(DeleteBehavior.ClientCascade);
            // builder.HasOne<User>().WithMany(t => t.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
