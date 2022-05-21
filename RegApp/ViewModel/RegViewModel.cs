using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RegApp.Model;

namespace RegApp.ViewModel
{
    public class RegViewModel : INotifyPropertyChanged
    {
        private readonly RegInfa regInfa = new();
        public string Login
        {
            get { return regInfa.Login; }
            set
            {
                regInfa.Login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Email
        {
            get { return regInfa.Email; }
            set
            {
                regInfa.Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password1
        {
            get { return regInfa.Password1; }
            set
            {
                regInfa.Password1 = value;
                OnPropertyChanged("Password1");
            }
        }
        public string Password2
        {
            get { return regInfa.Password2; }
            set
            {
                regInfa.Password2 = value;
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
