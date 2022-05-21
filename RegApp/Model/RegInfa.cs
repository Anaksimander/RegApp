using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegApp.Model
{
    internal class RegInfa : INotifyPropertyChanged
    {
        private int _idUser;
        private string _login;
        private string _password1;
        private string _password2;
        private string _email;
        public string IdUser { get; set; }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password1
        {
            get { return _password1; }
            set
            {
                _password1 = value;
                OnPropertyChanged("Password1");
            }
        }
        public string Password2
        {
            get { return _password2; }
            set
            {
                _password2 = value;
                OnPropertyChanged("Password2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
