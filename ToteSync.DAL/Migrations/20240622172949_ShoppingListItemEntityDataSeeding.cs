using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToteSync.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListItemEntityDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "tote",
                table: "shopping_list_items",
                columns: new[] { "shopping_list_item_id", "shopping_list_item_item_id", "shopping_list_item_notes", "shopping_list_item_quantity", "shopping_list_item_shopping_list_id" },
                values: new object[,]
                {
                    { 1, 1, "Zanahorias frescas", 1, 1 },
                    { 2, 2, "Tomates maduros", 2, 1 },
                    { 3, 3, "Lechuga romana", 1, 1 },
                    { 4, 6, "Manzanas rojas", 1, 2 },
                    { 5, 7, "Plátanos maduros", 3, 2 },
                    { 6, 8, "Uvas verdes", 1, 2 },
                    { 7, 11, "Pechugas de pollo", 2, 3 },
                    { 8, 12, "Carne de res molida", 1, 3 },
                    { 9, 13, "Chuletas de cerdo", 2, 3 },
                    { 10, 16, "Queso cheddar", 1, 4 },
                    { 11, 17, "Leche descremada", 2, 4 },
                    { 12, 18, "Yogur natural", 1, 4 },
                    { 13, 21, "Arroz integral", 2, 5 },
                    { 14, 22, "Frijoles negros", 1, 5 },
                    { 15, 23, "Maíz dulce", 1, 5 },
                    { 16, 26, "Botellas de agua", 6, 6 },
                    { 17, 27, "Jugos de naranja", 4, 6 },
                    { 18, 28, "Refrescos variados", 3, 6 },
                    { 19, 31, "Pan integral", 1, 7 },
                    { 20, 32, "Pan blanco", 1, 7 },
                    { 21, 33, "Pan de centeno", 1, 7 },
                    { 22, 36, "Filetes de salmón", 2, 8 },
                    { 23, 37, "Latas de atún", 1, 8 },
                    { 24, 38, "Filetes de trucha", 1, 8 },
                    { 25, 41, "Aceite de oliva extra virgen", 2, 9 },
                    { 26, 42, "Aceite de girasol", 1, 9 },
                    { 27, 43, "Aceite de coco orgánico", 1, 9 },
                    { 28, 46, "Bolsas de papas fritas", 2, 10 },
                    { 29, 47, "Galletas de chocolate", 1, 10 },
                    { 30, 48, "Palomitas de maíz", 3, 10 },
                    { 31, 51, "Sal marina", 1, 11 },
                    { 32, 52, "Pimienta negra", 1, 11 },
                    { 33, 53, "Orégano seco", 1, 11 },
                    { 34, 56, "Avena integral", 2, 12 },
                    { 35, 57, "Trigo sarraceno", 1, 12 },
                    { 36, 58, "Harina de maíz", 1, 12 },
                    { 37, 61, "Barras de chocolate", 3, 13 },
                    { 38, 62, "Caramelos surtidos", 2, 13 },
                    { 39, 63, "Chicles de menta", 1, 13 },
                    { 40, 66, "Helado de vainilla", 2, 14 },
                    { 41, 67, "Helado de chocolate", 1, 14 },
                    { 42, 68, "Helado de fresa", 1, 14 },
                    { 43, 71, "Paquetes de espagueti", 2, 15 },
                    { 44, 72, "Fideos de arroz", 1, 15 },
                    { 45, 73, "Lasañas congeladas", 1, 15 },
                    { 46, 76, "Lentejas orgánicas", 1, 16 },
                    { 47, 77, "Garbanzos secos", 1, 16 },
                    { 48, 78, "Frijoles negros", 2, 16 },
                    { 49, 81, "Pimienta negra molida", 1, 17 },
                    { 50, 82, "Pimienta blanca", 1, 17 },
                    { 51, 83, "Curry en polvo", 1, 17 },
                    { 52, 86, "Botellas de cerveza", 6, 18 },
                    { 53, 87, "Vino tinto", 2, 18 },
                    { 54, 88, "Vino blanco", 1, 18 },
                    { 55, 91, "Latas de atún", 3, 19 },
                    { 56, 92, "Latas de maíz", 2, 19 },
                    { 57, 93, "Latas de guisantes", 1, 19 },
                    { 58, 96, "Salsa de tomate", 1, 20 },
                    { 59, 97, "Salsa BBQ", 1, 20 },
                    { 60, 98, "Salsa Alfredo", 1, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_list_items",
                keyColumn: "shopping_list_item_id",
                keyValue: 60);
        }
    }
}
