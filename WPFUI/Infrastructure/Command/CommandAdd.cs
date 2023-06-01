using Microsoft.Win32;
using PASEDM.Infrastructure.Command.Base;
using System;

namespace PASEDM.Infrastructure.Command
{
    public class CommandAdd : BaseCommand
    {
        private Action value;

        public CommandAdd()
        {
        }

        public override void Execute(object? parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
        }
    }
}
