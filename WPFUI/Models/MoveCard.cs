using Microsoft.VisualBasic.ApplicationServices;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class MoveCard
    {
        private IMoveCardCreator _moveUserCreator;
        private IMoveCardProvider _moveUserProvider;

        #region Конструкторы
        public MoveCard() { }
        public MoveCard(IMoveCardCreator moveUserCreator)
        {
            _moveUserCreator = moveUserCreator;
        }

        public MoveCard(IMoveCardProvider moveUserProvider)
        {
            _moveUserProvider = moveUserProvider;
        }
        public MoveCard(int? typeUserID)
            : this(default, default, typeUserID, default)
        { }
        public MoveCard(int? typeUserID, int viewed, int? cardID)
            :this(default, viewed, typeUserID, cardID)
        { }
        public MoveCard(int id, int viewed, int? typeUserID, int? cardID)
        {
            Id = id;
            Viewed = viewed;
            TypeUserID = typeUserID;
            CardID = cardID;
        }
        public MoveCard(int? id, int viewed, int? cardID, int numberCard, string nameCard, Document document, Deadlines deadlines, DocStages docStages, SecrecyStamps secrecyStamps, DocumentTypes documentTypes, Tasks tasks, TaskStages taskStages, Case cases, Employee executor, DateTime dateOfFormation, string comment, User recipient, string sender)
        {
            Id = id;
            Viewed = viewed;
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
        #endregion

        #region Свойства
        public int? Id { get; }
        public int Viewed { get; }
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
        #endregion
        public async Task AddMoveUser(MoveCard moveUser)
        {
            await _moveUserCreator.AddMoveCard(moveUser);
        }
        public Task<IEnumerable<MoveCard>> GetAllMoveUserSender(MoveCard moveUser, User user)
        {
            return _moveUserProvider.GetAllMoveUserSender(moveUser, user);
        }
        public Task<IEnumerable<MoveCard>> GetAllMoveUserRecipient(MoveCard moveUser, User user)
        {
            return _moveUserProvider.GetAllMoveUserRecipient(moveUser, user);
        }
        public async Task DeleteMoveUser(MoveCard moveUser)
        {
            await _moveUserProvider.DeleteMoveCard(moveUser);
        }
        public int GetCountViewedMoveCard(User user)
        {
            return _moveUserProvider.GetCountViewedMoveCard(user);
        }
    }
}