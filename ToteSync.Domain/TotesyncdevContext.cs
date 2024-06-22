using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToteSync.Domain;

public partial class TotesyncdevContext : DbContext
{
    public TotesyncdevContext()
    {
    }

    public TotesyncdevContext(DbContextOptions<TotesyncdevContext> options)
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
