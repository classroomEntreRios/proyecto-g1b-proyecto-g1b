﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Viajes365RestApi.Helpers;

namespace Viajes365RestApi.Migrations.SqlServerMigrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Viajes365RestApi.Entities.Attraction", b =>
                {
                    b.Property<long>("AttractionId")
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

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de última actualización");

                    b.HasKey("AttractionId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Attractions");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Location", b =>
                {
                    b.Property<long>("LocationId")
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

                    b.Property<string>("FullAddress")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<long>("LastId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del último Editor");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<byte>("Note")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de última actualización");

                    b.HasKey("LocationId");

                    b.HasIndex("LocationName")
                        .IsUnique();

                    b.ToTable("Locations");
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
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 0L,
                            LastId = 0L,
                            RoleName = "Usuario",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RoleId = 2L,
                            Active = true,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 0L,
                            LastId = 0L,
                            RoleName = "Administrador",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RoleId = 3L,
                            Active = false,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 0L,
                            LastId = 0L,
                            RoleName = "Moderador",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RoleId = 4L,
                            Active = false,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 0L,
                            LastId = 0L,
                            RoleName = "Anónimo",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Tour", b =>
                {
                    b.Property<long>("TourId")
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

                    b.Property<string>("Duration")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("LastId")
                        .HasColumnType("bigint")
                        .HasComment("UserId del último Editor");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha y hora de última actualización");

                    b.HasKey("TourId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Tour_attraction", b =>
                {
                    b.Property<long>("Tour_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Attraction_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("AttractionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TourId")
                        .HasColumnType("bigint");

                    b.Property<long>("Tour_atractionId")
                        .HasColumnType("bigint");

                    b.HasKey("Tour_Id", "Attraction_Id");

                    b.HasIndex("AttractionId");

                    b.HasIndex("TourId");

                    b.ToTable("Tour_attractions");
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

            modelBuilder.Entity("Viajes365RestApi.Entities.Attraction", b =>
                {
                    b.HasOne("Viajes365RestApi.Entities.Location", null)
                        .WithMany("Attractions")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Tour", b =>
                {
                    b.HasOne("Viajes365RestApi.Entities.Location", null)
                        .WithMany("Tours")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Tour_attraction", b =>
                {
                    b.HasOne("Viajes365RestApi.Entities.Attraction", null)
                        .WithMany("Tour_Attractions")
                        .HasForeignKey("AttractionId");

                    b.HasOne("Viajes365RestApi.Entities.Tour", null)
                        .WithMany("Tour_Attractions")
                        .HasForeignKey("TourId");
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

            modelBuilder.Entity("Viajes365RestApi.Entities.Attraction", b =>
                {
                    b.Navigation("Tour_Attractions");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Location", b =>
                {
                    b.Navigation("Attractions");

                    b.Navigation("Tours");
                });

            modelBuilder.Entity("Viajes365RestApi.Entities.Tour", b =>
                {
                    b.Navigation("Tour_Attractions");
                });
#pragma warning restore 612, 618
        }
    }
}
