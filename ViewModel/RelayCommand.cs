using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjektReolmarked.ViewModel
{
    // Lets a button in the View run a method in the ViewModel
    public class RelayCommand : ICommand
    {
        private Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        // Required by ICommand
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // The button can always be clicked
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        // Runs the method when the button is clicked
        public void Execute(object? parameter)
        {
            execute();
        }
    }
}
