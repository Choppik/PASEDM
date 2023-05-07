using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Sender
    {
        private ISenderCreator _senderCreator;
        private ISenderProvider _senderProvider;

        public Sender() { }
        public Sender(ISenderCreator senderCreator)
        {
            _senderCreator = senderCreator;
        }
        public Sender(int? recipientID)
            :this(default, recipientID)
        { }

        public Sender(ISenderProvider senderProvider)
        {
            _senderProvider = senderProvider;
        }

        public Sender(int id, int? recipientID)
        {
            Id = id;
            RecipientID = recipientID;
        }

        public Sender(int numberCard, string nameCard, string nameDoc, string docType, string nameTask, string contentTask, string taskStage, string numberCase, string desriptionCase, string executor, DateTime dateOfFormation, string comment, string recipient)
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
            Recipient = recipient;
        }

        public int Id { get; }
        public int? RecipientID { get; }
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
        public string Recipient { get; }
        public async Task AddSender(Recipient recipient)
        {
            await _senderCreator.AddSender(recipient);
        }
        public async Task<IEnumerable<Sender>> GetAllSender(User user)
        {
            return await _senderProvider.GetAllSender(user);
        }
    }
}