using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public int Phone { get; set; }
    }

    public class MemberConfiguration : IEntityTypeConfiguration<DC_Member>
    {
        public void Configure(EntityTypeBuilder<DC_Member> builder)
        {
            // Set Id's as PK's.
            builder.ToTable("Member", "Member")
                .HasKey(primaryKey => primaryKey.Id);

            // Generate new Id's when new members are added to db.
            builder.Property(m => m.Id).ValueGeneratedOnAdd(); 

            // Configure column properties.
            builder.Property(m => m.FirstName).HasMaxLength(256);
            builder.Property(m => m.LastName).HasMaxLength(256);
            builder.Property(m => m.Birthdate).HasMaxLength(16);
            builder.Property(m => m.Gender).HasMaxLength(30);
        }
    }
}
