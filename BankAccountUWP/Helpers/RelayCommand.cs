using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankAccountUWP.Helpers
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute  = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object  parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged
        {
            add => CommandManagerHepler.AddCanExecuteChangedHandler(value);
            remove => CommandManagerHepler.RemoveCanExecuteChangedHandler(value);
        }

    }
    static class CommandManagerHepler

    {
        private static event EventHandler _handlers;
        public static void AddCanExecuteChangedHandler(EventHandler handler) => _handlers += handler;
        public static void RemoveCanExecuteChangedHandler(EventHandler handler) => _handlers -= handler;
        public static void RaiseCanExecuteChanged() => _handlers?.Invoke(null, EventArgs.Empty);
    }
}
