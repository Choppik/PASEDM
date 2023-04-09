using PASEDM.Models;
using PASEDM.Data.Configuration;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using PASEDM.Data.DTOs;

namespace PASEDM.Data
{
    public class PASEDMContext : DbContext
    {
        public PASEDMContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserDTO> Users { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseExceptionProcessor();
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
