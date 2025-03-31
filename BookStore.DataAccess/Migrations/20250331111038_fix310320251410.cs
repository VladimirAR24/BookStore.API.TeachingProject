using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fix310320251410 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissionEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity",
                columns: new[] { "PermissionId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_RoleId",
                table: "RolePermissionEntity",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissionEntity",
                column: "PermissionId");
        }
    }
}
