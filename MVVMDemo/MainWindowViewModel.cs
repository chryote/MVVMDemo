using MVVMDemo.Commands;
using MVVMDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo
{
    class MainWindowViewModel : BindableBase
    {
        public NavigationCommand<string> NavCommand { get; private set; }

        private BindableBase _currentViewModel;

        // Child View Model
        private BindableBase _studentViewModel = new StudentViewModel();
        private BindableBase _loginViewModel = new LoginViewModel();
        private BindableBase _visitorViewModel = new VisitorViewModel();

        public BindableBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }

        public MainWindowViewModel()
        {
            NavCommand = new NavigationCommand<string>(SwitchView);
            CurrentViewModel = _visitorViewModel;
        }

        private void SwitchView(string view)
        {
            switch (view)
            {
                case "student":
                    CurrentViewModel = _studentViewModel;
                    break;

                case "login":
                    CurrentViewModel = _loginViewModel;
                    break;

                case "visitor":
                    CurrentViewModel = _visitorViewModel;
                    break;
            }
        }
    }
}
