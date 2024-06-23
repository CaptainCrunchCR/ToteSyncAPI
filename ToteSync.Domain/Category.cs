using System;
using System.Collections.Generic;

namespace ToteSync.Domain;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public int CategoryUserId { get; set; }

    public virtual User CategoryUser { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
