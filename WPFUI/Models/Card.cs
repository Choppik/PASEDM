using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Card
    {
        private ICardCreator _cardCreator;
        private ICardProvider _cardProvider;

        public Card() { }

        public Card(int numberCard, string nameCard, string comment, DateTime dateOfFormation, int? documentID, int? documentTypesID, int? taskID, int? caseID, int? employeeID, int? senderID) 
            :this(default, numberCard, nameCard, comment, dateOfFormation, documentID, documentTypesID, taskID, caseID, employeeID, senderID)
        { }
        public Card(int id, string nameCard)
            : this(id, default, nameCard, "", default, default, default, default, default, default, default)
        { }
        public Card(string nameCard)
            : this(default, default, nameCard, "", default, default, default, default, default, default, default)
        { }



        public Card(ICardCreator cardCreator, ICardProvider cardProvider)
        {
            _cardCreator = cardCreator;
            _cardProvider = cardProvider;
        }
        public Card(int id, int numberCard, string nameCard, string comment, DateTime dateOfFormation, int? documentID, int? documentTypesID, int? taskID, int? caseID, int? employeeID, int? userID)
        {
            Id = id;
            NumberCard = numberCard;
            NameCard = nameCard;
            Comment = comment;
            DateOfFormation = dateOfFormation;
            DocumentID = documentID;
            DocumentTypesID = documentTypesID;
            TaskID = taskID;
            CaseID = caseID;
            EmployeeID = employeeID;
            UserID = userID;
        }

        public int Id { get; }
        public int NumberCard { get; }
        public string NameCard { get; }
        public string Comment { get; }
        public DateTime DateOfFormation { get; }
        public int? DocumentID { get; }
        public int? DocumentTypesID { get; }
        public int? TaskID { get; }
        public int? CaseID { get; }
        public int? EmployeeID { get; }
        public int? UserID { get; }

        public async Task CreateCard(Card card)
        {
            await _cardCreator.CreateCard(card);
        }
        public async Task<Card> GetCard(Card card)
        {
            return await _cardProvider.GetCard(card);
        }
    }
}