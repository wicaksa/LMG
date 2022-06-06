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

            // Seed Data
            builder.HasData(
                new DC_Author

                {
                    Id = 1,
                    FirstName = "J.K.",
                    LastName = "Rowling",
                    Description = "Joanne Rowling, also known by her pen name " +
                    "J. K. Rowling, is a British author and philanthropist. She " +
                    "wrote a seven-volume children's fantasy series, Harry Potter," +
                    " published from 1997 to 2007.",
                    Dob = "07/31/1965",
                    Dod = null,
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                },

                new DC_Author
                {
                    Id = 2,
                    FirstName = "J.D.",
                    LastName = "Sallinger",
                    Description = "Jerome David Salinger was an American author " +
                    "best known for his 1951 novel The Catcher in the Rye. Before " +
                    "its publication, Salinger published several short stories in " +
                    "Story magazine and served in World War II.",
                    Dob = "01/01/1919",
                    Dod = "01/27/2010",
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                },

                new DC_Author

                {
                    Id = 3,
                    FirstName = "Chinua",
                    LastName = "Achebe",
                    Description = "Chinua Achebe was a Nigerian novelist, poet, and " +
                    "critic who is regarded as the dominant figure of modern African " +
                    "literature. His first novel and magnum opus, Things Fall Apart," +
                    " occupies a pivotal place in African literature and remains the " +
                    "most widely studied, translated and read African novel.",
                    Dob = "11/16/1930",
                    Dod = "03/21/2013",
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                },

                new DC_Author

                {
                    Id = 4,
                    FirstName = "Alice",
                    LastName = "Waters",
                    Description = "Alice Louise Waters is an American chef, restaurateur, " +
                    "and author. In 1971 she opened Chez Panisse, a Berkeley, California " +
                    "restaurant famous for its role in creating the farm-to-table movement " +
                    "and for pioneering California cuisine.",
                    Dob = "04/28/1944",
                    Dod = null,
                    CreatedBy = "Me",
                    ModifiedBy = "Me"
                }
           );

        }
    }
}
