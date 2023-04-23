using PASEDM.Services.PASEDMProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Employee
    {
        private readonly IEmployeeProvider _employeeProviders;
        public int ID { get; }
        public int NumberEmployee { get; }
        public string Name { get; }

        public Employee(IEmployeeProvider employeeProviders)
        {
            _employeeProviders = employeeProviders;
        }

        public Employee(int id, int numberEmployee, string name)
        {
            ID = id;
            NumberEmployee = numberEmployee;
            Name = name;
        }

        public Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return _employeeProviders.GetAllEmployee();
        }
    }
}