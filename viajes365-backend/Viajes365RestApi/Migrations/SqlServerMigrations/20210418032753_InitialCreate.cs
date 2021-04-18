using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viajes365RestApi.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Note = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del creador"),
                    LastId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId del último Editor"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de creación"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha y hora de última actualización"),
                    Active = table.Column<bool>(type: "bit", nullable: false, comment: "Esto se implementa para soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "Tour_attractions",
                columns: table => new
                {
                    Tour_Id = table.Column<long>(type: "bigint", nullable: false),
                    Attraction_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tour_atractionId = table.Column<long>(type: "bigint", nullable: false),
                    AttractionId = table.Column<long>(type: "bigint", nullable: true),
                    TourId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_attractions", x => new { x.Tour_Id, x.Attraction_Id });
                    table.ForeignKey(
                        name: "FK_Tour_attractions_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "AttractionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tour_attractions_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Active", "Created", "CreatorId", "LastId", "RoleName", "Updated" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, 0L, "Usuario", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, 0L, "Administrador", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, 0L, "Moderador", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, 0L, "Anónimo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
                name: "IX_Locations_LocationName",
                table: "Locations",
                column: "LocationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_attractions_AttractionId",
                table: "Tour_attractions",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_attractions_TourId",
                table: "Tour_attractions",
                column: "TourId");

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
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tour_attractions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
