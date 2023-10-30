using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 662, DateTimeKind.Local).AddTicks(5933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 594, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 654, DateTimeKind.Local).AddTicks(8205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 586, DateTimeKind.Local).AddTicks(9966));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 662, DateTimeKind.Local).AddTicks(7394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 594, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 656, DateTimeKind.Local).AddTicks(2483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 588, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 658, DateTimeKind.Local).AddTicks(2233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 590, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 652, DateTimeKind.Local).AddTicks(2318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 584, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 653, DateTimeKind.Local).AddTicks(5320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 585, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionsName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_PermissionsId_Permissions", x => x.PermissionsId);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_RolId_Rol", x => x.RolId);
                    table.ForeignKey(
                        name: "Fk_EmployeeId_Rol",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionsRols",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsRol_PermissionsRol", x => new { x.PermissionsId, x.RolId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "Fk_PermissionsId_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_RolId_PermissionsId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsRols_RolId",
                table: "PermissionsRols",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Rols_EmployeeId",
                table: "Rols",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionsRols");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 594, DateTimeKind.Local).AddTicks(7536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 662, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 586, DateTimeKind.Local).AddTicks(9966),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 654, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 594, DateTimeKind.Local).AddTicks(9394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 662, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 588, DateTimeKind.Local).AddTicks(3488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 656, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 590, DateTimeKind.Local).AddTicks(2353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 658, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 584, DateTimeKind.Local).AddTicks(9141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 652, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Time",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 7, 59, 45, 585, DateTimeKind.Local).AddTicks(9603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 28, 16, 1, 33, 653, DateTimeKind.Local).AddTicks(5320));
        }
    }
}
