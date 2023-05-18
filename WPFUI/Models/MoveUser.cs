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

        public MoveUser(int numberCard, string nameCard, string nameDoc, string docType, string nameTask, string contentTask, string taskStage, string numberCase, string desriptionCase, string executor, DateTime dateOfFormation, string comment, string sender, string recipient)
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
            Recipient = recipient;
        }
        public MoveUser(int numberCard, string nameCard, string nameDoc, string docType, Tasks tasks, string numberCase, string desriptionCase, string executor, DateTime dateOfFormation, string comment, string sender, string recipient)
        {
            NumberCard = numberCard;
            NameCard = nameCard;
            NameDoc = nameDoc;
            DocType = docType;
            Tasks = tasks;
            NumberCase = numberCase;
            DesriptionCase = desriptionCase;
            Executor = executor;
            DateOfFormation = dateOfFormation;
            Comment = comment;
            Sender = sender;
            Recipient = recipient;
        }

        public int Id { get; }
        public int? TypeUserID { get; }
        public int? CardID { get; }
        public int NumberCard { get; }
        public string NameCard { get; }
        public string NameDoc { get; }
        public string DocType { get; }
        public Tasks Tasks { get; }
        public string NameTask { get; }
        public string ContentTask { get; }
        public string TaskStage { get; }
        public string NumberCase { get; }
        public string DesriptionCase { get; }
        public string Executor { get; }
        public DateTime DateOfFormation { get; }
        public string Comment { get; }
        public string Sender { get; }
        public string Recipient { get; }
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