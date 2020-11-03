using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisitorApp.Commands;
using DBServices.Services;
using VisitorApp.ViewModel;
using System.Net;

namespace VisitorApp.ViewModel
{
    class LoginWindowViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;

        private LoginService LoginService = new LoginService();

        public ParameterCommand<object> LoginCommand { get; set; }

        public LoginWindowViewModel()
        {
            LoginCommand = new ParameterCommand<object>(Login, canLogin);
        }
        private void Login(object passwordbox)
        {
            PasswordBox pass = passwordbox as PasswordBox;
            int visitor = LoginService.CheckLogin(Email, pass.Password);
            if ( visitor != 0)
            {
                // Store logged in user in Resources
                Application.Current.Resources.Add("user_id", visitor);

                Window win = new MainWindow();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = win;
                Application.Current.MainWindow.Show();
            }
            else 
            {
                MessageBox.Show("Login False");
            }
        }
        private bool canLogin(object passwordBox)
        {
            return true;
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
