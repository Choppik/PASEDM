using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class MoveDocument
    {
        private IMoveDocumentProvider _moveDocumentProvider;
        private IMoveDocumentCreator _moveDocumentCreator;

        public MoveDocument() { }
        public MoveDocument(IMoveDocumentCreator moveDocumentCreator)
        {
            _moveDocumentCreator = moveDocumentCreator;
        }

        public MoveDocument(IMoveDocumentProvider moveDocumentProvider)
        {
            _moveDocumentProvider = moveDocumentProvider;
        }

        public MoveDocument(IMoveDocumentProvider moveDocumentProvider, IMoveDocumentCreator moveDocumentCreator)
        {
            _moveDocumentProvider = moveDocumentProvider;
            _moveDocumentCreator = moveDocumentCreator;
        }
        public MoveDocument(User user, Document document)
            : this(default, user, document)
        { }

        public MoveDocument(int id, User user, Document document)
        {
            Id = id;
            User = user;
            Document = document;
        }

        public int Id { get; }
        public User User { get; }
        public Document Document { get; }
        public async Task AddMoveDocument(MoveDocument moveDocument)
        {
            await _moveDocumentCreator.AddMoveDocument(moveDocument);
        }
        public Task<IEnumerable<MoveDocument>> GetAllMoveDocument(User user)
        {
            return _moveDocumentProvider.GetAllMoveDocument(user);
        }
        public async Task DeleteMoveDocument(MoveDocument moveDocument)
        {
            await _moveDocumentProvider.DeleteMoveDocument(moveDocument);
        }
    }
}