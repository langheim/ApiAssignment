using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Assignment_3.Migrations
{
    public partial class initialDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FranchiseId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "No franchise", "Franchise not set" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A curious Hobbit, Bilbo Baggins, journeys to the Lonely Mountain with a vigorous group.", "The Hobbit" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A shy young hobbit named Frodo Baggins inherits a simple gold ring.", "The Lord of the Rings" });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, "American epic space opera multimedia franchise created by George Lucas.", "Star Wars" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "FranchiseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "FranchiseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "FranchiseId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                column: "FranchiseId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                column: "FranchiseId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6,
                column: "FranchiseId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "FranchiseId",
                table: "Movie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A curious Hobbit, Bilbo Baggins, journeys to the Lonely Mountain with a vigorous group.", "The Hobbit" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A shy young hobbit named Frodo Baggins inherits a simple gold ring.", "The Lord of the Rings" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "American epic space opera multimedia franchise created by George Lucas.", "Star Wars" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "FranchiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "FranchiseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "FranchiseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                column: "FranchiseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                column: "FranchiseId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6,
                column: "FranchiseId",
                value: 3);
        }
    }
}
