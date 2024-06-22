using System;
using System.Collections.Generic;

namespace ToteSync.Domain;

public partial class ShoppingList
{
    public int ShoppingListId { get; set; }

    public int ShoppingListUserId { get; set; }

    public string ShoppingListName { get; set; } = null!;

    public DateTime ShoppingListCreatedDate { get; set; }

    public DateTime ShoppingListModifiedDate { get; set; }

    public int ShoppingListGroupId { get; set; }

    public virtual Group ShoppingListGroup { get; set; } = null!;

    public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();

    public virtual User ShoppingListUser { get; set; } = null!;
}
