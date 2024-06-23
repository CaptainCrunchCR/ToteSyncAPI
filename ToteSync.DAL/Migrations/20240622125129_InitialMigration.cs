using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ToteSync.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tote");

            migrationBuilder.CreateTable(
                name: "groups",
                schema: "tote",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    group_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    group_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("groups_pk", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "tote",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    user_first_last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    user_second_last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    user_is_active = table.Column<bool>(type: "boolean", nullable: false),
                    user_birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    user_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    user_avatar_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    user_phone_number = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    user_zip_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pk", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "tote",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    category_description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    category_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categories_pk", x => x.category_id);
                    table.ForeignKey(
                        name: "categories_users_user_id_fk",
                        column: x => x.category_user_id,
                        principalSchema: "tote",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_members",
                schema: "tote",
                columns: table => new
                {
                    group_member_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_member_group_id = table.Column<int>(type: "integer", nullable: false),
                    group_member_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("group_members_pk", x => x.group_member_id);
                    table.ForeignKey(
                        name: "group_members_groups_fk",
                        column: x => x.group_member_group_id,
                        principalSchema: "tote",
                        principalTable: "groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "group_members_users_fk",
                        column: x => x.group_member_user_id,
                        principalSchema: "tote",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopping_lists",
                schema: "tote",
                columns: table => new
                {
                    shopping_list_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shopping_list_user_id = table.Column<int>(type: "integer", nullable: false),
                    shopping_list_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    shopping_list_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    shopping_list_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    shopping_list_group_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("shopping_lists_pk", x => x.shopping_list_id);
                    table.ForeignKey(
                        name: "shopping_lists_groups_fk",
                        column: x => x.shopping_list_group_id,
                        principalSchema: "tote",
                        principalTable: "groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "shopping_lists_users_fk",
                        column: x => x.shopping_list_user_id,
                        principalSchema: "tote",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items",
                schema: "tote",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    item_category_id = table.Column<int>(type: "integer", nullable: true),
                    item_user_id = table.Column<int>(type: "integer", nullable: false),
                    item_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    item_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("items_pk", x => x.item_id);
                    table.ForeignKey(
                        name: "items_categories_fk",
                        column: x => x.item_category_id,
                        principalSchema: "tote",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "items_users_fk",
                        column: x => x.item_user_id,
                        principalSchema: "tote",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopping_list_items",
                schema: "tote",
                columns: table => new
                {
                    shopping_list_item_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shopping_list_item_shopping_list_id = table.Column<int>(type: "integer", nullable: false),
                    shopping_list_item_item_id = table.Column<int>(type: "integer", nullable: false),
                    shopping_list_item_quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    shopping_list_item_notes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("shopping_list_items_pk", x => x.shopping_list_item_id);
                    table.ForeignKey(
                        name: "shopping_list_items_items_fk",
                        column: x => x.shopping_list_item_item_id,
                        principalSchema: "tote",
                        principalTable: "items",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "shopping_list_items_shopping_lists_fk",
                        column: x => x.shopping_list_item_shopping_list_id,
                        principalSchema: "tote",
                        principalTable: "shopping_lists",
                        principalColumn: "shopping_list_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_category_user_id",
                schema: "tote",
                table: "categories",
                column: "category_user_id");

            migrationBuilder.CreateIndex(
                name: "group_members_user_group_uindex",
                schema: "tote",
                table: "group_members",
                columns: new[] { "group_member_user_id", "group_member_group_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_group_members_group_member_group_id",
                schema: "tote",
                table: "group_members",
                column: "group_member_group_id");

            migrationBuilder.CreateIndex(
                name: "items_category_user_name_uindex",
                schema: "tote",
                table: "items",
                columns: new[] { "item_category_id", "item_user_id", "item_name" },
                unique: true,
                filter: "(item_category_id IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "items_user_name_uindex",
                schema: "tote",
                table: "items",
                columns: new[] { "item_user_id", "item_name" },
                unique: true,
                filter: "(item_category_id IS NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_list_items_shopping_list_item_shopping_list_id",
                schema: "tote",
                table: "shopping_list_items",
                column: "shopping_list_item_shopping_list_id");

            migrationBuilder.CreateIndex(
                name: "shopping_list_items_item_list_uindex",
                schema: "tote",
                table: "shopping_list_items",
                columns: new[] { "shopping_list_item_item_id", "shopping_list_item_shopping_list_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shopping_lists_shopping_list_user_id",
                schema: "tote",
                table: "shopping_lists",
                column: "shopping_list_user_id");

            migrationBuilder.CreateIndex(
                name: "shopping_lists_group_name_user_uindex",
                schema: "tote",
                table: "shopping_lists",
                columns: new[] { "shopping_list_group_id", "shopping_list_name", "shopping_list_user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_user_email_uindex",
                schema: "tote",
                table: "users",
                column: "user_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_user_phone_number_uindex",
                schema: "tote",
                table: "users",
                column: "user_phone_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "group_members",
                schema: "tote");

            migrationBuilder.DropTable(
                name: "shopping_list_items",
                schema: "tote");

            migrationBuilder.DropTable(
                name: "items",
                schema: "tote");

            migrationBuilder.DropTable(
                name: "shopping_lists",
                schema: "tote");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "tote");

            migrationBuilder.DropTable(
                name: "groups",
                schema: "tote");

            migrationBuilder.DropTable(
                name: "users",
                schema: "tote");
        }
    }
}
