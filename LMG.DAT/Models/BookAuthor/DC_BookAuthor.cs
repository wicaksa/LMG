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
        public int BookId { get; set; } 

        public int AuthorId { get; set; }
    }

    public class BookAuthorConfiguration : IEntityTypeConfiguration<DC_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<DC_BookAuthor> builder)
        {

        }
    }
}
