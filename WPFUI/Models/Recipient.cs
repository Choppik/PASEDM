using Microsoft.VisualBasic.ApplicationServices;
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

        public Recipient(IRecipientCreator recipientCreator)
        {
            _recipientCreator = recipientCreator;
        }

        public Recipient(DateTime dateOfReceipt, int? taskID, int? userID)
        {
            DateOfReceipt = dateOfReceipt;
            TaskID = taskID;
            UserID = userID;
        }

        public Recipient(IRecipientProvider recipientProvider)
        {
            _recipientProvider = recipientProvider;
        }
        public Recipient(DateTime dateOfReceipt, int userID)
        {
            DateOfReceipt = dateOfReceipt;
            UserID = userID;
        }

        public Recipient(int id, DateTime dateOfReceipt, int? taskID, int? userID)
        {
            Id = id;
            DateOfReceipt = dateOfReceipt;
            TaskID = taskID;
            UserID = userID;
        }

        public int Id { get; }
        public DateTime DateOfReceipt { get; }
        public int? TaskID { get; }
        public int? UserID { get; }

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