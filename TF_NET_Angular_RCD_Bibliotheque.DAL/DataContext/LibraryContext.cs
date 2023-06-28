using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.DAL.Configurations;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.DAL.DataContext
{
    public class LibraryContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Notice> Notices => Set<Notice>();

        public LibraryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new NoticeConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        //{
        //    optionsbuilder.UseSqlServer(@"Data Source=DESKTOP-56GOFPS\\DEVPERSO;Initial Catalog=E6KRCD;Integrated Security=True;");
        //}


    }
}
