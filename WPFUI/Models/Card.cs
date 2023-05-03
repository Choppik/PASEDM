using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using System;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Card
    {
        private ICardCreator _cardCreator;

        public Card(ICardCreator cardCreator)
        {
            _cardCreator = cardCreator;
        }

        public Card(int numberCard, string nameCard, DateTime dateOfFormation, string comment, int? documentID, int? documentTypesID, int? caseID, int? userID, int? employeeID, int? recipientID)
        {
            NumberCard = numberCard;
            NameCard = nameCard;
            DateOfFormation = dateOfFormation;
            Comment = comment;
            DocumentID = documentID;
            DocumentTypesID = documentTypesID;
            CaseID = caseID;
            UserID = userID;
            EmployeeID = employeeID;
            RecipientID = recipientID;
        }

        public int Id { get; }
        public int NumberCard { get; }
        public string NameCard { get; }
        public DateTime DateOfFormation { get; }
        public string Comment { get; }
        public int? DocumentID { get; }
        public int? DocumentTypesID { get; }
        public int? CaseID { get; }
        public int? UserID { get; }
        public int? EmployeeID { get; }
        public int? RecipientID { get; }

        public async Task CreateCard(Card card)
        {
            await _cardCreator.CreateCard(card);
        }
    }
}