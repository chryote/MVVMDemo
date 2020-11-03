using DBServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VisitorApp.Commands;
using VisitorApp.Model;
using VisitorApp.ViewModel;

namespace VisitorApp
{
    class MainWindowViewModel : BindableBase
    {
        public ParameterCommand<string> NavCommand { get; private set; }

        private LoginService LoginService = new LoginService();

        private BindableBase _currentViewModel;

        // Child View Model
        private BindableBase _homeViewModel = new HomeViewModel();
        private BindableBase _tourListViewModel = new TourListViewModel();
        public Visitor CurrentVisitor { get; set; }

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
            NavCommand = new ParameterCommand<string>(SwitchView);
            CurrentViewModel = _tourListViewModel;

            // Fix error if login disabled
            int user_id = (int) Application.Current.Resources["user_id"];
            // int user_id = 3;
            var visitor = LoginService.GetUserByID(user_id);

            CurrentVisitor = new Visitor {
                VisitorID = visitor.VisitorModelID,
                Name = visitor.Name,
                Age = visitor.Age,
                Gender = visitor.Gender,
                Email = visitor.Email,
            };
        }

        private void SwitchView(string view)
        {
            switch (view)
            {
                case "myTour":
                    CurrentViewModel = _homeViewModel;
                    break;

                case "tourList":
                    CurrentViewModel = _tourListViewModel;
                    break;
            }
        }
    }
}
