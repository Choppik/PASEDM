using PASEDM.Data.Configuration;
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
        public DbSet<EmployeeDTO> Staff { get; set; }
        public DbSet<DivisionDTO> Divisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
        }
    }
}