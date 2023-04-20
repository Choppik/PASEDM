using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseEmloyeeProvider : IEmployeeProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseEmloyeeProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<EmployeeDTO> employeeDTOs = context.Staff.ToList();

                return employeeDTOs.Select(u => ToEmployee(u));
            }
        }

        private static Employee ToEmployee(EmployeeDTO dto)
        {
            return new Employee(dto.Id, dto.Name);
        }
    }
}