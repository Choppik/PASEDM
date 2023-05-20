using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Employee
    {
        private readonly IEmployeeProvider _employeeProviders;
        public int? Id { get; }
        public int NumberEmployee { get; }
        public string FullName { get; set; }
        public string Mail { get; }
        public AccessRights AccessRights { get; }
        public int? DivisionID { get; }

        public Employee(IEmployeeProvider employeeProviders)
        {
            _employeeProviders = employeeProviders;
        }

        public Employee(int? id, int numberEmployee, string fullName, string mail, AccessRights accessRights, int? divisionID)
        {
            Id = id;
            NumberEmployee = numberEmployee;
            FullName = fullName;
            Mail = mail;
            AccessRights = accessRights;
            DivisionID = divisionID;
        }

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