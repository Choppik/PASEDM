using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Card
    {
        private ICardCreator _cardCreator;
        private ICardProvider _cardProvider;

        public Card(ICardCreator cardCreator)
        {
            _cardCreator = cardCreator;
        }

        public Card(ICardProvider cardProvider)
        {
            _cardProvider = cardProvider;
        }

        public Card(int numberCard, string nameCard, string comment, int? documentID, int? documentTypesID, int? caseID, int? userID, int? employeeID, int? recipientID)
        {
            NumberCard = numberCard;
            NameCard = nameCard;
            Comment = comment;
            DocumentID = documentID;
            DocumentTypesID = documentTypesID;
            CaseID = caseID;
            UserID = userID;
            EmployeeID = employeeID;
            RecipientID = recipientID;
        }
        public Card(int numberCard, string nameCard, string comment, string document, string documentType, string cases, string user, string employee, string recipient)
        {
            NumberCard = numberCard;
            NameCard = nameCard;
            Comment = comment;
            NameDoc = document;
            DocumentType = documentType;
            Case = cases;
            User = user;
            Employee = employee;
            Recipient = recipient;
        }

        public int Id { get; }
        public int NumberCard { get; }
        public string NameCard { get; }
        public string Comment { get; }
        public int? DocumentID { get; }
        public string NameDoc { get; }
        public int? DocumentTypesID { get; }
        public string DocumentType { get; }
        public int? CaseID { get; }
        public string Case { get; }
        public int? UserID { get; }
        public string User { get; }
        public int? EmployeeID { get; }
        public string Employee { get; }
        public int? RecipientID { get; }
        public string Recipient { get; }

        public async Task CreateCard(Card card)
        {
            await _cardCreator.CreateCard(card);
        }
        public async Task<IEnumerable<Card>> GetAllCard()
        {
            return await _cardProvider.GetAllCard();
        }
    }
}