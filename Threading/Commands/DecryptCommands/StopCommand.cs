using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Threading
{
    public class StopCommand : ICommand
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public StopCommand(MainWindowViewModel MainWindowViewModel)
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
            if (MainWindowViewModel.Decrypt_thread.ThreadState
                 != ThreadState.Aborted)
            {
                MainWindowViewModel.Decrypt_thread.Abort();
            }
        }
    }
}
