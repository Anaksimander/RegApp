using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegApp.Model
{
    internal class User : INotifyPropertyChanged
    {
        private int    _idUser;
        private string _login;
        private string _password;
        private string _name;
        private string _email;
        private string _phone;
        private string _address;
        private string _city;
        private string _sex;
        private string _country;



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
