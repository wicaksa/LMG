using LMG.DAT.Models.Book;
using LMG.DAT.Models.Member;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.Models.Reservation
{
    public class DC_Reservation : DataContextBase
    {
        // Attributes 
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReservationDate { get; set; }

        public DateTime ReservationExpirationDate { get; set; }

        public Boolean ReservationStatus { get; set; } // True =It's still live, False = Not live

        public String? ReservationResult { get; set; } // Borrow, Cancel, or Expired

        // Relationships
        public DC_Book Book { get; set; }

        public DC_Member Member { get; set; }

        public class ReservationConfiguration : IEntityTypeConfiguration<DC_Reservation>
        {
            public void Configure(EntityTypeBuilder<DC_Reservation> builder)
            {
                // Set Id's as PK
                builder.ToTable("Reservation", "Reservation")
                    .HasKey(m => m.Id);

                // Relationship
                builder.HasOne(b => b.Book).WithMany(b => b.Reservations);
                builder.HasOne(m => m.Member).WithMany(m => m.Reservations);

                // Column Props
                builder.Property(r => r.ReservationResult).HasMaxLength(16);

				// Seed Data
				builder.HasData(

					new DC_Reservation
					{
						Id = 1,
						BookId = 2,
						MemberId = 1,
						ReservationDate = new DateTime(2022, 1, 6),
						ReservationExpirationDate = new DateTime(2022, 1, 20),
						ReservationStatus = true,
						ReservationResult = null,
						
					},

					new DC_Reservation
					{
						Id = 2,
						BookId = 2,
						MemberId = 3,
						ReservationDate = new DateTime(2022, 1, 5),
						ReservationExpirationDate = new DateTime(2022, 1, 19),
						ReservationStatus = false,
						ReservationResult = "Cancel"
					},

					new DC_Reservation
					{
						Id = 3,
						BookId = 4,
						MemberId = 2,
						ReservationDate = new DateTime(2022, 1, 3),
						ReservationExpirationDate = new DateTime(2022, 1, 17),
						ReservationStatus = false,
						ReservationResult = "Borrow"
					},

					new DC_Reservation
					{
						Id = 4,
						BookId = 3,
						MemberId = 3,
						ReservationDate = new DateTime(2022, 1, 2),
						ReservationExpirationDate = new DateTime(2022, 1, 16),
						ReservationStatus = true,
						ReservationResult = null
					},

					new DC_Reservation
					{
						Id = 5,
						BookId = 2,
						MemberId = 5,
						ReservationDate = new DateTime(2022, 1, 1),
						ReservationExpirationDate = new DateTime(2022, 1, 15),
						ReservationStatus = true,
						ReservationResult = null
					}
				); ;
            }
        }
    }
}
