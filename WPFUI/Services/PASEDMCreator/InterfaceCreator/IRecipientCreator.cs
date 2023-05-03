using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface IRecipientCreator
    {
        Task AddRecipient(Recipient recipient);
    }
}