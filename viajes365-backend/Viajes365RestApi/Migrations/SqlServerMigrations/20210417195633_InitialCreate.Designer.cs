﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Viajes365RestApi.Helpers;

namespace Viajes365RestApi.Migrations.SqlServerMigrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210417195633_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Viajes365RestApi.Entities.City", b =>
                {
                    b.Property<long>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasComment("Esto se implementa para soft delete");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de creación");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del creador");

                    b.Property<long>("LastId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del último Editor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de última actualización");

                    b.HasKey("CityId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1L,
                            Active = true,
                            Code = 43437,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447),
                            CreatorId = 1L,
                            LastId = 1L,
                            Name = "Colón",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447)
                        },
                        new
                        {
                            CityId = 2L,
                            Active = true,
                            Code = 42923,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447),
                            CreatorId = 1L,
                            LastId = 1L,
                            Name = "Concordia",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447)
                        },
                        new
                        {
                            CityId = 3L,
                            Active = true,
                            Code = 42987,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447),
                            CreatorId = 1L,
                            LastId = 1L,
                            Name = "Federación",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447)
                        },
                        new
                        {
                            CityId = 4L,
                            Active = true,
                            Code = 43034,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447),
                            CreatorId = 1L,
                            LastId = 1L,
                            Name = "Gualeguaychú",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447)
                        },
                        new
                        {
                            CityId = 5L,
                            Active = true,
                            Code = 43214,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447),
                            CreatorId = 1L,
                            LastId = 1L,
                            Name = "Paraná",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447)
                        });
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Day", b =>
                {
                    b.Property<long>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon_wind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moon_phases_icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moonrise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moonset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunrise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Temperature_max")
                        .HasColumnType("int");

                    b.Property<int>("Temperature_min")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WeatherId")
                        .HasColumnType("bigint");

                    b.Property<int>("Wind")
                        .HasColumnType("int");

                    b.Property<string>("Wind_direction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DayId");

                    b.HasIndex("WeatherId");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Hour", b =>
                {
                    b.Property<long>("HourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hour_data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon_wind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pressure")
                        .HasColumnType("int");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WeatherId")
                        .HasColumnType("bigint");

                    b.Property<int>("Wind")
                        .HasColumnType("int");

                    b.Property<string>("Wind_direction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HourId");

                    b.HasIndex("WeatherId");

                    b.ToTable("Hour");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Information", b =>
                {
                    b.Property<long>("InformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Humidity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wind")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InformationId");

                    b.ToTable("Informations");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Locality", b =>
                {
                    b.Property<long>("LocalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url_country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url_hourly_forecast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url_weather_forecast_15_days")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocalityId");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasComment("Esto se implementa para soft delete");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de creación");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del creador");

                    b.Property<long>("LastId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del último Editor");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de última actualización");

                    b.HasKey("RoleId");

                    b.HasIndex("RoleName")
                        .IsUnique()
                        .HasFilter("[RoleName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1L,
                            Active = true,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793),
                            CreatorId = 1L,
                            LastId = 1L,
                            RoleName = "Usuario",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793)
                        },
                        new
                        {
                            RoleId = 2L,
                            Active = true,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793),
                            CreatorId = 1L,
                            LastId = 1L,
                            RoleName = "Administrador",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793)
                        },
                        new
                        {
                            RoleId = 3L,
                            Active = false,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793),
                            CreatorId = 1L,
                            LastId = 1L,
                            RoleName = "Moderador",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793)
                        },
                        new
                        {
                            RoleId = 4L,
                            Active = false,
                            Created = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793),
                            CreatorId = 1L,
                            LastId = 1L,
                            RoleName = "Anónimo",
                            Updated = new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793)
                        });
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasComment("Esto se implementa para soft delete");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de creación");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del creador");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("EmailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("LastId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del último Editor");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("TermsAndConditionsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de última actualización");

                    b.Property<string>("UserName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Weather", b =>
                {
                    b.Property<long>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasComment("Esto se implementa para soft delete");

                    b.Property<string>("Copyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de creación");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del creador");

                    b.Property<long>("InformationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del último Editor");

                    b.Property<long>("LocalityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de última actualización");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Web")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeatherId");

                    b.HasIndex("InformationId")
                        .IsUnique();

                    b.HasIndex("LocalityId")
                        .IsUnique();

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Day", b =>
                {
                    b.HasOne("Viajes365RestApi.Entities.Weather", null)
                        .WithMany("Days")
                        .HasForeignKey("WeatherId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Hour", b =>
                {
                    b.HasOne("Viajes365RestApi.Entities.Weather", null)
                        .WithMany("Hours")
                        .HasForeignKey("WeatherId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.User", b =>
                {
                    b.HasOne("Viajes365RestApi.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Weather", b =>
                {
                    b.HasOne("Viajes365RestApi.Entities.Information", "Information")
                        .WithOne()
                        .HasForeignKey("Viajes365RestApi.Entities.Weather", "InformationId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Viajes365RestApi.Entities.Locality", "Locality")
                        .WithOne()
                        .HasForeignKey("Viajes365RestApi.Entities.Weather", "LocalityId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Information");

                    b.Navigation("Locality");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Weather", b =>
                {
                    b.Navigation("Days");

                    b.Navigation("Hours");
                });
#pragma warning restore 612, 618
        }
    }
}
