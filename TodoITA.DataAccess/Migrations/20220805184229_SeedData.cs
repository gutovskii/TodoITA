using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoITA.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoCategories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "TodoCategories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Work" });

            migrationBuilder.InsertData(
                table: "TodoCategories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Gym" });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Description", "IsDone", "Text", "TodoCategoryId" },
                values: new object[,]
                {
                    { 1, "My part but not the neighbour", false, "Room Cleaning", 1 },
                    { 2, "Boil eggs and cook the meat", true, "To Cook", 1 },
                    { 3, "With Mr.Proper", false, "Wash the Dishes", 1 },
                    { 4, "ASP.NET Core 3.1, MS SQL", true, "Make Backend", 2 },
                    { 5, "React, Redux", false, "Make Frontend", 2 },
                    { 6, "NUnit", false, "Make Tests", 2 },
                    { 7, "Squats, Lunges, Extension, Caviar", true, "Legs", 3 },
                    { 8, "Front, Middle, Back", true, "Shoulders", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TodoCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
