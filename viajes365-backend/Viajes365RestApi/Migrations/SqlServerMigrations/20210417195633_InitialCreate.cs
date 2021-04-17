using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viajes365RestApi.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Active", "Code", "Created", "CreatorId", "LastId", "Name", "Updated" },
                values: new object[,]
                {
                    { 1L, true, 43437, new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447), 1L, 1L, "Colón", new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447) },
                    { 2L, true, 42923, new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447), 1L, 1L, "Concordia", new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447) },
                    { 3L, true, 42987, new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447), 1L, 1L, "Federación", new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447) },
                    { 4L, true, 43034, new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447), 1L, 1L, "Gualeguaychú", new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447) },
                    { 5L, true, 43214, new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447), 1L, 1L, "Paraná", new DateTime(2021, 4, 17, 19, 56, 32, 369, DateTimeKind.Utc).AddTicks(1447) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Active", "Created", "CreatorId", "LastId", "RoleName", "Updated" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793), 1L, 1L, "Usuario", new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793) },
                    { 2L, true, new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793), 1L, 1L, "Administrador", new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793) },
                    { 3L, false, new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793), 1L, 1L, "Moderador", new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793) },
                    { 4L, false, new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793), 1L, 1L, "Anónimo", new DateTime(2021, 4, 17, 19, 56, 32, 364, DateTimeKind.Utc).AddTicks(9793) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Day_WeatherId",
                table: "Day",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Hour_WeatherId",
                table: "Hour",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

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
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Hour");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "Localities");
        }
    }
}
