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
        public List<DC_Review>? Reviews { get; set; }
        public DC_Series Serie { get; set; }
        public List<DC_Borrow>? Borrows { get; set; }
        public List<DC_BookAuthor>? BookAuthors { get; set; }
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
            
            // Seed Data
            builder.HasData(
                new DC_Book
                {
                    Id = 1,
                    Title = "Harry Potter & The Socerer's Stone",
                    Copies = 3,
                    Series = "Harry Potter",
                    Edition = 1,
                    Genre = "Fantasy",
                    Summary = "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.",
                    PublicationYear = 1997
                },

                new DC_Book
                {
                    Id = 2,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Copies = 3,
                    Series = "Harry Potter",
                    Edition = 1,
                    Genre = "Fantasy",
                    Summary = "The second instalment of boy wizard Harry Potter's adventures at Hogwarts School of Witchcraft and Wizardry, based on the novel by JK Rowling. A mysterious elf tells Harry to expect trouble during his second year at Hogwarts, but nothing can prepare him for trees that fight back, flying cars, spiders that talk and deadly warnings written in blood on the walls of the school.",
                    PublicationYear = 1998
                },

                new DC_Book
                {
                    Id = 3,
                    Title = "The Catcher in the Rye",
                    Copies = 5,
                    Series = "N/A",
                    Edition = 1,
                    Genre = "Fiction",
                    Summary = "The novel details two days in the life of 16-year-old Holden Caulfield after he has been expelled from prep school. Confused and disillusioned, Holden searches for truth and rails against the phoniness of the adult world.",
                    PublicationYear = 1951
                },

                new DC_Book
                {
                    Id = 4,
                    Title = "Things Fall Apart",
                    Copies = 5,
                    Series = "N/A",
                    Edition = 1,
                    Genre = "Fiction",
                    Summary = "Things Fall Apart is the debut novel by Nigerian author Chinua Achebe, first published in 1958. It depicts pre-colonial life in the southeastern part of Nigeria and the invasion by Europeans during the late 19th century. ",
                    PublicationYear = 1958
                },

                new DC_Book
                {
                    Id = 5,
                    Title = "We Are What We Eat: A Slow Food Manifesto",
                    Copies = 2,
                    Series = "N/A",
                    Edition = 1,
                    Genre = "Non-Fiction",
                    Summary = "Since opening Chez Panisse in 1971, Alice Waters has been a kind of living legend in the movement for local food, sustainable agriculture, and seasonal cooking. In her latest work, she recounts scenes from that career that fans of hers will enjoy while championing a slow food approach to farming and eating, with an emphasis on regenerative agriculture, biodiversity, and health.",
                    PublicationYear = 2021
                }
            );
        }
    }
}
