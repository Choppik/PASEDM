using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Recipient
    {
        private IRecipientCreator _recipientCreator;
        private IRecipientProvider _recipientProvider;

        public Recipient() { }
        public Recipient(int? userID)
            :this(default, userID)
        { }

        public Recipient(IRecipientCreator recipientCreator, IRecipientProvider recipientProvider)
        {
            _recipientCreator = recipientCreator;
            _recipientProvider = recipientProvider;
        }

        public Recipient(IRecipientProvider recipientProvider)
        {
            _recipientProvider = recipientProvider;
        }

        public Recipient(int id, int? userID)
        {
            Id = id;
            UserID = userID;
        }

        public int Id { get; }
        public int? UserID { get; }

        public async Task AddRecipient(Recipient recipient)
        {
            await _recipientCreator.AddRecipient(recipient);
        }
        public async Task<Recipient> GetRecipient(Recipient recipient)
        {
            return await _recipientProvider.GetRecipient(recipient);
        }
    }
}