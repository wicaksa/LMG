using LMG.DAT.Models.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Borrow
{
    public class DC_Borrow : DataContextBase
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public string BorrowDate { get; set; }

        //Relationship
        public DC_Book Book { get; set; }
    }

    public class BorrowConfiguration : IEntityTypeConfiguration<DC_Borrow>
    {
        public void Configure(EntityTypeBuilder<DC_Borrow> builder)
        {
            builder.ToTable("Borrow", "Borrow")
                .HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.BorrowDate).HasMaxLength(16);

        }
    }
}
