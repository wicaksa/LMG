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
        // Attributes
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public string Review { get; set; }

        // Relationship
        public DC_Book Book { get; set; }
    }

    public class ReviewConfiguration : IEntityTypeConfiguration<DC_Review>
    {
        public void Configure(EntityTypeBuilder<DC_Review> builder)
        {
            // Set Ids as PK.
            builder.ToTable("Review", "Review")
                .HasKey(m => m.Id);

            // Relationship.
            builder.HasOne(r => r.Book).WithMany(r => r.Reviews);

            // Set column properties.
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Review).HasMaxLength(2048);
        }
    }
}
