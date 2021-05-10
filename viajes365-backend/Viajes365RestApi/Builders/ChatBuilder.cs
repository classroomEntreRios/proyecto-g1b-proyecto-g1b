using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Builders
{
    public class ChatBuilder : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            var utcNow = DateTime.UtcNow;
            builder.HasIndex(t => t.Email).IsUnique();
            builder.HasMany(t => t.Chatcomments).WithOne(c => c.Chat).HasForeignKey(c => c.ChatId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(new Chat() {
                ChatId = 1L,
                Nick = "Caro",
                Email = "carolina_perez@gmail.com",
                Status = "aprobado",
                Chatcomments= null,
                CreatorId = 2L,
                LastId= 2L,
                Created= utcNow,
                Updated= utcNow,
                Active = true});
        }
    }
}
