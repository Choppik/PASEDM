using PASEDM.Data;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASEDM.Infrastructure.Command
{
    public class CreateCardCommand : AsyncBaseCommand
    {
        private string _userName;
        private string _password;
        private int _employee;

        private readonly CreateCardViewModel _createCardViewModel;
        private readonly PASEDMDbContextFactory _deferredContextFactory;

        private IEmployeeProvider _employeeProvider;
        private ITasksProvider _tasksProvider;
        private ICasesProvider _casesProvider;
        private IDocTypProvider _docTypProvider;
        private IUserProvider _userProvider;
        private IDeadlinesProvider _deadlinesProvider;

        public CreateCardCommand(CreateCardViewModel createCardViewModel, PASEDMDbContextFactory deferredContextFactory)
        {
            _createCardViewModel = createCardViewModel;
            _deferredContextFactory = deferredContextFactory;
        }

        public override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}