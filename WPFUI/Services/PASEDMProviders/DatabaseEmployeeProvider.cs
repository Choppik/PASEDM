using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseEmployeeProvider : IEmployeeProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseEmployeeProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<EmployeeDTO> employeeDTOs = await context.Staff.Include(u => u.Division).ToListAsync();

                return employeeDTOs.Select(u => ToEmployee(u));
            }
        }

        private static Employee ToEmployee(EmployeeDTO dto)
        {
            return new Employee(dto.ID, dto.NumberEmployee, dto.FullName, dto.Mail, dto.Division.Division);
        }
    }
}