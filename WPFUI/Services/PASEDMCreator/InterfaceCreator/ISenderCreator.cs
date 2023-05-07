using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface ISenderCreator
    {
        Task AddSender(Recipient recipient);
    }
}