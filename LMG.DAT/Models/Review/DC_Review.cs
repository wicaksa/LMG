using LMG.DAT.Models.Book;
using LMG.DAT.Models.Member;
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
        public DC_Member Member { get; set; }
    }

    public class ReviewConfiguration : IEntityTypeConfiguration<DC_Review>
    {
        public void Configure(EntityTypeBuilder<DC_Review> builder)
        {
            // Set Ids as PK.
            builder.ToTable("Review", "Review")
                .HasKey(m => m.Id);

            // Relationship.
            // builder.HasOne(r => r.Book).WithMany(r => r.Reviews);

            // Set column properties.
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Review).HasMaxLength(2048);

            // Seed Data
            builder.HasData(
                new DC_Review
                {
                    Id = 1,
                    BookId = 1,
                    MemberId = 1,
                    Review = "This book was great."
                },

                new DC_Review
                {
                    Id = 2,
                    BookId = 1,
                    MemberId = 2,
                    Review = "This book was bad."
                },

                new DC_Review
                {
                    Id = 3,
                    BookId = 2,
                    MemberId = 3,
                    Review = "Amazing book!"
                },

                new DC_Review
                {
                    Id = 4,
                    BookId = 4,
                    MemberId = 4,
                    Review = "Snooze fest."
                }
            );
        }
    }
}
