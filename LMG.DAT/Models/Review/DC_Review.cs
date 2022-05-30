using LMG.DAT.Models.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Review
{
    public class DC_Review : DataContextBase
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public string Review { get; set; }
        public DC_Book Book { get; set; }
    }

    public class ReviewConfiguration : IEntityTypeConfiguration<DC_Review>
    {
        public void Configure(EntityTypeBuilder<DC_Review> builder)
        {
            builder.ToTable("Review", "Review")
                .HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Review).HasMaxLength(2048);
        }
    }
}
