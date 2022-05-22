using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RegApp;
using RegApp.Model;

namespace RegApp.ViewModel
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        private readonly DataBaseWorker bd;
        User _selectedUser;
        public User SelectedUser {
            get { return _selectedUser; }
            set { 
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public UserViewModel(string id_user)
        {
            bd = new DataBaseWorker();
            bd.OpentConection();
            List<string> list = bd.ExecuteQueryRow($"SELECT login, name, email, phone, address, city, sex, country FROM UsersInfo WHERE id_user = '{id_user}'",8);
            
            _selectedUser = new User()
            {
                Login = list[0],
                Name = list[1],
                Email = list[2],
                Phone = list[3],
                Address = list[4],
                City = list[5],
                Sex = list[6],
                Country = list[7],
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
