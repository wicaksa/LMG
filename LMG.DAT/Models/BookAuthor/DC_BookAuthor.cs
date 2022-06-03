using LMG.DAT.Models.Author;
using LMG.DAT.Models.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Models.BookAuthor
{
    public class DC_BookAuthor : DataContextBase
    {

        //Attributes
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        //Relationships
        public DC_Book Book { get; set; } 

        public DC_Author Author { get; set; }
    }

    public class BookAuthorConfiguration : IEntityTypeConfiguration<DC_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<DC_BookAuthor> builder)
        {
            // Relationship
            builder.HasOne(b => b.Book).WithMany(b => b.BookAuthors);

			// Seed Data
			builder.HasData(
				new DC_BookAuthor
				{
					Id = 1,
					AuthorId = 1,
					BookId = 1
				},

				new DC_BookAuthor
				{
					Id = 2,
					AuthorId = 1,
					BookId = 2
				},

				new DC_BookAuthor
				{
					Id = 3,
					AuthorId = 2,
					BookId = 3
				},

				new DC_BookAuthor
				{
					Id = 4,
					AuthorId = 3,
					BookId = 4
				},

				new DC_BookAuthor
				{
					Id = 5,
					AuthorId = 4,
					BookId = 5
				}
			);
		}
    }
}
