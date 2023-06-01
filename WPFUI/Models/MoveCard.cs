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
        private IMoveCardCreator _moveCardCreator;
        private IMoveCardProvider _moveCardProvider;

        #region Конструкторы
        public MoveCard() { }
        public MoveCard(IMoveCardCreator moveUserCreator)
        {
            _moveCardCreator = moveUserCreator;
        }

        public MoveCard(IMoveCardProvider moveUserProvider)
        {
            _moveCardProvider = moveUserProvider;
        }
        public MoveCard(TypeCard typeCard, User user)
            : this(default, default, default, typeCard, user)
        { }
        public MoveCard(int viewed, Card card, TypeCard typeCard, User user)
            :this(default, viewed, card, typeCard, user)
        { }

        public MoveCard(int? id, int viewed, Card card, TypeCard typeCard, User user)
        {
            Id = id;
            Viewed = viewed;
            Card = card;
            TypeCard = typeCard;
            User = user;
        }

        #endregion

        #region Свойства
        public int? Id { get; }
        public int Viewed { get; }
        public Card Card { get; }
        public TypeCard TypeCard { get; }
        public User User { get; }
        #endregion
        public async Task AddMoveCard(MoveCard moveUser)
        {
            await _moveCardCreator.AddMoveCard(moveUser);
        }
        public Task<IEnumerable<MoveCard>> GetAllMoveCardUniq(MoveCard moveCard)
        {
            return _moveCardProvider.GetAllMoveCard(moveCard);
        }
        public Task<IEnumerable<MoveCard>> GetAllMoveCard(MoveCard moveCard)
        {
            return _moveCardProvider.GetAllMoveCard(moveCard);
        }
        public async Task DeleteMoveUser(MoveCard moveUser)
        {
            await _moveCardProvider.DeleteMoveCard(moveUser);
        }
        public int GetCountViewedMoveCard(User user)
        {
            return _moveCardProvider.GetCountViewedMoveCard(user);
        }
    }
}