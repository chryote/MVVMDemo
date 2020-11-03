using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;
using DBServices.Services;
using MVVMDemo.Commands;
using System.Dynamic;
using System.Windows;

namespace MVVMDemo.ViewModel
{
    class VisitorListViewModel : BindableBase
    {
        VisitorService VisitorManager = new VisitorService();
        public MyCommand DeleteVisitorCommand { get; set; }
        private Visitor _selectedVisitor;
        public VisitorListViewModel()
        {
            LoadVisitors();
            DeleteVisitorCommand = new MyCommand(DeleteVisitor, canDelete);
        }

        public ObservableCollection<Visitor> Visitors
        {
            get;
            set;
        }

        public Visitor SelectedVisitor
        {
            get
            {
                return _selectedVisitor;
            }
            set
            {
                _selectedVisitor = value;
                DeleteVisitorCommand.RaiseEventChange();
            }
        }


        public void LoadVisitors()
        {
            ObservableCollection<Visitor> visitors = new ObservableCollection<Visitor>();
            var visitor_list =  VisitorManager.GetVisitors();

            foreach (var v in visitor_list)
            {
                visitors.Add(new Visitor { 
                    VisitorID = v.VisitorModelID,
                    Name = v.Name, 
                    Email = v.Email, 
                    Gender = v.Gender, 
                    Age = v.Age });
            }
            Visitors = visitors;
        }

        public void DeleteVisitor()
        {
            if (((ICRUDService)VisitorManager).Delete(SelectedVisitor.VisitorID))
            {
                Visitors.Remove(SelectedVisitor);
                MessageBox.Show("Item Deleted");
            }
        }

        public bool canDelete()
        {
            return SelectedVisitor != null;
        }
    }
}
