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

namespace RegApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void regBtm_Click(object sender, RoutedEventArgs e)
        {
            string login = logBox.Text;
            string password = passBox.Password;
            string password2 = passBox2.Password;
            string email = emailBox.Text;

            bool check = true;

            if(login.Length > 12 || login.Length < 6)
            {
                check = false;
                logBox.ToolTip = "Это поле введено не коректно";
                logBox.Background = Brushes.OrangeRed;
            }

            if(password.Length > 20 || password.Length < 6)
            {
                check = false;
                passBox.ToolTip = "Это поле введено не коректно";
                passBox.Background = Brushes.OrangeRed;
            }

            if (password != password2 || password2 == "")
            {
                check = false;
                passBox2.ToolTip = "Это поле введено не коректно";
                passBox2.Background = Brushes.OrangeRed;
            }

            if (!(email.Contains('@') && email.Contains('.') && email.Length >= 5))
            {
                check = false;
                emailBox.ToolTip = "Это поле введено не коректно";
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

                MessageBox.Show("Успешно!");
            }
        }
    }
}
