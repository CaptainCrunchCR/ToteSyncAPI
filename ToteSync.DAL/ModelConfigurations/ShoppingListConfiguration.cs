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
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            //Basic parameters
            builder.HasKey(e => e.ShoppingListId).HasName("shopping_lists_pk");
            builder.ToTable("shopping_lists", "tote");

            builder.HasIndex(e => new { e.ShoppingListGroupId, e.ShoppingListName, e.ShoppingListUserId }, "shopping_lists_group_name_user_uindex").IsUnique();

            //Property rules
            builder.Property(e => e.ShoppingListId).HasColumnName("shopping_list_id");
            builder.Property(e => e.ShoppingListCreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("shopping_list_created_date");
            builder.Property(e => e.ShoppingListGroupId).HasColumnName("shopping_list_group_id");
            builder.Property(e => e.ShoppingListModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("shopping_list_modified_date");
            builder.Property(e => e.ShoppingListName)
                .HasMaxLength(100)
                .HasColumnName("shopping_list_name");
            builder.Property(e => e.ShoppingListUserId).HasColumnName("shopping_list_user_id");

            builder.HasOne(d => d.ShoppingListGroup).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.ShoppingListGroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shopping_lists_groups_fk");

            builder.HasOne(d => d.ShoppingListUser).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.ShoppingListUserId)
                .HasConstraintName("shopping_lists_users_fk");

            //Data-seeding
            builder.HasData([
            // Shopping lists for User 1
            new ShoppingList {
                ShoppingListId = 1,
                ShoppingListUserId = 1,
                ShoppingListName = "Lista de Compras de Pablo - Casa Atenas",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 2,
                ShoppingListUserId = 1,
                ShoppingListName = "Lista de Compras de Pablo - Donación Familia Fonseca Moncada",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 3,
                ShoppingListUserId = 1,
                ShoppingListName = "Lista de Compras de Pablo - Fiesta de Cumpleaños",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 4,
                ShoppingListUserId = 1,
                ShoppingListName = "Lista de Compras de Pablo - Picnic en el Parque",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 5,
                ShoppingListUserId = 1,
                ShoppingListName = "Lista de Compras de Pablo - Viaje de Fin de Semana",
                ShoppingListGroupId = 1,
            },

            // Shopping lists for User 2
            new ShoppingList {
                ShoppingListId = 6,
                ShoppingListUserId = 2,
                ShoppingListName = "Lista de Compras de Virginia - Compras del mes de Junio",
                ShoppingListGroupId = 2,
            },
            new ShoppingList {
                ShoppingListId = 7,
                ShoppingListUserId = 2,
                ShoppingListName = "Lista de Compras de Virginia - Fiesta de Fin de Año",
                ShoppingListGroupId = 2,
            },
            new ShoppingList {
                ShoppingListId = 8,
                ShoppingListUserId = 2,
                ShoppingListName = "Lista de Compras de Virginia - Cena Romántica",
                ShoppingListGroupId = 2,
            },
            new ShoppingList {
                ShoppingListId = 9,
                ShoppingListUserId = 2,
                ShoppingListName = "Lista de Compras de Virginia - Picnic en la Playa",
                ShoppingListGroupId = 2,
            },
            new ShoppingList {
                ShoppingListId = 10,
                ShoppingListUserId = 2,
                ShoppingListName = "Lista de Compras de Virginia - Evento Familiar",
                ShoppingListGroupId = 2,
            },

            // Shopping lists for User 3
            new ShoppingList {
                ShoppingListId = 11,
                ShoppingListUserId = 3,
                ShoppingListName = "Lista de Compras de Daniel - Semana Santa",
                ShoppingListGroupId = 3,
            },
            new ShoppingList {
                ShoppingListId = 12,
                ShoppingListUserId = 3,
                ShoppingListName = "Lista de Compras de Daniel - Navidad",
                ShoppingListGroupId = 3,
            },
            new ShoppingList {
                ShoppingListId = 13,
                ShoppingListUserId = 3,
                ShoppingListName = "Lista de Compras de Daniel - Aniversario",
                ShoppingListGroupId = 3,
            },
            new ShoppingList {
                ShoppingListId = 14,
                ShoppingListUserId = 3,
                ShoppingListName = "Lista de Compras de Daniel - Cumpleaños",
                ShoppingListGroupId = 3,
            },
            new ShoppingList {
                ShoppingListId = 15,
                ShoppingListUserId = 3,
                ShoppingListName = "Lista de Compras de Daniel - Barbacoa",
                ShoppingListGroupId = 3,
            },

            // Shopping lists for User 4
            new ShoppingList {
                ShoppingListId = 16,
                ShoppingListUserId = 4,
                ShoppingListName = "Lista de Compras de Danny - Fiesta de Verano",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 17,
                ShoppingListUserId = 4,
                ShoppingListName = "Lista de Compras de Danny - Fin de Año",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 18,
                ShoppingListUserId = 4,
                ShoppingListName = "Lista de Compras de Danny - Reunión Familiar",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 19,
                ShoppingListUserId = 4,
                ShoppingListName = "Lista de Compras de Danny - Asado",
                ShoppingListGroupId = 1,
            },
            new ShoppingList {
                ShoppingListId = 20,
                ShoppingListUserId = 4,
                ShoppingListName = "Lista de Compras de Danny - Viaje de Camping",
                ShoppingListGroupId = 1,
            }
            ]);
        }
    }
}
