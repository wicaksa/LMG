using LMG.DAT.Models.Borrow;
using LMG.DAT.Models.Review;
using LMG.DAT.Models.Series;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.DataContext
{
    public class LMG_DbContext : DbContext
    {
        public DbSet<DC_Borrow> Borrow { get; set; }
        public DbSet<DC_Review> Review { get; set; }
        public DbSet<DC_Series> Series { get; set; }

        public LMG_DbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BorrowConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=codeday-labs-2;Integrated Security=True");
    }
}
