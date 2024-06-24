using System;
using System.Collections.Generic;

namespace ToteSync.Domain.Models;

public partial class Group : IBaseEntity
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public DateTime GroupCreatedDate { get; set; }

    public DateTime? GroupModifiedDate { get; set; }

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();

    public int Id => GroupId;
}
