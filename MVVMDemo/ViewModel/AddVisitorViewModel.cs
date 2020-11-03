using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Commands;
using MVVMDemo.Model;
using DBServices.Services;
using System.Collections.ObjectModel;
using DBServices.Models;

namespace MVVMDemo.ViewModel
{
    class AddVisitorViewModel : BindableBase
    {
        public MyCommand StoreNewVisitor { get; set; }
        public ObservableCollection<Visitor> Visitors { get; set; }
        public string Test { get; set; }

        public AddVisitorViewModel()
        {
            StoreNewVisitor = new MyCommand(StoreVisitor, canStore);
            ObservableCollection<Visitor> visitors = new ObservableCollection<Visitor>();

            visitors.Add(new Visitor{ Name = "Hahahaha", Email = "Haha@gmail.com", Gender = "Male", Age = 50,});

            Visitors = visitors;
            Test = Visitors.First().Name;
        }
        private void StoreVisitor()
        {
            VisitorService VisitorManager = new VisitorService();
            var visitor = Visitors.First();

            ((ICRUDService)VisitorManager).Create(
                visitor.Name,
                visitor.Email,
                visitor.Age,
                visitor.Gender,
                visitor.Password
            );
        }
        private bool canStore()
        {
            return true;
        }
    }
}
