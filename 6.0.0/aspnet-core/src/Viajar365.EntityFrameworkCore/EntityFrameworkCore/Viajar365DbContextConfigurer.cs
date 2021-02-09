using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Viajar365.EntityFrameworkCore
{
    public static class Viajar365DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Viajar365DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Viajar365DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
