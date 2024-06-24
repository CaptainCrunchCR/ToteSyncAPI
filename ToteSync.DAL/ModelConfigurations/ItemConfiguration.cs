using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToteSync.Domain.Models;

namespace ToteSync.DAL.ModelConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            //Basic parameters
            builder.HasKey(e => e.ItemId).HasName("items_pk");
            builder.ToTable("items", "tote");

            builder.HasIndex(e => new { e.ItemCategoryId, e.ItemUserId, e.ItemName }, "items_category_user_name_uindex")
                .IsUnique()
                .HasFilter("(item_category_id IS NOT NULL)");

            builder.HasIndex(e => new { e.ItemUserId, e.ItemName }, "items_user_name_uindex")
                .IsUnique()
                .HasFilter("(item_category_id IS NULL)");

            //Property rules
            builder.Property(e => e.ItemId).HasColumnName("item_id");
            builder.Property(e => e.ItemCategoryId).HasColumnName("item_category_id");
            builder.Property(e => e.ItemCreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("item_created_date");
            builder.Property(e => e.ItemModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("item_modified_date");
            builder.Property(e => e.ItemName)
                .HasMaxLength(150)
                .HasColumnName("item_name");
            builder.Property(e => e.ItemUserId).HasColumnName("item_user_id");

            builder.HasOne(d => d.ItemCategory).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("items_categories_fk");

            builder.HasOne(d => d.ItemUser).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemUserId)
                .HasConstraintName("items_users_fk");

            //Data-seeding
            builder.HasData([
            // Items for User 1
            new Item {
                ItemId = 1,
                ItemName = "Zanahoria",
                ItemCategoryId = 1,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 2,
                ItemName = "Tomate",
                ItemCategoryId = 1,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 3,
                ItemName = "Lechuga",
                ItemCategoryId = 1,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 4,
                ItemName = "Pepino",
                ItemCategoryId = 1,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 5,
                ItemName = "Espinaca",
                ItemCategoryId = 1,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 6,
                ItemName = "Manzana",
                ItemCategoryId = 2,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 7,
                ItemName = "Plátano",
                ItemCategoryId = 2,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 8,
                ItemName = "Uva",
                ItemCategoryId = 2,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 9,
                ItemName = "Naranja",
                ItemCategoryId = 2,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 10,
                ItemName = "Pera",
                ItemCategoryId = 2,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 11,
                ItemName = "Pollo",
                ItemCategoryId = 3,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 12,
                ItemName = "Res",
                ItemCategoryId = 3,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 13,
                ItemName = "Cerdo",
                ItemCategoryId = 3,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 14,
                ItemName = "Pavo",
                ItemCategoryId = 3,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 15,
                ItemName = "Cordero",
                ItemCategoryId = 3,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 16,
                ItemName = "Queso",
                ItemCategoryId = 4,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 17,
                ItemName = "Leche",
                ItemCategoryId = 4,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 18,
                ItemName = "Yogur",
                ItemCategoryId = 4,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 19,
                ItemName = "Mantequilla",
                ItemCategoryId = 4,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 20,
                ItemName = "Crema",
                ItemCategoryId = 4,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 21,
                ItemName = "Arroz",
                ItemCategoryId = 5,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 22,
                ItemName = "Frijoles",
                ItemCategoryId = 5,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 23,
                ItemName = "Maíz",
                ItemCategoryId = 5,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 24,
                ItemName = "Lentejas",
                ItemCategoryId = 5,
                ItemUserId = 1,
            },
            new Item {
                ItemId = 25,
                ItemName = "Avena",
                ItemCategoryId = 5,
                ItemUserId = 1,
            },

            // Items for User 2
            new Item {
                ItemId = 26,
                ItemName = "Agua",
                ItemCategoryId = 6,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 27,
                ItemName = "Jugo",
                ItemCategoryId = 6,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 28,
                ItemName = "Refresco",
                ItemCategoryId = 6,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 29,
                ItemName = "Té",
                ItemCategoryId = 6,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 30,
                ItemName = "Café",
                ItemCategoryId = 6,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 31,
                ItemName = "Pan integral",
                ItemCategoryId = 7,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 32,
                ItemName = "Pan blanco",
                ItemCategoryId = 7,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 33,
                ItemName = "Pan de centeno",
                ItemCategoryId = 7,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 34,
                ItemName = "Pan de avena",
                ItemCategoryId = 7,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 35,
                ItemName = "Baguette",
                ItemCategoryId = 7,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 36,
                ItemName = "Salmón",
                ItemCategoryId = 8,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 37,
                ItemName = "Atún",
                ItemCategoryId = 8,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 38,
                ItemName = "Trucha",
                ItemCategoryId = 8,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 39,
                ItemName = "Bacalao",
                ItemCategoryId = 8,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 40,
                ItemName = "Tilapia",
                ItemCategoryId = 8,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 41,
                ItemName = "Aceite de oliva",
                ItemCategoryId = 9,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 42,
                ItemName = "Aceite de girasol",
                ItemCategoryId = 9,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 43,
                ItemName = "Aceite de coco",
                ItemCategoryId = 9,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 44,
                ItemName = "Aceite de aguacate",
                ItemCategoryId = 9,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 45,
                ItemName = "Aceite de sésamo",
                ItemCategoryId = 9,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 46,
                ItemName = "Papas fritas",
                ItemCategoryId = 10,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 47,
                ItemName = "Galletas",
                ItemCategoryId = 10,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 48,
                ItemName = "Palomitas",
                ItemCategoryId = 10,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 49,
                ItemName = "Chocolates",
                ItemCategoryId = 10,
                ItemUserId = 2,
            },
            new Item {
                ItemId = 50,
                ItemName = "Nueces",
                ItemCategoryId = 10,
                ItemUserId = 2,
            },

            // Items for User 3
            new Item {
                ItemId = 51,
                ItemName = "Sal",
                ItemCategoryId = 11,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 52,
                ItemName = "Pimienta",
                ItemCategoryId = 11,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 53,
                ItemName = "Orégano",
                ItemCategoryId = 11,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 54,
                ItemName = "Comino",
                ItemCategoryId = 11,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 55,
                ItemName = "Canela",
                ItemCategoryId = 11,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 56,
                ItemName = "Avena",
                ItemCategoryId = 12,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 57,
                ItemName = "Trigo",
                ItemCategoryId = 12,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 58,
                ItemName = "Maíz",
                ItemCategoryId = 12,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 59,
                ItemName = "Cebada",
                ItemCategoryId = 12,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 60,
                ItemName = "Quinoa",
                ItemCategoryId = 12,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 61,
                ItemName = "Chocolate",
                ItemCategoryId = 13,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 62,
                ItemName = "Caramelo",
                ItemCategoryId = 13,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 63,
                ItemName = "Chicle",
                ItemCategoryId = 13,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 64,
                ItemName = "Gomitas",
                ItemCategoryId = 13,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 65,
                ItemName = "Barras de cereal",
                ItemCategoryId = 13,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 66,
                ItemName = "Helado de vainilla",
                ItemCategoryId = 14,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 67,
                ItemName = "Helado de chocolate",
                ItemCategoryId = 14,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 68,
                ItemName = "Helado de fresa",
                ItemCategoryId = 14,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 69,
                ItemName = "Helado de menta",
                ItemCategoryId = 14,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 70,
                ItemName = "Helado de coco",
                ItemCategoryId = 14,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 71,
                ItemName = "Espagueti",
                ItemCategoryId = 15,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 72,
                ItemName = "Fideos",
                ItemCategoryId = 15,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 73,
                ItemName = "Lasaña",
                ItemCategoryId = 15,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 74,
                ItemName = "Raviolis",
                ItemCategoryId = 15,
                ItemUserId = 3,
            },
            new Item {
                ItemId = 75,
                ItemName = "Macarrones",
                ItemCategoryId = 15,
                ItemUserId = 3,
            },

            // Items for User 4
            new Item {
                ItemId = 76,
                ItemName = "Lentejas",
                ItemCategoryId = 16,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 77,
                ItemName = "Garbanzos",
                ItemCategoryId = 16,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 78,
                ItemName = "Frijoles",
                ItemCategoryId = 16,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 79,
                ItemName = "Habas",
                ItemCategoryId = 16,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 80,
                ItemName = "Chícharos",
                ItemCategoryId = 16,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 81,
                ItemName = "Pimienta negra",
                ItemCategoryId = 17,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 82,
                ItemName = "Pimienta blanca",
                ItemCategoryId = 17,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 83,
                ItemName = "Curry",
                ItemCategoryId = 17,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 84,
                ItemName = "Paprika",
                ItemCategoryId = 17,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 85,
                ItemName = "Clavo",
                ItemCategoryId = 17,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 86,
                ItemName = "Cerveza",
                ItemCategoryId = 18,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 87,
                ItemName = "Vino tinto",
                ItemCategoryId = 18,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 88,
                ItemName = "Vino blanco",
                ItemCategoryId = 18,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 89,
                ItemName = "Ron",
                ItemCategoryId = 18,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 90,
                ItemName = "Vodka",
                ItemCategoryId = 18,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 91,
                ItemName = "Atún enlatado",
                ItemCategoryId = 19,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 92,
                ItemName = "Maíz enlatado",
                ItemCategoryId = 19,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 93,
                ItemName = "Guisantes enlatados",
                ItemCategoryId = 19,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 94,
                ItemName = "Tomate enlatado",
                ItemCategoryId = 19,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 95,
                ItemName = "Champiñones enlatados",
                ItemCategoryId = 19,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 96,
                ItemName = "Salsa de tomate",
                ItemCategoryId = 20,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 97,
                ItemName = "Salsa BBQ",
                ItemCategoryId = 20,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 98,
                ItemName = "Salsa Alfredo",
                ItemCategoryId = 20,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 99,
                ItemName = "Salsa de soya",
                ItemCategoryId = 20,
                ItemUserId = 4,
            },
            new Item {
                ItemId = 100,
                ItemName = "Salsa de ajo",
                ItemCategoryId = 20,
                ItemUserId = 4,
            }
            ]);
        }
    }
}
