using Microsoft.EntityFrameworkCore.Migrations;

namespace Coreapp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[,]
                {
                    { 7, "Renault", "Renault" },
                    { 8, "Škoda", "Škoda Auto" },
                    { 9, "Audi", "Audi AG" },
                    { 10, "VW", "Volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[,]
                {
                    { 16, "i8", 1, "i8" },
                    { 17, "Series-3", 1, "316" },
                    { 18, "Focus", 3, "Focus" },
                    { 19, "Ka", 3, "Ka" },
                    { 20, "ix35", 4, "ix35" },
                    { 21, "Kona", 4, "Kona" },
                    { 22, "3", 5, "323" },
                    { 23, "6", 5, "6" },
                    { 24, "Cayenne", 6, "Cayenne" },
                    { 25, "911", 6, "911" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[,]
                {
                    { 26, "Captur", 7, "Captur" },
                    { 27, "Scenic", 7, "Scenic" },
                    { 28, "Superb", 8, "Superb" },
                    { 29, "Octavia", 8, "Octavia" },
                    { 30, "A3", 9, "A3" },
                    { 31, "A4", 9, "A4" },
                    { 32, "Passsat", 10, "Passat" },
                    { 33, "Arteon", 10, "Arteon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleMake",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
