﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Threading.Commands
{
    public class ResumeCommandWithEncryption : ICommand
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public ResumeCommandWithEncryption(MainWindowViewModel MainWindowViewModel)
        {
            this.MainWindowViewModel = MainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}