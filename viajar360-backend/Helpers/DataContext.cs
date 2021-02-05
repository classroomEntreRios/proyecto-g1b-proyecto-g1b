using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Viajar360Api.Entities;
using Viajar360Api.Models;

namespace Viajar360Api.Helpers
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
            options.UseSqlServer(Configuration.GetConnectionString("Viajar360Database"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }

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

        // Specify DbSet properties etc
        protected override void OnModelCreating(ModelBuilder MB)
        {
            // Write Fluent API configurations from here
            // Property Configurations SQL Server Express 2019

            // USER
            MB.Entity<User>().Property<long>(u => u.UserId)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .UseIdentityColumn();

            MB.Entity<User>().Property<bool>(u => u.Active)
                .HasColumnType("bit")
                .HasComment("Esto se implementa para soft delete");

            MB.Entity<User>().Property<DateTime>(u => u.CreatedDate)
                .HasColumnType("datetime2")
                .HasComment("Fecha y hora de creación");

            MB.Entity<User>().Property<string>(u => u.Email)
                .HasMaxLength(250)
                .HasColumnType("nvarchar(250)");

            MB.Entity<User>().Property<string>(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            MB.Entity<User>().Property<string>(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            MB.Entity<User>().Property<byte[]>(u => u.PasswordHash)
                .HasColumnType("varbinary(max)");

            MB.Entity<User>().Property<byte[]>(u => u.PasswordSalt)
                .HasColumnType("varbinary(max)");

            MB.Entity<User>().Property<DateTime>(u => u.UpdatedDate)
                .HasColumnType("datetime2")
                .HasComment("Fecha y hora de última actualización");

            MB.Entity<User>().Property<string>(u => u.UserName)
                .HasMaxLength(15)
                .HasColumnType("nvarchar(15)");  

            MB.Entity<User>().HasKey(u => u.UserId);

            MB.Entity<User>().ToTable("Users");

            // ROLE
            
            MB.Entity<Role>()
                .Property<long>(r => r.RoleId)
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint");

            MB.Entity<Role>().Property<bool>(r => r.Active)
                .HasColumnType("bit")
                .HasComment("Esto se implementa para soft delete");

            MB.Entity<Role>().Property<DateTime>(r => r.CreatedDate)
                .HasColumnType("datetime2")
                .HasComment("Fecha y hora de creación");

            MB.Entity<Role>().Property<string>("RoleName")
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            MB.Entity<Role>().Property<int>(r => (int)r.RoleType)
                .HasColumnType("int");

            MB.Entity<Role>().Property<DateTime>(r => r.UpdatedDate)
                .HasColumnType("datetime2")
                .HasComment("Fecha y hora de última actualización");

            MB.Entity<Role>().HasKey(r => r.RoleId);

            MB.Entity<Role>().ToTable("Roles");

            MB.Entity<Role>().HasData(
                new Role { RoleId = 1L, RoleName = "Registrado", RoleType = RoleType.Registered, Active = true },
                new Role { RoleId = 2L, RoleName = "Administrador", RoleType = RoleType.Admin, Active = true },
                new Role { RoleId = 3L, RoleName = "Moderador", RoleType = RoleType.Moderator, Active = false },
                new Role { RoleId = 4L, RoleName = "Anónimo", RoleType = RoleType.Anonymous, Active = false }
                );

            // ROLEUSER

          /*  MB.Entity<RoleUser>()
              .Property<long>(r => r.RolesRoleId)
              .HasColumnType("bigint");

            MB.Entity<RoleUser>()
              .Property<long>(r => r.UsersUserId)
              .HasColumnType("bigint");

            MB.Entity<RoleUser>()
              .HasNoKey();

            MB.Entity<RoleUser>()
              .HasIndex(r => r.UsersUserId);

            MB.Entity<RoleUser>()
                .ToTable("RoleUser");

            MB.Entity<RoleUser>()
              .HasOne(r => r.RolesId)
              .WithMany()
              .HasForeignKey(r => r.RolesRoleId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();

            MB.Entity<RoleUser>()
              .HasOne(r => r.UserId)
              .WithMany()
              .HasForeignKey(r => r.UsersUserId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();*/

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