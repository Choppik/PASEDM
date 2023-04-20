using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public interface IEmployeeProvider
    {
        IEnumerable<Employee> GetAllEmployee();
    }
}
