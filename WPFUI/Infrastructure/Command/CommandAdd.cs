using Microsoft.Win32;
using PASEDM.Infrastructure.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASEDM.Infrastructure.Command
{
    public class CommandAdd : BaseCommand
    {
        private Action value;

        public CommandAdd(Action value)
        {
            this.value = value;
        }

        public override void Execute(object? parameter)
        {
            /*OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();*/
            int r = 1;
        }
    }
}
