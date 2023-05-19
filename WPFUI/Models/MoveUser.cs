using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class MoveUser
    {
        private IMoveUserCreator _moveUserCreator;
        private IMoveUserProvider _moveUserProvider;

        public MoveUser() { }
        public MoveUser(IMoveUserCreator moveUserCreator)
        {
            _moveUserCreator = moveUserCreator;
        }

        public MoveUser(IMoveUserProvider moveUserProvider)
        {
            _moveUserProvider = moveUserProvider;
        }
        public MoveUser(int? typeUserID)
            : this(default, typeUserID, default)
        { }
        public MoveUser(int? typeUserID, int? cardID)
            :this(default, typeUserID, cardID)
        { }
        public MoveUser(int id, int? typeUserID, int? cardID)
        {
            Id = id;
            TypeUserID = typeUserID;
            CardID = cardID;
        }
        public MoveUser(int? cardID, int numberCard, string nameCard, Document document, Deadlines deadlines, DocStages docStages, SecrecyStamps secrecyStamps, DocumentTypes documentTypes, Tasks tasks, TaskStages taskStages, Case cases, Employee executor, DateTime dateOfFormation, string comment, User recipient, string sender)
        {
            CardID = cardID;
            NumberCard = numberCard;
            NameCard = nameCard;
            Document = document;
            Deadlines = deadlines;
            DocStages = docStages;
            SecrecyStamps = secrecyStamps;
            DocumentTypes = documentTypes;
            Tasks = tasks;
            TaskStages = taskStages;
            Cases = cases;
            Executor = executor;
            DateOfFormation = dateOfFormation;
            Comment = comment;
            Recipient = recipient;
            Sender = sender;
        }

        public int Id { get; }
        public int? TypeUserID { get; }
        public int? CardID { get; }
        public int NumberCard { get; }
        public string NameCard { get; }
        public Document Document { get; }
        public DocStages DocStages { get; }
        public SecrecyStamps SecrecyStamps { get; }
        public Deadlines Deadlines { get; }
        public DocumentTypes DocumentTypes { get; }
        public Tasks Tasks { get; }
        public TaskStages TaskStages { get; }
        public Case Cases { get; }
        public Employee Executor { get; }
        public DateTime DateOfFormation { get; }
        public string Comment { get; }
        public string Sender { get; }
        public User Recipient { get; }
        public async Task AddMoveUser(MoveUser moveUser)
        {
            await _moveUserCreator.AddMoveUser(moveUser);
        }
        public Task<IEnumerable<MoveUser>> GetAllMoveUserSender(MoveUser moveUser, User user)
        {
            return _moveUserProvider.GetAllMoveUserSender(moveUser, user);
        }
        public Task<IEnumerable<MoveUser>> GetAllMoveUserRecipient(MoveUser moveUser, User user)
        {
            return _moveUserProvider.GetAllMoveUserRecipient(moveUser, user);
        }
    }
}