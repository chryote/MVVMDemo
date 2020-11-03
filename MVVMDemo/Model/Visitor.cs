using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Model
{
    class Visitor : INotifyPropertyChanged
    {
        private int _visitorID;
        private string _name;
        private string _email;
        private string _gender;
        private string _password;
        private int _age;

        public int VisitorID
        {
            get
            {
                return _visitorID;
            }
            set
            {
                _visitorID = value;
            }
        }
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                if(_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public string Email 
        {
            get
            {
                return _email;
            }
            set
            {
                if(_email != value)
                {
                    _email = value;
                    RaisePropertyChanged("Email");
                }
            }
        }
        public string Password 
        {
            get
            {
                return _password;
            }
            set
            {
                if(_password != value)
                {
                    _password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    RaisePropertyChanged("Gender");
                }
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
