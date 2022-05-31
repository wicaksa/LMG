using LMG.DAT.Models.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Series
{
    public class DC_Series : DataContextBase
    {
        public int authorId { get; set; }
        public string SeriesName { get; set; }
        public int TotalBooks { get; set; }

        //Relationship
        public List<DC_Book> Books { get; set; }
    }

    public class SeriesConfiguration : IEntityTypeConfiguration<DC_Series>
    {
        public void Configure(EntityTypeBuilder<DC_Series> builder)
        {
            builder.ToTable("Series", "Series")
                .HasKey(m => m.Id);

            //Relationship
            builder.HasMany(s => s.Books).WithOne(s => s.Serie);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.SeriesName).HasMaxLength(1024);
        }
    }
}
