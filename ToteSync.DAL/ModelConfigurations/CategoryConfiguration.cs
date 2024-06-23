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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Basic parameters
            builder.HasKey(e => e.CategoryId).HasName("categories_pk");
            builder.ToTable("categories", "tote");

            //Property rules
            builder.Property(e => e.CategoryId).HasColumnName("category_id");
            builder.Property(e => e.CategoryDescription)
                .HasMaxLength(200)
                .HasColumnName("category_description");
            builder.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .HasColumnName("category_name");
            builder.Property(e => e.CategoryUserId).HasColumnName("category_user_id");

            builder.HasOne(d => d.CategoryUser).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CategoryUserId)
                .HasConstraintName("categories_users_user_id_fk");

            //Data-seeding
            builder.HasData([
                new Category {
                CategoryId = 1,
                CategoryName = "Verduras",
                CategoryUserId = 1,
            },
            new Category {
                CategoryId = 2,
                CategoryName = "Frutas",
                CategoryUserId = 1,
            },
            new Category {
                CategoryId = 3,
                CategoryName = "Carnes",
                CategoryUserId = 1,
            },
            new Category {
                CategoryId = 4,
                CategoryName = "Lácteos",
                CategoryUserId = 1,
            },
            new Category {
                CategoryId = 5,
                CategoryName = "Granos",
                CategoryUserId = 1,
            },
            new Category {
                CategoryId = 6,
                CategoryName = "Bebidas",
                CategoryUserId = 2,
            },
            new Category {
                CategoryId = 7,
                CategoryName = "Panadería",
                CategoryUserId = 2,
            },
            new Category {
                CategoryId = 8,
                CategoryName = "Pescados",
                CategoryUserId = 2,
            },
            new Category {
                CategoryId = 9,
                CategoryName = "Aceites",
                CategoryUserId = 2,
            },
            new Category {
                CategoryId = 10,
                CategoryName = "Snacks",
                CategoryUserId = 2,
            },

            new Category {
                CategoryId = 11,
                CategoryName = "Condimentos",
                CategoryUserId = 3,
            },
            new Category {
                CategoryId = 12,
                CategoryName = "Cereales",
                CategoryUserId = 3,
            },
            new Category {
                CategoryId = 13,
                CategoryName = "Dulces",
                CategoryUserId = 3,
            },
            new Category {
                CategoryId = 14,
                CategoryName = "Helados",
                CategoryUserId = 3,
            },
            new Category {
                CategoryId = 15,
                CategoryName = "Pastas",
                CategoryUserId = 3,
            },
            new Category {
                CategoryId = 16,
                CategoryName = "Legumbres",
                CategoryUserId = 4,
            },
            new Category {
                CategoryId = 17,
                CategoryName = "Especias",
                CategoryUserId = 4,
            },
            new Category {
                CategoryId = 18,
                CategoryName = "Bebidas alcohólicas",
                CategoryUserId = 4,
            },
            new Category {
                CategoryId = 19,
                CategoryName = "Conservas",
                CategoryUserId = 4,
            },
            new Category {
                CategoryId = 20,
                CategoryName = "Salsas",
                CategoryUserId = 4,
            }
           ]);
        }
    }
}
