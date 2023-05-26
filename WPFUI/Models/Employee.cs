using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Employee
    {
        private readonly IEmployeeProvider _employeeProviders;

        public Employee() { }
        public Employee(IEmployeeProvider employeeProviders)
        {
            _employeeProviders = employeeProviders;
        }

        public Employee(int? id, int numberEmployee, string fullName, string mail, AccessRights accessRights, Division divisionName)
        {
            Id = id;
            NumberEmployee = numberEmployee;
            FullName = fullName;
            Mail = mail;
            AccessRights = accessRights;
            DivisionName = divisionName;
        }
        public int? Id { get; }
        public int NumberEmployee { get; }
        public string FullName { get; set; }
        public string Mail { get; }
        public AccessRights AccessRights { get; }
        public Division DivisionName { get; }


        public Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return _employeeProviders.GetAllEmployee();
        }
        public override string ToString()
        {
            return $"{FullName}";
        }
    }
}