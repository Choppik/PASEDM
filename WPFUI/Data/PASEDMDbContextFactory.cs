using Microsoft.EntityFrameworkCore;

namespace PASEDM.Data
{
    public class PASEDMDbContextFactory
    {
        private readonly string _connectionString;

        public PASEDMDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PASEDMContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;

            return new PASEDMContext(options);
        }
    }
}