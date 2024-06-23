using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToteSync.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FirstStepsOnDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "tote",
                table: "groups",
                columns: new[] { "group_id", "group_name" },
                values: new object[,]
                {
                    { 1, "Familia Fonseca Moncada" },
                    { 2, "Familia Fonseca Mata" },
                    { 3, "Familia Quintana Perez" }
                });

            migrationBuilder.InsertData(
                schema: "tote",
                table: "users",
                columns: new[] { "user_id", "user_avatar_url", "user_birthdate", "user_email", "user_first_last_name", "user_is_active", "user_name", "user_phone_number", "user_second_last_name", "user_zip_code" },
                values: new object[,]
                {
                    { 1, "https://www.google.com/", new DateOnly(2001, 5, 14), "pablo.fonsecam@outlook.com", "Fonseca", true, "Pablo", "87719888", "Moncada", 506 },
                    { 2, "https://www.fakephoto.com/", new DateOnly(2003, 6, 3), "perezvirginia889@gmail.com", "Mata", true, "Virginia", "72892168", "Perez", 506 },
                    { 3, "https://www.fakecatphoto.com/", new DateOnly(1989, 5, 30), "daniel.bleach1@gmail.com", "Quintana", true, "Daniel", "70068596", "Medina", 506 },
                    { 4, "https://www.fakephoto.com/", new DateOnly(1973, 10, 23), "dafotr@outlook.com", "Fonseca", true, "Danny", "83030630", "Trejos", 506 }
                });

            migrationBuilder.InsertData(
                schema: "tote",
                table: "group_members",
                columns: new[] { "group_member_id", "group_member_group_id", "group_member_user_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 },
                    { 3, 2, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 2 },
                    { 6, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "tote",
                table: "group_members",
                keyColumn: "group_member_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "group_members",
                keyColumn: "group_member_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "group_members",
                keyColumn: "group_member_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "group_members",
                keyColumn: "group_member_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "group_members",
                keyColumn: "group_member_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "group_members",
                keyColumn: "group_member_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "groups",
                keyColumn: "group_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "groups",
                keyColumn: "group_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "groups",
                keyColumn: "group_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "users",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "users",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "users",
                keyColumn: "user_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "tote",
                table: "users",
                keyColumn: "user_id",
                keyValue: 4);
        }
    }
}
