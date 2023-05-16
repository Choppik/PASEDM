using Microsoft.Win32;
using PASEDM.Infrastructure.Command.Base;
using PASEDM.ViewModels;
using System;
using System.IO;

namespace PASEDM.Infrastructure.Command
{
    public class AddDocCommand : BaseCommand
    {

        public string FilePath { get; set; }
        public DateTime DateOfFormationDocument { get; set; }
        private OpenFileDialog openFileDialog1 { get; set; }
        public AddDocCommand() { }

        public AddDocCommand(OpenFileDialog openFileDialog)
        {
            openFileDialog1 = openFileDialog;
        }

        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
/*            FilePath = openFile.FileName;
            DateOfFormationDocument = File.GetLastWriteTime(FilePath);*/
        }
    }
}