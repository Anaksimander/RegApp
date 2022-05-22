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
        private string _name;
        private string _email;
        private string _phone;
        private string _address;
        private string _city;
        private string _sex;
        private string _country;


        public int IdUser
        {
            get { return _idUser; }
            set
            {
                _idUser = value;
                OnPropertyChanged("IdUser");
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
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
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }
        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                OnPropertyChanged("Sex");
            }
        }
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
