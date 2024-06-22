using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToteSync.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "tote",
                table: "shopping_lists",
                columns: new[] { "shopping_list_id", "shopping_list_group_id", "shopping_list_name", "shopping_list_user_id" },
                values: new object[,]
                {
                    { 1, 1, "Lista de Compras de Pablo - Casa Atenas", 1 },
                    { 2, 1, "Lista de Compras de Pablo - Donación Familia Fonseca Moncada", 1 },
                    { 3, 1, "Lista de Compras de Pablo - Fiesta de Cumpleaños", 1 },
                    { 4, 1, "Lista de Compras de Pablo - Picnic en el Parque", 1 },
                    { 5, 1, "Lista de Compras de Pablo - Viaje de Fin de Semana", 1 },
                    { 6, 2, "Lista de Compras de Virginia - Compras del mes de Junio", 2 },
                    { 7, 2, "Lista de Compras de Virginia - Fiesta de Fin de Año", 2 },
                    { 8, 2, "Lista de Compras de Virginia - Cena Romántica", 2 },
                    { 9, 2, "Lista de Compras de Virginia - Picnic en la Playa", 2 },
                    { 10, 2, "Lista de Compras de Virginia - Evento Familiar", 2 },
                    { 11, 3, "Lista de Compras de Daniel - Semana Santa", 3 },
                    { 12, 3, "Lista de Compras de Daniel - Navidad", 3 },
                    { 13, 3, "Lista de Compras de Daniel - Aniversario", 3 },
                    { 14, 3, "Lista de Compras de Daniel - Cumpleaños", 3 },
                    { 15, 3, "Lista de Compras de Daniel - Barbacoa", 3 },
                    { 16, 1, "Lista de Compras de Danny - Fiesta de Verano", 4 },
                    { 17, 1, "Lista de Compras de Danny - Fin de Año", 4 },
                    { 18, 1, "Lista de Compras de Danny - Reunión Familiar", 4 },
                    { 19, 1, "Lista de Compras de Danny - Asado", 4 },
                    { 20, 1, "Lista de Compras de Danny - Viaje de Camping", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "shopping_lists",
                keyColumn: "shopping_list_id",
                keyValue: 20);
        }
    }
}
