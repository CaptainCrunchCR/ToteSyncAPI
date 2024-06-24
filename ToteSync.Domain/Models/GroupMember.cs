using System;
using System.Collections.Generic;

namespace ToteSync.Domain.Models;

public partial class GroupMember : IBaseEntity
{
    public int GroupMemberId { get; set; }

    public int GroupMemberGroupId { get; set; }

    public int GroupMemberUserId { get; set; }

    public virtual Group GroupMemberGroup { get; set; } = null!;

    public virtual User GroupMemberUser { get; set; } = null!;

    public int Id => GroupMemberId;
}
