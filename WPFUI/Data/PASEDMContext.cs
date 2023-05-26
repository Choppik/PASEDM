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
        public DbSet<TypeUserDTO> TypeUsers { get; set; }
        public DbSet<CaseDTO> Cases { get; set; }
        public DbSet<DocumentTypesDTO> DocumentTypes { get; set; }
        public DbSet<DocumentDTO> Documents { get; set; }
        public DbSet<TermDTO> Deadlines { get; set; }
        public DbSet<TaskDTO> Tasks { get; set; }
        public DbSet<CardDTO> Cards { get; set; }
        public DbSet<SecrecyStampDTO> SecrecyStamps { get; set; }
        public DbSet<TaskStagesDTO> TaskStages { get; set; }
        public DbSet<DocStagesDTO> DocStages { get; set; }
        public DbSet<AccessRightsDTO> AccessRights { get; set; }
        public DbSet<RoleDTO> Role { get; set; }
        public DbSet<MoveCardDTO> MoveCards { get; set; }
        public DbSet<MoveDocumentDTO> MoveDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
            modelBuilder.ApplyConfiguration(new RecipientConfiguration());
            modelBuilder.ApplyConfiguration(new TypeUserConfiguration());
            modelBuilder.ApplyConfiguration(new CaseConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypesConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new DeadlinesConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new SecrecyStampConfiguration());
            modelBuilder.ApplyConfiguration(new TaskStagesConfiguration());
            modelBuilder.ApplyConfiguration(new DocStagesConfiguration());
            modelBuilder.ApplyConfiguration(new AccessRightsConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new MoveCardConfiguration());
            modelBuilder.ApplyConfiguration(new MoveDocumentConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }
    }
}