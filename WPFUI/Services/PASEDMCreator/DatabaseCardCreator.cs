﻿using PASEDM.Data.DTOs;
using PASEDM.Data;
using PASEDM.Models;
using System.Threading.Tasks;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseCardCreator : ICardCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseCardCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateCard(Card card)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    CardDTO cardDTO = ToCardDTO(card);
                    context.Cards.Add(cardDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static CardDTO ToCardDTO(Card card)
        {
            return new CardDTO()
            {
                NumberCard = card.NumberCard,
                NameCard = card.NameCard,
                Comment = card.Comment,
                DateOfFormation = card.DateOfFormation,
                DocumentID = card.Documents.Id,
                TaskID = card.Tasks.Id,
                CaseID = card.Cases.Id,
                EmployeeID = card.Employee.Id,
            };
        }
    }
}