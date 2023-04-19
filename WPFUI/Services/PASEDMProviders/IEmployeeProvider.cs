using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    internal interface IEmployeeProvider
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
    }
}
