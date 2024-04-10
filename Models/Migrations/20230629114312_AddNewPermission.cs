using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    public partial class AddNewPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "canManageCassetts" });

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 11, 43, 12, 217, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 2,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 11, 43, 12, 217, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 3,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 11, 43, 12, 217, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 4,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 11, 43, 12, 217, DateTimeKind.Utc).AddTicks(6081));

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 10, 44, 3, 95, DateTimeKind.Utc).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 2,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 10, 44, 3, 95, DateTimeKind.Utc).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 3,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 10, 44, 3, 95, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "UserCassettes",
                keyColumn: "Id",
                keyValue: 4,
                column: "TakeDate",
                value: new DateTime(2023, 6, 29, 10, 44, 3, 95, DateTimeKind.Utc).AddTicks(3444));
        }
    }
}
