using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // conectar al sql server express
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // para las entidades que heredan de BaseModel,
                // les ponemos fechas de creacion y actualizacion
                if (entry.Entity is BaseModel trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // poner fecha de ahora a UpdatedDate
                            trackable.UpdatedDate = utcNow;

                            // marca la propiedad como no tocar
                            // no actualizar la fecha de creacion en una actualizacion
                            entry.Property("CreatedDate").IsModified = false;
                            break;

                        case EntityState.Added:
                            // estamos creando fijamos ambos valores a la fecha de ahora
                            trackable.CreatedDate = utcNow;
                            trackable.UpdatedDate = utcNow;
                            break;
                    }
                }
            }
        }
    }
}