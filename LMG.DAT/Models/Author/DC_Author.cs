using LMG.DAT.Models.BookAuthor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Author
{
    public class DC_Author : DataContextBase
    {
        // Attributes
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Description { get; set; }

        public string Dob { get; set; } = null!; // Date of birth

        public string? Dod { get; set; } // Date of death

        // Relationships
        public List<DC_BookAuthor> BookAuthors { get; set; }
    }

    public class AuthorConfiguration : IEntityTypeConfiguration<DC_Author>
    {
        public void Configure(EntityTypeBuilder<DC_Author> builder)
        {

            // Set Id as PKs.
            builder.ToTable("Author", "Author")
                .HasKey(primaryKey => primaryKey.Id);

            // Relationship
            builder.HasMany(a => a.BookAuthors).WithOne(a => a.Author);

            // Create new Id's when new authors are added to db.
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            // Configure column properties.
            builder.Property(m => m.FirstName).HasMaxLength(64);
            builder.Property(m => m.LastName).HasMaxLength(64);
            builder.Property(m => m.Description).HasMaxLength(2048);
            builder.Property(m => m.Dob).HasMaxLength(16);
            builder.Property(m => m.Dod).HasMaxLength(16);
        }
    }
}
