using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Reservation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Member
{
    public class DC_Member : DataContextBase
    {

        // Attributes 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Birthdate { get; set; } = null!;
        public string? Gender { get; set; }
        public long Phone { get; set; }

        // Relationship
        [JsonIgnore]
        public List<DC_Borrow> Borrows { get; set; }
        [JsonIgnore]
        public List <DC_Reservation> Reservations { get; set; }

    }

    public class MemberConfiguration : IEntityTypeConfiguration<DC_Member>
    {
        public void Configure(EntityTypeBuilder<DC_Member> builder)
        {
            // Set Id's as PK's.
            builder.ToTable("Member", "Member")
                .HasKey(primaryKey => primaryKey.Id);

            // Relationship.
            builder.HasMany(m => m.Borrows).WithOne(m => m.Member);
            builder.HasMany(m => m.Reservations).WithOne(m => m.Member);

            // Generate new Id's when new members are added to db.
            builder.Property(m => m.Id).ValueGeneratedOnAdd(); 

            // Configure column properties.
            builder.Property(m => m.FirstName).HasMaxLength(256);
            builder.Property(m => m.LastName).HasMaxLength(256);
            builder.Property(m => m.Birthdate).HasMaxLength(16);
            builder.Property(m => m.Gender).HasMaxLength(30);

            // Seed Data
            builder.HasData(
                new DC_Member
                {
                    Id = 1,
                    FirstName = "Earl",
                    LastName = "Stevens",
                    Birthdate = "11/15/1967",
                    Gender = "Male",
                    Phone = 8312124438
                },

                new DC_Member
                {
                    Id = 2,
                    FirstName = "Todd",
                    LastName = "Shaw",
                    Birthdate = "04/28/1966",
                    Gender = "Male",
                    Phone = 8315142982
                },

                new DC_Member
                {
                    Id = 3,
                    FirstName = "Kimberly",
                    LastName = "Jones",
                    Birthdate = "07/11/1974",
                    Gender = "Female",
                    Phone = 8316554577
                },

                new DC_Member
                {
                    Id = 4,
                    FirstName = "Khalif",
                    LastName = "Malek",
                    Birthdate = "07/07/1993",
                    Gender = "Male",
                    Phone = 8054243108
                },

                new DC_Member
                {
                    Id = 5,
                    FirstName = "Amala",
                    LastName = "Dlamini",
                    Birthdate = "11/21/1995",
                    Gender = "Female",
                    Phone = 8052629749
                }
            );
        }
    }
}
