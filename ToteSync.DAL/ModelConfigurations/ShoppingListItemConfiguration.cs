using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToteSync.Domain;

namespace ToteSync.DAL.ModelConfigurations
{
    public class ShoppingListItemConfiguration : IEntityTypeConfiguration<ShoppingListItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
        {
            //Basic parameters
            builder.HasKey(e => e.ShoppingListItemId).HasName("shopping_list_items_pk");
            builder.ToTable("shopping_list_items", "tote");

            builder.HasIndex(e => new { e.ShoppingListItemItemId, e.ShoppingListItemShoppingListId }, "shopping_list_items_item_list_uindex").IsUnique();

            //Property rules
            builder.Property(e => e.ShoppingListItemId).HasColumnName("shopping_list_item_id");
            builder.Property(e => e.ShoppingListItemItemId).HasColumnName("shopping_list_item_item_id");
            builder.Property(e => e.ShoppingListItemNotes)
                .HasMaxLength(255)
                .HasColumnName("shopping_list_item_notes");
            builder.Property(e => e.ShoppingListItemQuantity)
                .HasDefaultValue(0)
                .HasColumnName("shopping_list_item_quantity");
            builder.Property(e => e.ShoppingListItemShoppingListId).HasColumnName("shopping_list_item_shopping_list_id");

            builder.HasOne(d => d.ShoppingListItemItem).WithMany(p => p.ShoppingListItems)
                .HasForeignKey(d => d.ShoppingListItemItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("shopping_list_items_items_fk");

            builder.HasOne(d => d.ShoppingListItemShoppingList).WithMany(p => p.ShoppingListItems)
                .HasForeignKey(d => d.ShoppingListItemShoppingListId)
                .HasConstraintName("shopping_list_items_shopping_lists_fk");

            //Data-seeding
            builder.HasData([
            // Shopping List Items for User 1
            new ShoppingListItem {
                ShoppingListItemId = 1,
                ShoppingListItemItemId = 1,
                ShoppingListItemShoppingListId = 1,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Zanahorias frescas",
            },
            new ShoppingListItem {
                ShoppingListItemId = 2,
                ShoppingListItemItemId = 2,
                ShoppingListItemShoppingListId = 1,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Tomates maduros",
            },
            new ShoppingListItem {
                ShoppingListItemId = 3,
                ShoppingListItemItemId = 3,
                ShoppingListItemShoppingListId = 1,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Lechuga romana",
            },
            new ShoppingListItem {
                ShoppingListItemId = 4,
                ShoppingListItemItemId = 6,
                ShoppingListItemShoppingListId = 2,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Manzanas rojas",
            },
            new ShoppingListItem {
                ShoppingListItemId = 5,
                ShoppingListItemItemId = 7,
                ShoppingListItemShoppingListId = 2,
                ShoppingListItemQuantity = 3,
                ShoppingListItemNotes = "Plátanos maduros",
            },
            new ShoppingListItem {
                ShoppingListItemId = 6,
                ShoppingListItemItemId = 8,
                ShoppingListItemShoppingListId = 2,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Uvas verdes",
            },
            new ShoppingListItem {
                ShoppingListItemId = 7,
                ShoppingListItemItemId = 11,
                ShoppingListItemShoppingListId = 3,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Pechugas de pollo",
            },
            new ShoppingListItem {
                ShoppingListItemId = 8,
                ShoppingListItemItemId = 12,
                ShoppingListItemShoppingListId = 3,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Carne de res molida",
            },
            new ShoppingListItem {
                ShoppingListItemId = 9,
                ShoppingListItemItemId = 13,
                ShoppingListItemShoppingListId = 3,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Chuletas de cerdo",
            },
            new ShoppingListItem {
                ShoppingListItemId = 10,
                ShoppingListItemItemId = 16,
                ShoppingListItemShoppingListId = 4,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Queso cheddar",
            },
            new ShoppingListItem {
                ShoppingListItemId = 11,
                ShoppingListItemItemId = 17,
                ShoppingListItemShoppingListId = 4,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Leche descremada",
            },
            new ShoppingListItem {
                ShoppingListItemId = 12,
                ShoppingListItemItemId = 18,
                ShoppingListItemShoppingListId = 4,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Yogur natural",
            },
            new ShoppingListItem {
                ShoppingListItemId = 13,
                ShoppingListItemItemId = 21,
                ShoppingListItemShoppingListId = 5,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Arroz integral",
            },
            new ShoppingListItem {
                ShoppingListItemId = 14,
                ShoppingListItemItemId = 22,
                ShoppingListItemShoppingListId = 5,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Frijoles negros",
            },
            new ShoppingListItem {
                ShoppingListItemId = 15,
                ShoppingListItemItemId = 23,
                ShoppingListItemShoppingListId = 5,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Maíz dulce",
            },

            // Shopping List Items for User 2
            new ShoppingListItem {
                ShoppingListItemId = 16,
                ShoppingListItemItemId = 26,
                ShoppingListItemShoppingListId = 6,
                ShoppingListItemQuantity = 6,
                ShoppingListItemNotes = "Botellas de agua",
            },
            new ShoppingListItem {
                ShoppingListItemId = 17,
                ShoppingListItemItemId = 27,
                ShoppingListItemShoppingListId = 6,
                ShoppingListItemQuantity = 4,
                ShoppingListItemNotes = "Jugos de naranja",
            },
            new ShoppingListItem {
                ShoppingListItemId = 18,
                ShoppingListItemItemId = 28,
                ShoppingListItemShoppingListId = 6,
                ShoppingListItemQuantity = 3,
                ShoppingListItemNotes = "Refrescos variados",
            },
            new ShoppingListItem {
                ShoppingListItemId = 19,
                ShoppingListItemItemId = 31,
                ShoppingListItemShoppingListId = 7,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Pan integral",
            },
            new ShoppingListItem {
                ShoppingListItemId = 20,
                ShoppingListItemItemId = 32,
                ShoppingListItemShoppingListId = 7,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Pan blanco",
            },
            new ShoppingListItem {
                ShoppingListItemId = 21,
                ShoppingListItemItemId = 33,
                ShoppingListItemShoppingListId = 7,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Pan de centeno",
            },
            new ShoppingListItem {
                ShoppingListItemId = 22,
                ShoppingListItemItemId = 36,
                ShoppingListItemShoppingListId = 8,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Filetes de salmón",
            },
            new ShoppingListItem {
                ShoppingListItemId = 23,
                ShoppingListItemItemId = 37,
                ShoppingListItemShoppingListId = 8,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Latas de atún",
            },
            new ShoppingListItem {
                ShoppingListItemId = 24,
                ShoppingListItemItemId = 38,
                ShoppingListItemShoppingListId = 8,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Filetes de trucha",
            },
            new ShoppingListItem {
                ShoppingListItemId = 25,
                ShoppingListItemItemId = 41,
                ShoppingListItemShoppingListId = 9,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Aceite de oliva extra virgen",
            },
            new ShoppingListItem {
                ShoppingListItemId = 26,
                ShoppingListItemItemId = 42,
                ShoppingListItemShoppingListId = 9,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Aceite de girasol",
            },
            new ShoppingListItem {
                ShoppingListItemId = 27,
                ShoppingListItemItemId = 43,
                ShoppingListItemShoppingListId = 9,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Aceite de coco orgánico",
            },
            new ShoppingListItem {
                ShoppingListItemId = 28,
                ShoppingListItemItemId = 46,
                ShoppingListItemShoppingListId = 10,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Bolsas de papas fritas",
            },
            new ShoppingListItem {
                ShoppingListItemId = 29,
                ShoppingListItemItemId = 47,
                ShoppingListItemShoppingListId = 10,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Galletas de chocolate",
            },
            new ShoppingListItem {
                ShoppingListItemId = 30,
                ShoppingListItemItemId = 48,
                ShoppingListItemShoppingListId = 10,
                ShoppingListItemQuantity = 3,
                ShoppingListItemNotes = "Palomitas de maíz",
            },

            // Shopping List Items for User 3
            new ShoppingListItem {
                ShoppingListItemId = 31,
                ShoppingListItemItemId = 51,
                ShoppingListItemShoppingListId = 11,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Sal marina",
            },
            new ShoppingListItem {
                ShoppingListItemId = 32,
                ShoppingListItemItemId = 52,
                ShoppingListItemShoppingListId = 11,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Pimienta negra",
            },
            new ShoppingListItem {
                ShoppingListItemId = 33,
                ShoppingListItemItemId = 53,
                ShoppingListItemShoppingListId = 11,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Orégano seco",
            },
            new ShoppingListItem {
                ShoppingListItemId = 34,
                ShoppingListItemItemId = 56,
                ShoppingListItemShoppingListId = 12,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Avena integral",
            },
            new ShoppingListItem {
                ShoppingListItemId = 35,
                ShoppingListItemItemId = 57,
                ShoppingListItemShoppingListId = 12,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Trigo sarraceno",
            },
            new ShoppingListItem {
                ShoppingListItemId = 36,
                ShoppingListItemItemId = 58,
                ShoppingListItemShoppingListId = 12,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Harina de maíz",
            },
            new ShoppingListItem {
                ShoppingListItemId = 37,
                ShoppingListItemItemId = 61,
                ShoppingListItemShoppingListId = 13,
                ShoppingListItemQuantity = 3,
                ShoppingListItemNotes = "Barras de chocolate",
            },
            new ShoppingListItem {
                ShoppingListItemId = 38,
                ShoppingListItemItemId = 62,
                ShoppingListItemShoppingListId = 13,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Caramelos surtidos",
            },
            new ShoppingListItem {
                ShoppingListItemId = 39,
                ShoppingListItemItemId = 63,
                ShoppingListItemShoppingListId = 13,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Chicles de menta",
            },
            new ShoppingListItem {
                ShoppingListItemId = 40,
                ShoppingListItemItemId = 66,
                ShoppingListItemShoppingListId = 14,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Helado de vainilla",
            },
            new ShoppingListItem {
                ShoppingListItemId = 41,
                ShoppingListItemItemId = 67,
                ShoppingListItemShoppingListId = 14,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Helado de chocolate",
            },
            new ShoppingListItem {
                ShoppingListItemId = 42,
                ShoppingListItemItemId = 68,
                ShoppingListItemShoppingListId = 14,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Helado de fresa",
            },
            new ShoppingListItem {
                ShoppingListItemId = 43,
                ShoppingListItemItemId = 71,
                ShoppingListItemShoppingListId = 15,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Paquetes de espagueti",
            },
            new ShoppingListItem {
                ShoppingListItemId = 44,
                ShoppingListItemItemId = 72,
                ShoppingListItemShoppingListId = 15,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Fideos de arroz",
            },
            new ShoppingListItem {
                ShoppingListItemId = 45,
                ShoppingListItemItemId = 73,
                ShoppingListItemShoppingListId = 15,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Lasañas congeladas",
            },

            // Shopping List Items for User 4
            new ShoppingListItem {
                ShoppingListItemId = 46,
                ShoppingListItemItemId = 76,
                ShoppingListItemShoppingListId = 16,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Lentejas orgánicas",
            },
            new ShoppingListItem {
                ShoppingListItemId = 47,
                ShoppingListItemItemId = 77,
                ShoppingListItemShoppingListId = 16,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Garbanzos secos",
            },
            new ShoppingListItem {
                ShoppingListItemId = 48,
                ShoppingListItemItemId = 78,
                ShoppingListItemShoppingListId = 16,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Frijoles negros",
            },
            new ShoppingListItem {
                ShoppingListItemId = 49,
                ShoppingListItemItemId = 81,
                ShoppingListItemShoppingListId = 17,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Pimienta negra molida",
            },
            new ShoppingListItem {
                ShoppingListItemId = 50,
                ShoppingListItemItemId = 82,
                ShoppingListItemShoppingListId = 17,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Pimienta blanca",
            },
            new ShoppingListItem {
                ShoppingListItemId = 51,
                ShoppingListItemItemId = 83,
                ShoppingListItemShoppingListId = 17,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Curry en polvo",
            },
            new ShoppingListItem {
                ShoppingListItemId = 52,
                ShoppingListItemItemId = 86,
                ShoppingListItemShoppingListId = 18,
                ShoppingListItemQuantity = 6,
                ShoppingListItemNotes = "Botellas de cerveza",
            },
            new ShoppingListItem {
                ShoppingListItemId = 53,
                ShoppingListItemItemId = 87,
                ShoppingListItemShoppingListId = 18,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Vino tinto",
            },
            new ShoppingListItem {
                ShoppingListItemId = 54,
                ShoppingListItemItemId = 88,
                ShoppingListItemShoppingListId = 18,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Vino blanco",
            },
            new ShoppingListItem {
                ShoppingListItemId = 55,
                ShoppingListItemItemId = 91,
                ShoppingListItemShoppingListId = 19,
                ShoppingListItemQuantity = 3,
                ShoppingListItemNotes = "Latas de atún",
            },
            new ShoppingListItem {
                ShoppingListItemId = 56,
                ShoppingListItemItemId = 92,
                ShoppingListItemShoppingListId = 19,
                ShoppingListItemQuantity = 2,
                ShoppingListItemNotes = "Latas de maíz",
            },
            new ShoppingListItem {
                ShoppingListItemId = 57,
                ShoppingListItemItemId = 93,
                ShoppingListItemShoppingListId = 19,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Latas de guisantes",
            },
            new ShoppingListItem {
                ShoppingListItemId = 58,
                ShoppingListItemItemId = 96,
                ShoppingListItemShoppingListId = 20,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Salsa de tomate",
            },
            new ShoppingListItem {
                ShoppingListItemId = 59,
                ShoppingListItemItemId = 97,
                ShoppingListItemShoppingListId = 20,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Salsa BBQ",
            },
            new ShoppingListItem {
                ShoppingListItemId = 60,
                ShoppingListItemItemId = 98,
                ShoppingListItemShoppingListId = 20,
                ShoppingListItemQuantity = 1,
                ShoppingListItemNotes = "Salsa Alfredo",
            }
            ]);
        }
    }
}
