using System;
using System.Collections.Generic;

namespace ToteSync.Domain;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserFirstLastName { get; set; } = null!;

    public string? UserSecondLastName { get; set; }

    public bool UserIsActive { get; set; }

    public DateOnly UserBirthdate { get; set; }

    public string UserEmail { get; set; } = null!;

    public string? UserAvatarUrl { get; set; }

    public string UserPhoneNumber { get; set; } = null!;

    public int UserZipCode { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}
