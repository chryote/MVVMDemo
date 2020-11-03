using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;
using MVVMDemo.Commands;
using System.Collections.ObjectModel;

namespace MVVMDemo.ViewModel
{
    class StudentViewModel : BindableBase
    {
        public MyCommand DeleteCommand { get; set; }

        private Student _selectedStudent; 

        public StudentViewModel()
        {
            LoadStudent();
            DeleteCommand = new MyCommand(onDelete, canDelete);
        }

        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudent()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Bima", LastName = "Wiratama" });
            students.Add(new Student { FirstName = "Bima", LastName = "Kope" });
            students.Add(new Student { FirstName = "Bimo", LastName = "Wirotomo" });

            Students = students;
        }

        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                DeleteCommand.RaiseEventChange();
            }
        }

        private void onDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool canDelete()
        {
            return SelectedStudent != null;
        }
    }
}
