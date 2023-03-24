using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class PASEDMContext : DbContext
    {
        string connectionString = "Server=localhost;Database=AppPASEDM;User Id=user1;Password=sa;TrustServerCertificate=True";
        public PASEDMContext() 
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.IdUser).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(100);
        }
    }
}
