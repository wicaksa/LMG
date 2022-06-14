using LMG.DAT.Models.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Series
{
    public class DC_Series : DataContextBase
    {
        // Attributes
        public int AuthorId { get; set; }
        public string SeriesName { get; set; }
        public int TotalBooks { get; set; }

        //Relationship
        [JsonIgnore]
        public List<DC_Book>? Books { get; set; }
    }

    public class SeriesConfiguration : IEntityTypeConfiguration<DC_Series>
    {
        public void Configure(EntityTypeBuilder<DC_Series> builder)
        {
            // Create Pk's
            builder.ToTable("Series", "Series")
                .HasKey(m => m.Id);

            // Relationship
            builder.HasMany(s => s.Books).WithOne(s => s.Serie);

            // Column Properties
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.SeriesName).HasMaxLength(1024);

            // Seed Data
            builder.HasData(
                new DC_Series
                {
                    Id = 1,
                    AuthorId = 1,
                    SeriesName = "Harry Potter",
                    TotalBooks = 7
                }
            );

        }
    }
}
