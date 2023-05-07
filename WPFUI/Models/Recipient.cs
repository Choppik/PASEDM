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
        public Recipient(int? userID, int? cardID)
            :this(default, userID, cardID)
        { }
        public Recipient(int? cardID)
            : this(default, default, cardID)
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

        public Recipient(int numberCard, string nameCard, string nameDoc, string docType, string nameTask, string contentTask, string taskStage, string numberCase, string desriptionCase, string executor, DateTime dateOfFormation, string comment, string sender)
        {
            NumberCard = numberCard;
            NameCard = nameCard;
            NameDoc = nameDoc;
            DocType = docType;
            NameTask = nameTask;
            ContentTask = contentTask;
            TaskStage = taskStage;
            NumberCase = numberCase;
            DesriptionCase = desriptionCase;
            Executor = executor;
            DateOfFormation = dateOfFormation;
            Comment = comment;
            Sender = sender;
        }

        public Recipient(int id, int? userID, int? cardID)
        {
            Id = id;
            UserID = userID;
            CardID = cardID;
        }

        public int Id { get; }
        public int? UserID { get; }
        public int? CardID { get; }
        public int NumberCard { get; }
        public string NameCard { get; }
        public string NameDoc { get; }
        public string DocType { get; }
        public string NameTask { get; }
        public string ContentTask { get; }
        public string TaskStage { get; }
        public string NumberCase { get; }
        public string DesriptionCase { get; }
        public string Executor { get; }
        public DateTime DateOfFormation { get; }
        public string Comment { get; }
        public string Sender { get; }



        public async Task AddRecipient(Recipient recipient)
        {
            await _recipientCreator.AddRecipient(recipient);
        }
        public async Task<IEnumerable<Recipient>> GetAllRecipient(User user)
        {
            return await _recipientProvider.GetAllRecipient(user);
        }
        public async Task<Recipient> GetRecipient(Recipient recipient)
        {
            return await _recipientProvider.GetRecipient(recipient);
        }
    }
}