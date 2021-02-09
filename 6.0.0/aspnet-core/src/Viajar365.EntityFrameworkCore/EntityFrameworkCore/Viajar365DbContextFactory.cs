using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Viajar365.Configuration;
using Viajar365.Web;

namespace Viajar365.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Viajar365DbContextFactory : IDesignTimeDbContextFactory<Viajar365DbContext>
    {
        public Viajar365DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Viajar365DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Viajar365DbContextConfigurer.Configure(builder, configuration.GetConnectionString(Viajar365Consts.ConnectionStringName));

            return new Viajar365DbContext(builder.Options);
        }
    }
}
