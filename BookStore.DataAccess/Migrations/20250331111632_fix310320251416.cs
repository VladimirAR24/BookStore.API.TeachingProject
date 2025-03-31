using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fix310320251416 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissionEntity_RoleId",
                table: "RolePermissionEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.InsertData(
                table: "RolePermissionEntity",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissionEntity",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissionEntity");

            migrationBuilder.DeleteData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity",
                columns: new[] { "PermissionId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_RoleId",
                table: "RolePermissionEntity",
                column: "RoleId");
        }
    }
}
