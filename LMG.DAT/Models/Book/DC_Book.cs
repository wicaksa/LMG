using LMG.DAT.Models.BookAuthor;
using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Review;
using LMG.DAT.Models.Series;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Book
{
    public class DC_Book : DataContextBase
    {
        // Attributes
        public string Title { get; set; } = null!;

        public int Copies { get; set; }

        public string? Series { get; set; }

        public int Edition { get; set; }

        public string? Genre { get; set; }

        public string? Summary { get; set; }

        public int PublicationYear { get; set; }

        //Relationships
        public List<DC_Review> Reviews { get; set; }
        public DC_Series Serie { get; set; }
        public List<DC_Borrow> Borrows { get; set; }
        public List<DC_BookAuthor> BookAuthors { get; set; }
    }

    public class BookConfiguration : IEntityTypeConfiguration<DC_Book>
    {
        public void Configure(EntityTypeBuilder<DC_Book> builder)
        {
            // Set Id's as PK.
            builder.ToTable("Book", "Book")
                .HasKey(primaryKey => primaryKey.Id);

            // Relationship
            builder.HasMany(b => b.Borrows).WithOne(b => b.Book);

            // Generate PKs when books are added to db.
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            // Configure column properties.
            builder.Property(m => m.Title).HasMaxLength(1024); 
            builder.Property(m => m.Series).HasMaxLength(1024);
            builder.Property(m => m.Genre).HasMaxLength(512);
            builder.Property(m => m.Summary).HasMaxLength(2048);
        }
    }
}
