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
        public DateTime BorrowDate { get; set; }
		public DateTime DueDate { get; set; }	
		public DateTime? ReturnDate { get; set; }
		public String Status { get; set; }

        //Relationship
        public DC_Book Book { get; set; }
        public DC_Member Member { get; set; }
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
			builder.Property(m => m.Status).HasMaxLength(16); // "Good" , "Overdue", "Returned"

			// Seed Data
			builder.HasData(

				new DC_Borrow
				{
					Id = 1,
					BookId = 1,
					MemberId = 1,
					BorrowDate = new DateTime(2022, 1, 1),
					ReturnDate = new DateTime(2022, 1, 8),
					Status = "Good"
				},

				new DC_Borrow
				{
					Id = 2,
					BookId = 1,
					MemberId = 2,
					BorrowDate = new DateTime(2022, 1, 2),
					ReturnDate = new DateTime(2022, 1, 9),
					Status = "Good"
				},

				new DC_Borrow
				{
					Id = 3,
					BookId = 2,
					MemberId = 1,
					BorrowDate = new DateTime(2022, 1, 1),
					ReturnDate = new DateTime(2022, 1, 8),
					Status = "Good"
				},

				new DC_Borrow
				{
					Id = 4,
					BookId = 3,
					MemberId = 3,
					BorrowDate = new DateTime(2022, 1, 3),
					ReturnDate = new DateTime(2022, 1, 10),
					Status = "Returned"
				},

				new DC_Borrow
				{
					Id = 5,
					BookId = 4,
					MemberId = 1,
					BorrowDate = new DateTime(2022, 1, 1),
					ReturnDate = new DateTime(2022, 1, 8),
					Status = "Good"
				},

				new DC_Borrow
				{
					Id = 6,
					BookId = 5,
					MemberId = 4,
					BorrowDate = new DateTime(2021, 12, 26),
					ReturnDate = new DateTime(2022, 1, 3),
					Status = "Overdue"
				}
			); ;
		}
    }
}
