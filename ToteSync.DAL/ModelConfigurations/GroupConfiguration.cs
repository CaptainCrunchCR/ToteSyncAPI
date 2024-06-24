using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToteSync.Domain.Models;

namespace ToteSync.DAL.ModelConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //Basic parameters
            builder.HasKey(e => e.GroupId).HasName("groups_pk");
            builder.ToTable("groups", "tote");

            //Property rules
            builder.Property(e => e.GroupId).HasColumnName("group_id");
            builder.Property(e => e.GroupCreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("group_created_date");
            builder.Property(e => e.GroupModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnName("group_modified_date");
            builder.Property(e => e.GroupName)
                .HasMaxLength(150)
                .HasColumnName("group_name");

            //Data-seeding
            builder.HasData([
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
        }
    }
}
