using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class ChatBuilder : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasIndex(t => t.Email).IsUnique();
            builder.HasMany(t => t.Chatcomments).WithOne(c => c.Chat).HasForeignKey(c => c.ChatId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
