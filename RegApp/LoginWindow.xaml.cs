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
using System.Windows.Shapes;

namespace RegApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly DataBaseWorker bd;
        public LoginWindow()
        {
            InitializeComponent();
            bd = new DataBaseWorker();
            bd.OpentConection();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = logBox.Text;
            string password = passBox.Password;

            bool check = true;
            string warning = "Это поле введено не корректно";

            if (login.Length > 12 || login.Length < 6)
            {
                check = false;
                logBox.ToolTip = warning;
                logBox.Background = Brushes.OrangeRed;
            }

            if (password.Length > 20 || password.Length < 6)
            {
                check = false;
                passBox.ToolTip = warning;
                passBox.Background = Brushes.OrangeRed;
            }



            if (check)
            {
                if (bd.ExecuteQuery($"SELECT login FROM UsersInfo WHERE login = '{logBox.Text}'") != null)
                {
                    MessageBox.Show("Успешно!");

                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegWindow().Show();
            Close();
        }
    }
}
