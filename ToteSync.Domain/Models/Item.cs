using System;
using System.Collections.Generic;

namespace ToteSync.Domain.Models;

public partial class Item : IBaseEntity
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public int? ItemCategoryId { get; set; }

    public int ItemUserId { get; set; }

    public DateTime ItemCreatedDate { get; set; }

    public DateTime ItemModifiedDate { get; set; }

    public virtual Category? ItemCategory { get; set; }

    public virtual User ItemUser { get; set; } = null!;

    public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();

    public int Id => ItemId;
}
