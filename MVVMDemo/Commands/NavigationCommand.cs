using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Commands
{
    class NavigationCommand<Tipe> : ICommand
    {
        Action<Tipe> _TargetExecuteMethod;
        Func<Tipe, bool> _TargetCanExecuteMethod;

        public event EventHandler CanExecuteChanged = delegate { };

        public NavigationCommand(Action<Tipe> executeMethod){
            _TargetExecuteMethod = executeMethod;
        }

        public NavigationCommand(Action<Tipe> executeMethod, Func<Tipe, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseEventChange()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if(_TargetCanExecuteMethod != null)
            {
                Tipe tparm = (Tipe)parameter;
                return _TargetCanExecuteMethod(tparm);
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod((Tipe)parameter);
            }
        }
    }
}
