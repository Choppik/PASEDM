using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Recipient
    {
        private IRecipientCreator _recipientCreator;
        private IRecipientProvider _recipientProvider;

        public Recipient(IRecipientCreator recipientCreator)
        {
            _recipientCreator = recipientCreator;
        }

        public Recipient(int? taskID, int? userID)
        {
            TaskID = taskID;
            UserID = userID;
        }

        public Recipient(int id, int? taskID, int? userID)
        {
            Id = id;
            TaskID = taskID;
            UserID = userID;
        }
        public Recipient(int id, string user)
        {
            Id = id;
            User = user;
        }

        public Recipient(IRecipientProvider recipientProvider)
        {
            _recipientProvider = recipientProvider;
        }

        public int Id { get; }
        public int? TaskID { get; }
        public int? UserID { get; }
        public string User { get; }

        public async Task AddRecipient(Recipient recipient)
        {
            await _recipientCreator.AddRecipient(recipient);
        }
        public async Task<Recipient> GetRecipient(Recipient recipient)
        {
            return await _recipientProvider.GetRecipient(recipient);
        }
        public async Task<IEnumerable<Recipient>> GetAllRecipient()
        {
            return await _recipientProvider.GetAllRecipient();
        }
    }
}