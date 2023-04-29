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
        public DbSet<RecipientDTO> Recipients { get; set; }
        public DbSet<CaseDTO> Cases { get; set; }
        public DbSet<DocumentTypesDTO> DocumentTypes { get; set; }
        public DbSet<DocumentDTO> Documents { get; set; }
        public DbSet<TaskDTO> Tasks { get; set; }
        public DbSet<CardDTO> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
            modelBuilder.ApplyConfiguration(new RecipientConfiguration());
            modelBuilder.ApplyConfiguration(new CaseConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypesConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
        }
    }
}