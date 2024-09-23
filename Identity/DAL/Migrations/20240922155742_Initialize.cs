using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RoleGrupId = table.Column<int>(type: "integer", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: true),
                    OfficePhone = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "text", nullable: true),
                    UserNameConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    UserState = table.Column<int>(type: "integer", nullable: false),
                    RefresToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpire = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ProfileUrl = table.Column<string>(type: "text", nullable: true),
                    SecurityKeyExpiryDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    SecurityKey = table.Column<Guid>(type: "uuid", nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "RoleGrupId", "RoleName" },
                values: new object[] { "3188a971-25cb-4d5e-b317-81251b78012b", 1, "developer" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "Email", "MobilePhone", "Name", "OfficePhone", "Password", "ProfileImageUrl", "ProfileUrl", "RefresToken", "RefreshTokenExpire", "SecurityKey", "SecurityKeyExpiryDate", "SurName", "Unit", "UserName", "UserNameConfirmed", "UserState" },
                values: new object[,]
                {
                    { "6f01392c-45b1-4dbf-9457-74a107fe6ada", "jane.smith@example.com", "+1987654321", "Jane", "+1123456789", "Qns/cVv2lW92XVEdx2z/Dv7YRrDpKqvX7Fgc7tbqDQw=", "https://example.com/profiles/jane.jpg", "https://example.com/jane", "another-random-token", new DateTimeOffset(new DateTime(2024, 9, 27, 18, 57, 42, 383, DateTimeKind.Unspecified).AddTicks(4390), new TimeSpan(0, 3, 0, 0, 0)), new Guid("132a5a02-30ec-4857-9e9a-38a78231c604"), new DateTimeOffset(new DateTime(2024, 11, 22, 18, 57, 42, 383, DateTimeKind.Unspecified).AddTicks(4400), new TimeSpan(0, 3, 0, 0, 0)), "Smith", "HR Department", "js", false, 0 },
                    { "b77b129b-884f-49b4-bb5b-6237fe702246", "john.doe@example.com", "+1234567890", "John", "+0987654321", "Qns/cVv2lW92XVEdx2z/Dv7YRrDpKqvX7Fgc7tbqDQw=", "https://example.com/profiles/john.jpg", "https://example.com/john", "some-random-token", new DateTimeOffset(new DateTime(2024, 9, 29, 18, 57, 42, 379, DateTimeKind.Unspecified).AddTicks(8890), new TimeSpan(0, 3, 0, 0, 0)), new Guid("0a6414ca-0b43-49b6-b982-d91da5500bbf"), new DateTimeOffset(new DateTime(2024, 10, 22, 18, 57, 42, 379, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 3, 0, 0, 0)), "Doe", "IT Department", "jd", true, 0 }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, "3188a971-25cb-4d5e-b317-81251b78012b", "b77b129b-884f-49b4-bb5b-6237fe702246" },
                    { 2, "3188a971-25cb-4d5e-b317-81251b78012b", "6f01392c-45b1-4dbf-9457-74a107fe6ada" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "Identity",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");
        }
    }
}
