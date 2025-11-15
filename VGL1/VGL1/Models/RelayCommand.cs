using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VGL1.Models
{
    public class RelayCommand<T> :ICommand
    {
        private Action<T> _execute;
        private Predicate<T>? _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
            => _canExecute?.Invoke((T)parameter!) ?? true;

        public void Execute(object? parameter)
            => _execute?.Invoke((T)parameter!);

        public event EventHandler? CanExecuteChanged;
    }
}
