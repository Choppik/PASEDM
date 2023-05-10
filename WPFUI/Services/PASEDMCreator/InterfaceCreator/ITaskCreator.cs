using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface ITaskCreator
    {
        Task CreateTask(Tasks tasks);
    }
}