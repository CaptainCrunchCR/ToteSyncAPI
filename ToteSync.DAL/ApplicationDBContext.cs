using Microsoft.EntityFrameworkCore;
using ToteSync.Domain;

namespace ToteSync.DAL;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupMember> GroupMembers { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }

    public virtual DbSet<ShoppingListItem> ShoppingListItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categories_pk");

            entity.ToTable("categories", "tote");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(200)
                .HasColumnName("category_description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .HasColumnName("category_name");
            entity.Property(e => e.CategoryUserId).HasColumnName("category_user_id");

            entity.HasOne(d => d.CategoryUser).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CategoryUserId)
                .HasConstraintName("categories_users_user_id_fk");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("groups_pk");

            entity.ToTable("groups", "tote");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupCreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("group_created_date");
            entity.Property(e => e.GroupModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("group_modified_date");
            entity.Property(e => e.GroupName)
                .HasMaxLength(150)
                .HasColumnName("group_name");
        });

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.HasKey(e => e.GroupMemberId).HasName("group_members_pk");

            entity.ToTable("group_members", "tote");

            entity.HasIndex(e => new { e.GroupMemberUserId, e.GroupMemberGroupId }, "group_members_user_group_uindex").IsUnique();

            entity.Property(e => e.GroupMemberId).HasColumnName("group_member_id");
            entity.Property(e => e.GroupMemberGroupId).HasColumnName("group_member_group_id");
            entity.Property(e => e.GroupMemberUserId).HasColumnName("group_member_user_id");

            entity.HasOne(d => d.GroupMemberGroup).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.GroupMemberGroupId)
                .HasConstraintName("group_members_groups_fk");

            entity.HasOne(d => d.GroupMemberUser).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.GroupMemberUserId)
                .HasConstraintName("group_members_users_fk");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("items_pk");

            entity.ToTable("items", "tote");

            entity.HasIndex(e => new { e.ItemCategoryId, e.ItemUserId, e.ItemName }, "items_category_user_name_uindex")
                .IsUnique()
                .HasFilter("(item_category_id IS NOT NULL)");

            entity.HasIndex(e => new { e.ItemUserId, e.ItemName }, "items_user_name_uindex")
                .IsUnique()
                .HasFilter("(item_category_id IS NULL)");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.ItemCategoryId).HasColumnName("item_category_id");
            entity.Property(e => e.ItemCreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("item_created_date");
            entity.Property(e => e.ItemModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("item_modified_date");
            entity.Property(e => e.ItemName)
                .HasMaxLength(150)
                .HasColumnName("item_name");
            entity.Property(e => e.ItemUserId).HasColumnName("item_user_id");

            entity.HasOne(d => d.ItemCategory).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("items_categories_fk");

            entity.HasOne(d => d.ItemUser).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemUserId)
                .HasConstraintName("items_users_fk");
        });

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.ShoppingListId).HasName("shopping_lists_pk");

            entity.ToTable("shopping_lists", "tote");

            entity.HasIndex(e => new { e.ShoppingListGroupId, e.ShoppingListName, e.ShoppingListUserId }, "shopping_lists_group_name_user_uindex").IsUnique();

            entity.Property(e => e.ShoppingListId).HasColumnName("shopping_list_id");
            entity.Property(e => e.ShoppingListCreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("shopping_list_created_date");
            entity.Property(e => e.ShoppingListGroupId).HasColumnName("shopping_list_group_id");
            entity.Property(e => e.ShoppingListModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("shopping_list_modified_date");
            entity.Property(e => e.ShoppingListName)
                .HasMaxLength(100)
                .HasColumnName("shopping_list_name");
            entity.Property(e => e.ShoppingListUserId).HasColumnName("shopping_list_user_id");

            entity.HasOne(d => d.ShoppingListGroup).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.ShoppingListGroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shopping_lists_groups_fk");

            entity.HasOne(d => d.ShoppingListUser).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.ShoppingListUserId)
                .HasConstraintName("shopping_lists_users_fk");
        });

        modelBuilder.Entity<ShoppingListItem>(entity =>
        {
            entity.HasKey(e => e.ShoppingListItemId).HasName("shopping_list_items_pk");

            entity.ToTable("shopping_list_items", "tote");

            entity.HasIndex(e => new { e.ShoppingListItemItemId, e.ShoppingListItemShoppingListId }, "shopping_list_items_item_list_uindex").IsUnique();

            entity.Property(e => e.ShoppingListItemId).HasColumnName("shopping_list_item_id");
            entity.Property(e => e.ShoppingListItemItemId).HasColumnName("shopping_list_item_item_id");
            entity.Property(e => e.ShoppingListItemNotes)
                .HasMaxLength(255)
                .HasColumnName("shopping_list_item_notes");
            entity.Property(e => e.ShoppingListItemQuantity)
                .HasDefaultValue(0)
                .HasColumnName("shopping_list_item_quantity");
            entity.Property(e => e.ShoppingListItemShoppingListId).HasColumnName("shopping_list_item_shopping_list_id");

            entity.HasOne(d => d.ShoppingListItemItem).WithMany(p => p.ShoppingListItems)
                .HasForeignKey(d => d.ShoppingListItemItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("shopping_list_items_items_fk");

            entity.HasOne(d => d.ShoppingListItemShoppingList).WithMany(p => p.ShoppingListItems)
                .HasForeignKey(d => d.ShoppingListItemShoppingListId)
                .HasConstraintName("shopping_list_items_shopping_lists_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pk");

            entity.ToTable("users", "tote");

            entity.HasIndex(e => e.UserEmail, "users_user_email_uindex").IsUnique();

            entity.HasIndex(e => e.UserPhoneNumber, "users_user_phone_number_uindex").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserAvatarUrl)
                .HasMaxLength(255)
                .HasColumnName("user_avatar_url");
            entity.Property(e => e.UserBirthdate).HasColumnName("user_birthdate");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");
            entity.Property(e => e.UserFirstLastName)
                .HasMaxLength(200)
                .HasColumnName("user_first_last_name");
            entity.Property(e => e.UserIsActive).HasColumnName("user_is_active");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("user_phone_number");
            entity.Property(e => e.UserSecondLastName)
                .HasMaxLength(200)
                .HasColumnName("user_second_last_name");
            entity.Property(e => e.UserZipCode).HasColumnName("user_zip_code");
        });

        //Data-Seeding for User Entity
        modelBuilder.Entity<User>().HasData([
            new User {
                UserId = 1,
                UserName = "Pablo",
                UserFirstLastName = "Fonseca",
                UserSecondLastName = "Moncada",
                UserPhoneNumber = "87719888",
                UserZipCode = 506,
                UserAvatarUrl = "https://www.google.com/",
                UserBirthdate = new DateOnly(2001, 05, 14),
                UserEmail = "pablo.fonsecam@outlook.com",
                UserIsActive = true },
            new User {
                UserId = 2,
                UserName = "Virginia",
                UserFirstLastName = "Mata",
                UserSecondLastName = "Perez",
                UserPhoneNumber = "72892168",
                UserZipCode = 506,
                UserAvatarUrl = "https://www.fakephoto.com/",
                UserBirthdate = new DateOnly(2003, 06, 03),
                UserEmail = "perezvirginia889@gmail.com",
                UserIsActive = true
            },
            new User {
                UserId = 3,
                UserName = "Daniel",
                UserFirstLastName = "Quintana",
                UserSecondLastName = "Medina",
                UserPhoneNumber = "70068596",
                UserZipCode = 506,
                UserAvatarUrl = "https://www.fakecatphoto.com/",
                UserBirthdate = new DateOnly (1989, 05, 30),
                UserEmail = "daniel.bleach1@gmail.com",
                UserIsActive = true

            },
            new User {
                UserId = 4,
                UserName = "Danny",
                UserFirstLastName = "Fonseca",
                UserSecondLastName = "Trejos",
                UserPhoneNumber = "83030630",
                UserZipCode = 506,
                UserAvatarUrl = "https://www.fakephoto.com/",
                UserBirthdate = new DateOnly (1973, 10, 23),
                UserEmail = "dafotr@outlook.com",
                UserIsActive = true
            }
            ]);

        //Data-Seeding for Category
        modelBuilder.Entity<Category>().HasData([
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

        //Data-Seeding for Group Entity
        modelBuilder.Entity<Group>().HasData([
            new Group {
                GroupId = 1,
                GroupName = "Familia Fonseca Moncada"
            },
            new Group {
                GroupId = 2,
                GroupName = "Familia Fonseca Mata"
            },
            new Group {
                GroupId = 3,
                GroupName = "Familia Quintana Perez"
            }
            ]);

        //Data-Seeding for Group Member Entity
        modelBuilder.Entity<GroupMember>().HasData([
            new GroupMember {
                GroupMemberId = 1,
                GroupMemberUserId = 1,
                GroupMemberGroupId = 1,
            },
            new GroupMember {
                GroupMemberId = 2,
                GroupMemberUserId = 4,
                GroupMemberGroupId = 1,
            },
            new GroupMember {
                GroupMemberId = 3,
                GroupMemberUserId = 1,
                GroupMemberGroupId = 2,
            },
            new GroupMember {
                GroupMemberId = 4,
                GroupMemberUserId = 2,
                GroupMemberGroupId = 2,
            },
            new GroupMember {
                GroupMemberId = 5,
                GroupMemberUserId = 2,
                GroupMemberGroupId = 3,
            },
            new GroupMember {
                GroupMemberId = 6,
                GroupMemberUserId = 3,
                GroupMemberGroupId = 3,
            },
            ]);

        //Data-Seeding for Item Entity
        modelBuilder.Entity<Item>().HasData([
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

        //Data-Seeding for ShoppingList Entity
        modelBuilder.Entity<ShoppingList>().HasData([
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

        //Data-Seeding for ShoppingListItem Entity
        modelBuilder.Entity<ShoppingListItem>().HasData([
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


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
