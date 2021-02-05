using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Viajar360Api.Helpers
{
    public class SqliteDataContext : DataContext
    {
        public SqliteDataContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("Viajar360Database"));
        }
    }
}