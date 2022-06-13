using LMG.DAT.Models.Author;
using LMG.DAT.Models.BookAuthor;
using LMG.DAT.Models.Book;
using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Member;
using LMG.DAT.Models.Review;
using LMG.DAT.Models.Series;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMG.DAT.Models.Reservation;
using static LMG.DAT.Models.Reservation.DC_Reservation;

namespace LMG.DAT.DataContext
{
    public class LMG_DbContext : DbContext
    {
        public DbSet<DC_Borrow> Borrow { get; set; }
        public DbSet<DC_Review> Review { get; set; }
        public DbSet<DC_Series> Series { get; set; }
        public DbSet<DC_BookAuthor> BookAuthor { get; set; }

        // WM
        public DbSet<DC_Author> Author { get; set; }
        public DbSet<DC_Book> Book { get; set; }
        public DbSet<DC_Member> Member { get; set; }
        public DbSet<DC_Reservation> Reservation { get; set; }

        // Not sure what to do for this method so we left it empty. -WM
        public LMG_DbContext() : base()
        {

        }

        public LMG_DbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BorrowConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());   
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        // Move this later to appsettings.json - WM
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer("Data Source=codeday-labs-1;Integrated Security=True");
    }
}
