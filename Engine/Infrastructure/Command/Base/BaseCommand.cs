using System.Windows.Input;

namespace PASEDM.Infrastructure.Command.Base
{
    internal abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);
    }
}
