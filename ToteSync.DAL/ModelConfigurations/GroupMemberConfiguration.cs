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
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            //Basic parameters
            builder.HasKey(e => e.GroupMemberId).HasName("group_members_pk");
            builder.ToTable("group_members", "tote");

            builder.HasIndex(e => new { e.GroupMemberUserId, e.GroupMemberGroupId }, "group_members_user_group_uindex").IsUnique();

            //Property rules
            builder.Property(e => e.GroupMemberId).HasColumnName("group_member_id");
            builder.Property(e => e.GroupMemberGroupId).HasColumnName("group_member_group_id");
            builder.Property(e => e.GroupMemberUserId).HasColumnName("group_member_user_id");

            builder.HasOne(d => d.GroupMemberGroup).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.GroupMemberGroupId)
                .HasConstraintName("group_members_groups_fk");

            builder.HasOne(d => d.GroupMemberUser).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.GroupMemberUserId)
                .HasConstraintName("group_members_users_fk");

            //Data-seeding
            builder.HasData([
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
        }
    }
}
