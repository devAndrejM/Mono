using Microsoft.EntityFrameworkCore.Migrations;

namespace Coreapp.Migrations
{
    public partial class Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[,]
                {
                    { 7, "A-class", 2, "A180" },
                    { 8, "A-class", 2, "A160" },
                    { 9, "C-class", 2, "C43" },
                    { 10, "C-class", 2, "C300" },
                    { 11, "GLE", 2, "GLE580" },
                    { 12, "GLE", 2, "GLE350" },
                    { 13, "GLE", 2, "GLE400" },
                    { 14, "M-Class", 2, "ML350" },
                    { 15, "M-Class", 2, "ML400" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
