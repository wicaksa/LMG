using LMG.DAT.Models.Book;
using LMG.DAT.Models.Member;
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
        public DC_Member? Members { get; set; }
    }

    public class BorrowConfiguration : IEntityTypeConfiguration<DC_Borrow>
    {
        public void Configure(EntityTypeBuilder<DC_Borrow> builder)
        {
            // Set Id's as PK
            builder.ToTable("Borrow", "Borrow")
                .HasKey(m => m.Id);

            // Relationship
            builder.HasOne(b => b.Book).WithMany(b => b.Borrows);

            // Column Properties
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.BorrowDate).HasMaxLength(16);

			// Seed Data
			builder.HasData(

				new DC_Borrow
				{
					Id = 1,
					BookId = 1,
					MemberId = 1,
					BorrowDate = "05/17/2022"
				},

				new DC_Borrow
				{
					Id = 2,
					BookId = 1,
					MemberId = 2,
					BorrowDate = "05/12/2022"
				},

				new DC_Borrow
				{
					Id = 3,
					BookId = 2,
					MemberId = 1,
					BorrowDate = "05/17/2022"
				},

				new DC_Borrow
				{
					Id = 4,
					BookId = 3,
					MemberId = 3,
					BorrowDate = "05/10/2022"
				},

				new DC_Borrow
				{
					Id = 5,
					BookId = 4,
					MemberId = 1,
					BorrowDate = "05/17/2022"
				},

				new DC_Borrow
				{
					Id = 6,
					BookId = 5,
					MemberId = 4,
					BorrowDate = "05/09/2022"
				}
			);
		}
    }
}
