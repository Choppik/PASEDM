﻿using System;
using System.Windows.Input;

namespace PASEDM.Infrastructure.Command.Base
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        /*{
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }*/

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);
        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
