using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IRecipientProvider
    {
        Task<Recipient> GetRecipient(Recipient recipient);
    }
}