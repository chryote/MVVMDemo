using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;
using DBServices.Services;
using MVVMDemo.Commands;
using System.Windows;
using System.Reflection.Emit;

namespace MVVMDemo.ViewModel
{
    class VisitorViewModel : BindableBase
    {
        public NavigationCommand<string> VisitorNavCommand { get; private set; }

        private BindableBase _currentVisitorViewModel;

        private BindableBase _addNewVisitorView = new AddVisitorViewModel();
        private BindableBase _visitorListView = new VisitorListViewModel();
        public string MyText { get; set; }

        public BindableBase CurrentVisitorViewModel
        {
            get
            {
                return _currentVisitorViewModel;
            }
            set
            {
                SetProperty(member: ref _currentVisitorViewModel, val: value);
            }
        }

        public VisitorViewModel()
        {
            VisitorNavCommand = new NavigationCommand<string>(SwitchVisitorView);
            _currentVisitorViewModel = _addNewVisitorView;
        }

        private void SwitchVisitorView(string view)
        {
            switch (view)
            {
                case "add":
                    CurrentVisitorViewModel = _addNewVisitorView;
                    break;

                case "list":
                    CurrentVisitorViewModel = _visitorListView;
                    break;
            }
        }
    }
}
