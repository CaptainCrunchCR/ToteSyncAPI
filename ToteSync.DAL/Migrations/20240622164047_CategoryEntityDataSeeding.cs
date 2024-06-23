using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToteSync.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoryEntityDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "tote",
                table: "categories",
                columns: new[] { "category_id", "category_description", "category_name", "category_user_id" },
                values: new object[,]
                {
                    { 1, null, "Verduras", 1 },
                    { 2, null, "Frutas", 1 },
                    { 3, null, "Carnes", 1 },
                    { 4, null, "Lácteos", 1 },
                    { 5, null, "Granos", 1 },
                    { 6, null, "Bebidas", 2 },
                    { 7, null, "Panadería", 2 },
                    { 8, null, "Pescados", 2 },
                    { 9, null, "Aceites", 2 },
                    { 10, null, "Snacks", 2 },
                    { 11, null, "Condimentos", 3 },
                    { 12, null, "Cereales", 3 },
                    { 13, null, "Dulces", 3 },
                    { 14, null, "Helados", 3 },
                    { 15, null, "Pastas", 3 },
                    { 16, null, "Legumbres", 4 },
                    { 17, null, "Especias", 4 },
                    { 18, null, "Bebidas alcohólicas", 4 },
                    { 19, null, "Conservas", 4 },
                    { 20, null, "Salsas", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 20);
        }
    }
}
