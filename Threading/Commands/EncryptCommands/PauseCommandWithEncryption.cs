using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Threading.Commands
{
    public class PauseCommandWithEncryption : ICommand
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public PauseCommandWithEncryption(MainWindowViewModel MainWindowViewModel)
        {
            this.MainWindowViewModel = MainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        [Obsolete]
        public void Execute(object parameter)
        {
            if (MainWindowViewModel.Encrypt_thread.ThreadState 
                != ThreadState.Stopped)
            {
                MainWindowViewModel.Encrypt_thread.Suspend();
            }
        }
    }
}
