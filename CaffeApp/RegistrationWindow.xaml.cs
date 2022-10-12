using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CaffeApp
{
    
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        
        public RegistrationWindow()
        {
            InitializeComponent();
        }
      
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            App.Current.Shutdown();
        }

        private void label_log_mouse_left_buton_up(object sender, MouseButtonEventArgs e)
        {
            Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void btnDragMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db =  getConnection(dbStrings);

            Dictionary<string, string> validation = new Dictionary<string, string>();

            string surname = textboxSurname.Text;
            string name = textboxName.Text;
            string fathersName = textboxFathersName.Text;
            string login = textboxLogin.Text;
            string password = textboxPassword.Password;

            bool surnameMatches = checkStr(surname, "^[a-zA-Zа-яА-Я]{1,50}$");
            bool nameMatches = checkStr(name, "^[a-zA-Zа-яА-Я]{1,50}$");
            bool fathersNameMatches = checkStr(fathersName, "^[a-zA-Zа-яА-Я]{0,50}$");
            bool loginMatches = checkStr(login, "^[a-zA-Z0-9]{5,50}$");
            bool pswHasNumber = checkStr(password, "[0-9]+");
            bool pswHasUpperChar = checkStr(password, "[A-Z]+");
            bool pswHasEnoughChars = checkStr(password, ".{8,50}");
            bool pswHasLowerChar = checkStr(password, "[a-z]+");
            bool pswHasSpecialSymbols = checkStr(password, @"[;:<>|./?,!@#$%^&*()_+=\[{/\]}-]");
            bool pswsMatches = textboxPassword.Password == textboxPasswordCheck.Password;


            if (!surnameMatches) validation["Surname"] = "Фамилия введена неверно";
            if (!nameMatches) validation["Name"] = "Имя введено неверно";
            if (!fathersNameMatches) validation["FathersName"] = "Отчество введено неверно";
            if (!loginMatches) validation["Login"] = "Логин введен неверно";
            if (!pswHasNumber) validation["Password"] = "Пароль должен содержать хотя бы одну цифру";
            if (!pswHasUpperChar) validation["Password"] = "Пароль должен содержать хотя бы одну заглавную букву";
            if (!pswHasEnoughChars) validation["Password"] = "Пароль должен содержать от 8 до 50 символов";
            if (!pswHasLowerChar) validation["Password"] = "Пароль должен содержать хотя бы одну маленькую букву";
            if (!pswHasSpecialSymbols) validation["Password"] = "Пароль должен содержать хотя бы один специальный символ";
            if (!pswsMatches) validation["PasswordMatches"] = "Пароль повторен неверно";


            foreach (string key in validation.Keys)
            {
                MessageBox.Show(validation[key]);
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 20, 20));
                SolidColorBrush oldBrush = new SolidColorBrush(Color.FromRgb(180, 204, 82));
                
                textboxPassword.Background = oldBrush;
                textboxPasswordCheck.Background = oldBrush;
                textboxFathersName.Background = oldBrush;
                textboxLogin.Background = oldBrush;
                textboxName.Background = oldBrush;
                textboxPassword.Background = oldBrush;
                textboxSurname.Background = oldBrush;
                
                switch (key)
                {
                    case "Surname":
                        textboxSurname.Focus();
                        textboxSurname.Background = brush;
                        break;
                    case "Name":
                        textboxName.Focus();
                        textboxName.Background = brush;
                        break;
                    case "FathersName":
                        textboxFathersName.Focus();
                        textboxFathersName.Background= brush;
                        break;
                    case "Login":
                        textboxLogin.Focus();
                        textboxLogin.Background = brush;
                        break;
                    case "Password":
                        textboxPassword.Focus();
                        textboxPassword.Background= brush;
                        break;
                    case "PasswordMatches":
                        textboxPasswordCheck.Focus();
                        textboxPassword.Background = brush;
                        textboxPasswordCheck.Background = brush;
                        break;
                    default:
                        break;
                }
                break;
            }
            if (validation.Count==0)
            {
                string query = $"INSERT INTO `user`(`name`, `surname`, `fathersName`, `login`, `password`, `user_type_idUserType`) VALUES ('{name}','{surname}','{fathersName}','{login}','{password}', '1')";
                MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
                command.ExecuteNonQuery();
                db.mySqlConnection.Close();
                
                //Вернуть на экран входа
                Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();

            }

        }
        private bool checkStr(string input, string regexStr)
        {
            Regex regex = new Regex(regexStr);
            return regex.IsMatch(input) ? true : false;
        }

        private DBconnection? getConnection(string[] dbStrings)
        {

            DBconnection db = new DBconnection(dbStrings);
            string status = db.connect();
            if (status == "Connected")
            {
                return db;
            }
            else
            {
                MessageBox.Show("Подключение к бд невозможно");
                return null;
            }
        }
    }
}
