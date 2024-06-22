using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToteSync.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ItemEntityDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "tote",
                table: "items",
                columns: new[] { "item_id", "item_category_id", "item_name", "item_user_id" },
                values: new object[,]
                {
                    { 1, 1, "Zanahoria", 1 },
                    { 2, 1, "Tomate", 1 },
                    { 3, 1, "Lechuga", 1 },
                    { 4, 1, "Pepino", 1 },
                    { 5, 1, "Espinaca", 1 },
                    { 6, 2, "Manzana", 1 },
                    { 7, 2, "Plátano", 1 },
                    { 8, 2, "Uva", 1 },
                    { 9, 2, "Naranja", 1 },
                    { 10, 2, "Pera", 1 },
                    { 11, 3, "Pollo", 1 },
                    { 12, 3, "Res", 1 },
                    { 13, 3, "Cerdo", 1 },
                    { 14, 3, "Pavo", 1 },
                    { 15, 3, "Cordero", 1 },
                    { 16, 4, "Queso", 1 },
                    { 17, 4, "Leche", 1 },
                    { 18, 4, "Yogur", 1 },
                    { 19, 4, "Mantequilla", 1 },
                    { 20, 4, "Crema", 1 },
                    { 21, 5, "Arroz", 1 },
                    { 22, 5, "Frijoles", 1 },
                    { 23, 5, "Maíz", 1 },
                    { 24, 5, "Lentejas", 1 },
                    { 25, 5, "Avena", 1 },
                    { 26, 6, "Agua", 2 },
                    { 27, 6, "Jugo", 2 },
                    { 28, 6, "Refresco", 2 },
                    { 29, 6, "Té", 2 },
                    { 30, 6, "Café", 2 },
                    { 31, 7, "Pan integral", 2 },
                    { 32, 7, "Pan blanco", 2 },
                    { 33, 7, "Pan de centeno", 2 },
                    { 34, 7, "Pan de avena", 2 },
                    { 35, 7, "Baguette", 2 },
                    { 36, 8, "Salmón", 2 },
                    { 37, 8, "Atún", 2 },
                    { 38, 8, "Trucha", 2 },
                    { 39, 8, "Bacalao", 2 },
                    { 40, 8, "Tilapia", 2 },
                    { 41, 9, "Aceite de oliva", 2 },
                    { 42, 9, "Aceite de girasol", 2 },
                    { 43, 9, "Aceite de coco", 2 },
                    { 44, 9, "Aceite de aguacate", 2 },
                    { 45, 9, "Aceite de sésamo", 2 },
                    { 46, 10, "Papas fritas", 2 },
                    { 47, 10, "Galletas", 2 },
                    { 48, 10, "Palomitas", 2 },
                    { 49, 10, "Chocolates", 2 },
                    { 50, 10, "Nueces", 2 },
                    { 51, 11, "Sal", 3 },
                    { 52, 11, "Pimienta", 3 },
                    { 53, 11, "Orégano", 3 },
                    { 54, 11, "Comino", 3 },
                    { 55, 11, "Canela", 3 },
                    { 56, 12, "Avena", 3 },
                    { 57, 12, "Trigo", 3 },
                    { 58, 12, "Maíz", 3 },
                    { 59, 12, "Cebada", 3 },
                    { 60, 12, "Quinoa", 3 },
                    { 61, 13, "Chocolate", 3 },
                    { 62, 13, "Caramelo", 3 },
                    { 63, 13, "Chicle", 3 },
                    { 64, 13, "Gomitas", 3 },
                    { 65, 13, "Barras de cereal", 3 },
                    { 66, 14, "Helado de vainilla", 3 },
                    { 67, 14, "Helado de chocolate", 3 },
                    { 68, 14, "Helado de fresa", 3 },
                    { 69, 14, "Helado de menta", 3 },
                    { 70, 14, "Helado de coco", 3 },
                    { 71, 15, "Espagueti", 3 },
                    { 72, 15, "Fideos", 3 },
                    { 73, 15, "Lasaña", 3 },
                    { 74, 15, "Raviolis", 3 },
                    { 75, 15, "Macarrones", 3 },
                    { 76, 16, "Lentejas", 4 },
                    { 77, 16, "Garbanzos", 4 },
                    { 78, 16, "Frijoles", 4 },
                    { 79, 16, "Habas", 4 },
                    { 80, 16, "Chícharos", 4 },
                    { 81, 17, "Pimienta negra", 4 },
                    { 82, 17, "Pimienta blanca", 4 },
                    { 83, 17, "Curry", 4 },
                    { 84, 17, "Paprika", 4 },
                    { 85, 17, "Clavo", 4 },
                    { 86, 18, "Cerveza", 4 },
                    { 87, 18, "Vino tinto", 4 },
                    { 88, 18, "Vino blanco", 4 },
                    { 89, 18, "Ron", 4 },
                    { 90, 18, "Vodka", 4 },
                    { 91, 19, "Atún enlatado", 4 },
                    { 92, 19, "Maíz enlatado", 4 },
                    { 93, 19, "Guisantes enlatados", 4 },
                    { 94, 19, "Tomate enlatado", 4 },
                    { 95, 19, "Champiñones enlatados", 4 },
                    { 96, 20, "Salsa de tomate", 4 },
                    { 97, 20, "Salsa BBQ", 4 },
                    { 98, 20, "Salsa Alfredo", 4 },
                    { 99, 20, "Salsa de soya", 4 },
                    { 100, 20, "Salsa de ajo", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "items",
                keyColumn: "item_id",
                keyValue: 100);
        }
    }
}
