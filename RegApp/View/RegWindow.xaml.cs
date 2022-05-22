using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegApp;

namespace RegApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        private readonly DataBaseWorker bd;
        public RegWindow()
        {
            InitializeComponent();
            bd = new DataBaseWorker();
            bd.OpentConection();
        }

        private void RegBtm_Click(object sender, RoutedEventArgs e)
        {
            string login = logBox.Text;
            string password = passBox.Password;
            string password2 = passBox2.Password;
            string email = emailBox.Text;

            bool check = true;
            string warning = "Это поле введено не корректно";

            if (login.Length > 12 || login.Length < 6)
            {
                check = false;
                logBox.ToolTip = warning;
                logBox.Background = Brushes.OrangeRed;
            }

            if(password.Length > 20 || password.Length < 6)
            {
                check = false;
                passBox.ToolTip = warning;
                passBox.Background = Brushes.OrangeRed;
            }

            if (password != password2 || password2 == "")
            {
                check = false;
                passBox2.ToolTip = warning;
                passBox2.Background = Brushes.OrangeRed;
            }

            if (!(email.Contains('@') && email.Contains('.') && email.Length >= 5))
            {
                
                emailBox.ToolTip = warning;
                emailBox.Background = Brushes.OrangeRed;
            }

            if (bd.ExecuteQuery($"SELECT login FROM UsersInfo WHERE login = '{logBox.Text}'") != null)
            {
                check = false;
                emailBox.ToolTip = "Пользователь с таким логином уже существует";
                emailBox.Background = Brushes.OrangeRed;
            }

            if (bd.ExecuteQuery($"SELECT login FROM UsersInfo WHERE login = '{emailBox.Text}'") != null)
            {
                check = false;
                emailBox.ToolTip = "Пользователь с таким email уже существует";
                emailBox.Background = Brushes.OrangeRed;
            }


            if (check)
            {
                logBox.ToolTip = "";
                logBox.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;

                emailBox.ToolTip = "";
                emailBox.Background = Brushes.Transparent;

                
                bd.ExecuteQuery($"INSERT INTO UsersInfo (login, password, email) VALUES('{logBox.Text}', '{passBox.Password}', '{emailBox.Text}')");
                bd.CloseConection(); 
                new LoginWindow().Show();
                Close();
            }

        }


        private void LogBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            logBox.Background = Brushes.Transparent;
            passBox.Background = Brushes.Transparent;
            passBox2.Background = Brushes.Transparent;
            emailBox.Background = Brushes.Transparent;
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
    }
}
