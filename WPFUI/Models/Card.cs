using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Card
    {
        private ICardCreator _cardCreator;
        private ICardProvider _cardProvider;

        public Card() { }

        public Card(int numberCard, string nameCard, string comment, DateTime dateOfFormation, Document document, Tasks task, Case cases, Employee employee) 
            :this(default, numberCard, nameCard, comment, dateOfFormation, document, task, cases, employee)
        { }
        public Card(int id, string nameCard)
            : this(id, default, nameCard, "", default, default, default, default, default)
        { }
        public Card(DateTime dateOfFormation)
            : this(default, default, "", "", dateOfFormation, default, default, default, default)
        { }
        public Card(int id, Tasks task)
            : this(id, default, "", "", default, default, task, default, default)
        { }

        public Card(int id, int numberCard, string nameCard, string comment, DateTime dateOfFormation, Document document, Tasks task, Case cases, Employee employee)
        {
            Id = id;
            NumberCard = numberCard;
            NameCard = nameCard;
            Comment = comment;
            DateOfFormation = dateOfFormation;
            Documents = document;
            Tasks = task;
            Cases = cases;
            Employee = employee;
        }
        public Card(ICardCreator cardCreator, ICardProvider cardProvider)
        {
            _cardCreator = cardCreator;
            _cardProvider = cardProvider;
        }

        public Card(ICardProvider cardProvider)
        {
            _cardProvider = cardProvider;
        }

        public int Id { get; }
        public int NumberCard { get; }
        public string NameCard { get; }
        public string Comment { get; }
        public DateTime DateOfFormation { get; }
        public Tasks Tasks { get; }
        public Document Documents { get; }
        public Case Cases { get; }
        public Employee Employee { get; }

        public async Task CreateCard(Card card)
        {
            await _cardCreator.CreateCard(card);
        }
        public async Task<Card> GetCard(Card card)
        {
            return await _cardProvider.GetCard(card);
        }
        public Task<IEnumerable<Card>> GetAllTaskExecutor(User user)
        {
            return _cardProvider.GetAllTaskExecutor(user);
        }
        public override string ToString()
        {
            return $"{NameCard}";
        }
    }
}