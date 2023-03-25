using Engine.Models;
using Engine.ViewModels.Data.Configuration;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Engine.ViewModels.Data
{
    public class PASEDMContext : DbContext
    {
        private readonly string connectionString = "Server=localhost;Database=AppPASEDM;User Id=user1;Password=sa;TrustServerCertificate=True";
        public PASEDMContext()
        {
            //Database.EnsureDeleted();

            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseExceptionProcessor();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
