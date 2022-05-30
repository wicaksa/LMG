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
    }

    public class BookConfiguration : IEntityTypeConfiguration<DC_Book>
    {
        public void Configure(EntityTypeBuilder<DC_Book> builder)
        {
            // Set Id's as PK.
            builder.ToTable("Book", "Book")
                .HasKey(primaryKey => primaryKey.Id);

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
