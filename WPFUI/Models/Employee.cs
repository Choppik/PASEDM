﻿using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Employee
    {
        private readonly IEmployeeProvider _employeeProviders;
        public int Id { get; }
        public int NumberEmployee { get; }
        public string FullName { get; }
        public string Mail { get; }
        public string Admittance { get; }
        public string Division { get; }

        public Employee(IEmployeeProvider employeeProviders)
        {
            _employeeProviders = employeeProviders;
        }

        public Employee(int id, int numberEmployee, string fullName, string mail, string division)
        {
            Id = id;
            NumberEmployee = numberEmployee;
            FullName = fullName;
            Mail = mail;
            Division = division;
        }

        public Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return _employeeProviders.GetAllEmployee();
        }
    }
}