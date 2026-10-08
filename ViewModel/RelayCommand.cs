using System;
using System.Windows.Input;

namespace ProjektReolmarked.ViewModel
{
    // Lets a button in the View run a method in the ViewModel
    public class RelayCommand : ICommand
    {
        private Action<object?> execute;

        public RelayCommand(Action execute)
        {
            this.execute = _ => execute();
        }

        public RelayCommand(Action<object?> execute)
        {
            this.execute = execute;
        }

        // Required by ICommand
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}