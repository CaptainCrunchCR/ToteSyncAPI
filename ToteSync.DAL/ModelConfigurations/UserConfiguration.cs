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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Basic parameters
            builder.HasKey(e => e.UserId).HasName("users_pk");
            builder.ToTable("users", "tote");

            builder.HasIndex(e => e.UserEmail, "users_user_email_uindex").IsUnique();
            builder.HasIndex(e => e.UserPhoneNumber, "users_user_phone_number_uindex").IsUnique();

            //Property rules
            builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.Property(e => e.UserAvatarUrl)
                .HasMaxLength(255)
                .HasColumnName("user_avatar_url");
            builder.Property(e => e.UserBirthdate).HasColumnName("user_birthdate");
            builder.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");
            builder.Property(e => e.UserFirstLastName)
                .HasMaxLength(200)
                .HasColumnName("user_first_last_name");
            builder.Property(e => e.UserIsActive).HasColumnName("user_is_active");
            builder.Property(e => e.UserName)
                .HasMaxLength(200)
                .HasColumnName("user_name");
            builder.Property(e => e.UserPhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("user_phone_number");
            builder.Property(e => e.UserSecondLastName)
                .HasMaxLength(200)
                .HasColumnName("user_second_last_name");
            builder.Property(e => e.UserZipCode).HasColumnName("user_zip_code");

            //Data-seeding
            builder.HasData([
                new User {
                    UserId = 1,
                    UserName = "Pablo",
                    UserFirstLastName = "Fonseca",
                    UserSecondLastName = "Moncada",
                    UserPhoneNumber = "87719888",
                    UserZipCode = 506,
                    UserAvatarUrl = "https://www.google.com/",
                    UserBirthdate = new DateOnly(2001, 05, 14),
                    UserEmail = "pablo.fonsecam@outlook.com",
                    UserIsActive = true },
                new User {
                    UserId = 2,
                    UserName = "Virginia",
                    UserFirstLastName = "Mata",
                    UserSecondLastName = "Perez",
                    UserPhoneNumber = "72892168",
                    UserZipCode = 506,
                    UserAvatarUrl = "https://www.fakephoto.com/",
                    UserBirthdate = new DateOnly(2003, 06, 03),
                    UserEmail = "perezvirginia889@gmail.com",
                    UserIsActive = true
                },
                new User {
                    UserId = 3,
                    UserName = "Daniel",
                    UserFirstLastName = "Quintana",
                    UserSecondLastName = "Medina",
                    UserPhoneNumber = "70068596",
                    UserZipCode = 506,
                    UserAvatarUrl = "https://www.fakecatphoto.com/",
                    UserBirthdate = new DateOnly (1989, 05, 30),
                    UserEmail = "daniel.bleach1@gmail.com",
                    UserIsActive = true

                },
                new User {
                    UserId = 4,
                    UserName = "Danny",
                    UserFirstLastName = "Fonseca",
                    UserSecondLastName = "Trejos",
                    UserPhoneNumber = "83030630",
                    UserZipCode = 506,
                    UserAvatarUrl = "https://www.fakephoto.com/",
                    UserBirthdate = new DateOnly (1973, 10, 23),
                    UserEmail = "dafotr@outlook.com",
                    UserIsActive = true
                }
            ]);
        }
    }
}
