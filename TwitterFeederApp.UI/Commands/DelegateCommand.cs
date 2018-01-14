using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TwitterFeederApp.UI.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action _Execute;
        
        public DelegateCommand(Action execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _Execute = execute;
        }

        public DelegateCommand(Action execute)
          : this(execute, null)
        {
        }
        
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;
            _Execute();
        }
        
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
