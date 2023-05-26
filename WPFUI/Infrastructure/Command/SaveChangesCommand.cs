using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.Store;
using PASEDM.ViewModels;
using System.Threading.Tasks;

namespace PASEDM.Infrastructure.Command
{
    public class SaveChangesCommand : AsyncBaseCommand
    {
        private ReferencesViewModel _referencesViewModel;
        private UserStore _userStore;
        private PASEDMDbContextFactory _contextFactory;

        private ISecrecyStampsProvider _secrecyStampsProvider;
        public SaveChangesCommand(ReferencesViewModel referencesViewModel, UserStore userStore, PASEDMDbContextFactory contextFactory) 
        {
            _referencesViewModel = referencesViewModel;
            _userStore = userStore;
            _contextFactory = contextFactory;
        }
        public async override Task ExecuteAsync(object? parameter)
        {
            _secrecyStampsProvider = new DatabaseSecrecyStampsProvider(_contextFactory);

            SecrecyStamps secrecyStamps = new(_secrecyStampsProvider);


        }
    }
}