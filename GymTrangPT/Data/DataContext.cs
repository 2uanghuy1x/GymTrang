using GymApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTrangPT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HistoryEP> HistoryEPs { get; set; }
        public DbSet<EpisodePackage> EpisodePackages { get; set; }
        public DbSet<Pt> Pts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .HasKey(ur => new { ur.Id });
            modelBuilder.Entity<Staff>()
     .Property(ur => ur.Id)
     .ValueGeneratedOnAdd();

            modelBuilder.Entity<Bill>()
             .HasKey(ur => new { ur.Id });
            modelBuilder.Entity<Bill>()
.Property(ur => ur.Id)
.ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
             .HasKey(ur => new { ur.Id });
            modelBuilder.Entity<Customer>()
.Property(ur => ur.Id)
.ValueGeneratedOnAdd();

            modelBuilder.Entity<HistoryEP>()
             .HasKey(ur => new { ur.Id });
            modelBuilder.Entity<HistoryEP>()
.Property(ur => ur.Id)
.ValueGeneratedOnAdd();


            modelBuilder.Entity<EpisodePackage>()
             .HasKey(ur => new { ur.Id });
            modelBuilder.Entity<EpisodePackage>()
.Property(ur => ur.Id)
.ValueGeneratedOnAdd();

            modelBuilder.Entity<Pt>()
            .HasKey(ur => new { ur.Id });
            modelBuilder.Entity<Pt>()
.Property(ur => ur.Id)
.ValueGeneratedOnAdd();

        }
    }
}
