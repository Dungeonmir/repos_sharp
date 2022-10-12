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

namespace CaffeApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string[] dbStrings;
        public LoginWindow()
        {
            InitializeComponent();
            string[] DBconnString = new string[4];
            DBconnString[0] = "localhost";
            DBconnString[1] = "cafedb";
            DBconnString[2] = "root";
            DBconnString[3] = "";
            dbStrings = DBconnString;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            App.Current.Shutdown();
        }

        private void label_log_mouse_left_buton_up(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void btnDragMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DBconnection db= new DBconnection(dbStrings);
            string status = db.connect();
            if (status== "Connected")
            {
                string login = textboxLogin.Text;
                string passsword = textboxPassword.Password;
                MySql.Data.MySqlClient.MySqlDataReader reader =  db.execute($"Select login, password from user where login = '{login}' and password = '{passsword}';");
                int counter = db.getRowsCount(reader);
                if (counter > 0)
                {
                    MessageBox.Show($"Добро пожаловать, {login}!");
                    showMainWindow();

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");

                }

                
            }
            else
            {
                MessageBox.Show(status);
            }
        }

        private void showMainWindow()
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow(dbStrings);
            mainWindow.Show();
        }
    }
}
