using System;
using System.Collections.Generic;

namespace ToteSync.Domain;

public partial class ShoppingListItem
{
    public int ShoppingListItemId { get; set; }

    public int ShoppingListItemShoppingListId { get; set; }

    public int ShoppingListItemItemId { get; set; }

    public int ShoppingListItemQuantity { get; set; }

    public string? ShoppingListItemNotes { get; set; }

    public virtual Item ShoppingListItemItem { get; set; } = null!;

    public virtual ShoppingList ShoppingListItemShoppingList { get; set; } = null!;
}
