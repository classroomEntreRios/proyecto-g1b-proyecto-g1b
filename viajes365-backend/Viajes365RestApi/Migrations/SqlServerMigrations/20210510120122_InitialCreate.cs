﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viajes365RestApi.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    InformationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Humidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pressure = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.InformationId);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    LocalityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url_weather_forecast_15_days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url_hourly_forecast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url_country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.LocalityId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Chatcomments",
                columns: table => new
                {
                    ChatcommentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsResponse = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatcomments", x => x.ChatcommentId);
                    table.ForeignKey(
                        name: "FK_Chatcomments_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Copyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Use = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformationId = table.Column<long>(type: "bigint", nullable: false),
                    Web = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_Weathers_Informations_InformationId",
                        column: x => x.InformationId,
                        principalTable: "Informations",
                        principalColumn: "InformationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weathers_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "LocalityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    AttractionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.AttractionId);
                    table.ForeignKey(
                        name: "FK_Attractions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                    table.ForeignKey(
                        name: "FK_Tours_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    DayId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature_max = table.Column<int>(type: "int", nullable: false),
                    Temperature_min = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    Wind = table.Column<int>(type: "int", nullable: false),
                    Wind_direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon_wind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sunrise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sunset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moonrise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moonset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moon_phases_icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.DayId);
                    table.ForeignKey(
                        name: "FK_Day_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "WeatherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hour",
                columns: table => new
                {
                    HourId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hour_data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wind = table.Column<int>(type: "int", nullable: false),
                    Wind_direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon_wind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hour", x => x.HourId);
                    table.ForeignKey(
                        name: "FK_Hour_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "WeatherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttractionTour",
                columns: table => new
                {
                    AttractionsAttractionId = table.Column<long>(type: "bigint", nullable: false),
                    ToursTourId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionTour", x => new { x.AttractionsAttractionId, x.ToursTourId });
                    table.ForeignKey(
                        name: "FK_AttractionTour_Attractions_AttractionsAttractionId",
                        column: x => x.AttractionsAttractionId,
                        principalTable: "Attractions",
                        principalColumn: "AttractionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttractionTour_Tours_ToursTourId",
                        column: x => x.ToursTourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AttractionId = table.Column<long>(type: "bigint", nullable: true),
                    TourId = table.Column<long>(type: "bigint", nullable: true),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "AttractionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PhotoId = table.Column<long>(type: "bigint", nullable: false),
                    TermsAndConditionsChecked = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pinned = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TopicId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "Active", "Created", "CreatorId", "Email", "LastId", "Nick", "Status", "Updated" },
                values: new object[] { 1L, true, new DateTime(2021, 5, 10, 12, 1, 21, 545, DateTimeKind.Utc).AddTicks(9878), 2L, "carolina_perez@gmail.com", 2L, "Caro", "aprobado", new DateTime(2021, 5, 10, 12, 1, 21, 545, DateTimeKind.Utc).AddTicks(9878) });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Active", "Code", "Created", "CreatorId", "LastId", "Name", "Updated" },
                values: new object[,]
                {
                    { 1L, true, 43437, new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437), 1L, 1L, "Colón", new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437) },
                    { 2L, true, 42923, new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437), 1L, 1L, "Concordia", new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437) },
                    { 3L, true, 42987, new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437), 1L, 1L, "Federación", new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437) },
                    { 4L, true, 43034, new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437), 1L, 1L, "Gualeguaychú", new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437) },
                    { 5L, true, 43214, new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437), 1L, 1L, "Paraná", new DateTime(2021, 5, 10, 12, 1, 21, 525, DateTimeKind.Utc).AddTicks(437) }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "Active", "AttractionId", "Created", "CreatorId", "Description", "LastId", "Name", "Path", "Summary", "TourId", "Updated" },
                values: new object[,]
                {
                    { 1L, true, null, new DateTime(2021, 5, 10, 12, 1, 21, 515, DateTimeKind.Utc).AddTicks(2659), 1L, "Imagén de Perfil", 1L, "UserAvatar1", "StaticFiles\\Images\\Avatars\\user-avatar1.png", "Avatar Sin Foto", null, new DateTime(2021, 5, 10, 12, 1, 21, 515, DateTimeKind.Utc).AddTicks(2659) },
                    { 2L, true, null, new DateTime(2021, 5, 10, 12, 1, 21, 515, DateTimeKind.Utc).AddTicks(2659), 1L, "Imagén de Perfil", 1L, "UserAvatar2", "StaticFiles\\Images\\Avatars\\user-avatar2.png", "Avatar Sin Foto", null, new DateTime(2021, 5, 10, 12, 1, 21, 515, DateTimeKind.Utc).AddTicks(2659) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Active", "Created", "CreatorId", "LastId", "RoleName", "Updated" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221), 1L, 1L, "Usuario", new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221) },
                    { 2L, true, new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221), 1L, 1L, "Administrador", new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221) },
                    { 3L, false, new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221), 1L, 1L, "Moderador", new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221) },
                    { 4L, false, new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221), 1L, 1L, "Anónimo", new DateTime(2021, 5, 10, 12, 1, 21, 541, DateTimeKind.Utc).AddTicks(7221) }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Active", "CityId", "Created", "CreatorId", "FullAddress", "LastId", "Latitude", "LocationName", "Longitude", "Note", "Updated" },
                values: new object[] { 1L, true, 5L, new DateTime(2021, 5, 10, 12, 1, 21, 506, DateTimeKind.Utc).AddTicks(3911), 1L, "Sin datos", 1L, 0.0, "Sin Locación", 0.0, "Por defecto", new DateTime(2021, 5, 10, 12, 1, 21, 506, DateTimeKind.Utc).AddTicks(3911) });

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_LocationId",
                table: "Attractions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_Name",
                table: "Attractions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttractionTour_ToursTourId",
                table: "AttractionTour",
                column: "ToursTourId");

            migrationBuilder.CreateIndex(
                name: "IX_Chatcomments_ChatId",
                table: "Chatcomments",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Email",
                table: "Chats",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TopicId",
                table: "Comments",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_WeatherId",
                table: "Day",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Hour_WeatherId",
                table: "Hour",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationName",
                table: "Locations",
                column: "LocationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AttractionId",
                table: "Photos",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_Path",
                table: "Photos",
                column: "Path",
                unique: true,
                filter: "[Path] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TourId",
                table: "Photos",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_Name",
                table: "Topics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_LocationId",
                table: "Tours",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Name",
                table: "Tours",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhotoId",
                table: "Users",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_InformationId",
                table: "Weathers",
                column: "InformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_LocalityId",
                table: "Weathers",
                column: "LocalityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionTour");

            migrationBuilder.DropTable(
                name: "Chatcomments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Hour");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
