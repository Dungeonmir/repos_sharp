using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace kursovayaWPF.Pages
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnBackToLoginClicked(object sender, MouseButtonEventArgs e)
        {
            Login log = new Login();
            NavigationService.Navigate(log);
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            string _name = name.Text;
            string _surname = surname.Text;
            string _fathersName = fathersName.Text;
            string _login = login.Text;
            string _password = password.Text;
            string _passwordCheck = passwordCheck.Text;
            string _email = email.Text;
            string _phone = phone.Text;

            _fathersName = _fathersName == "" ? null : fathersName.Text;
            bool isValid = validation(_name, _surname, _login, _password, 
                _passwordCheck, _email, _phone, _fathersName);
            if (isValid)
            {
                HashFunction hashFunction = new HashFunction();
                string passwordHash = hashFunction.makeHash(_password);
                registrate(_name, _surname, _login, passwordHash, _email, _phone, _fathersName);
                Login log = new Login();
                NavigationService.Navigate(log);
            }
           

        }
        private bool validation(string name, string surname, string login, string password,string passwordCheck
            ,string email, string phone, string fathersName = null)
        {
            string isStringPattern = "^[a-zA-Zа-яА-Я]{1,50}$";
            string isLoginPattern = "^[a-zA-Z0-9.-_]{5,50}$";
            string hasNumberPattern = "[0-9]+";
            string hasUpperChar = "[A-Z]+";
            string hasEnoughChars = ".{8,50}";
            string hasLowerChar = "[a-z]+";
            string hasSpecialSymbol = @"[;:<>|./?,!@#$%^&*()_+=\[{/\]}-]";
            string isEmailPattern = "^(\\D)+(\\w)*((\\.(\\w)+)?)+@(\\D)+(\\w)*((\\.(\\D)+(\\w)*)+)?(\\.)[a-z]{2,}$";
            string isPhonePattern = "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$";
            string errorLogin = "Логин введен неверно";
            string errorName = "Имя введено неверно";
            string errorSurname = "Фамилия введена неверно";
            string errorFathersName = "Отчество введена неверно";
            string errorPassNumber = "Пароль должен содержать хотя от бы одну цифру";
            string errorPassChars = "Пароль должен содержать от 8 до 50 символов";
            string errorPassLowerChar = "Пароль должен содержать хотя бы один символ нижнего регистра";
            string errorPassUpperChar = "Пароль должен содержать хотя бы один символ верхнего регистра";
            string errorPassSpecialSymbol = "Пароль должен содержать хотя бы один специальный символ";
            string errorPassCheckFailed = "Пароли не совпадают";
            string errorLoginIsNotUnique = "Пользователь с таким логином уже существует";
            string errorEmail = "Почта введенна неверно";
            string errorPhone = "Телефон должен быть записан в формате 8 цифр";
            
            if (strHasErrors(name, isStringPattern, errorName)) return false;
            if (strHasErrors(surname, isStringPattern, errorSurname)) return false;
            if (strHasErrors(login, isLoginPattern, errorLogin)) return false;
            if (strHasErrors(password, hasNumberPattern, errorPassNumber)) return false;
            if (strHasErrors(password, hasEnoughChars, errorPassChars)) return false;
            if (strHasErrors(password, hasLowerChar, errorPassLowerChar)) return false;
            if (strHasErrors(password, hasUpperChar, errorPassUpperChar)) return false;
            if (strHasErrors(password, hasSpecialSymbol, errorPassSpecialSymbol)) return false;
            if (strHasErrors(email, isEmailPattern, errorEmail)) return false;
            if (strHasErrors(phone, isPhonePattern, errorPhone)) return false;
            if (password != passwordCheck)
            {
                MessageBox.Show(errorPassCheckFailed);
                return false;
            }
            if (fathersName != null)
            {
                if (strHasErrors(fathersName, isStringPattern, errorFathersName)) return false;
            }
            if (!isLoginUnique(login))
            {
                MessageBox.Show(errorLoginIsNotUnique);
                return false;
            }
            return true;
        }
        private bool strHasErrors(string str, string pattern, string errorMessage)
        {
            bool hasError = false;
            hasError = !validateStr(str, pattern);
            if(hasError)
            {
                MessageBox.Show(errorMessage);
                
            }
            return hasError;
        }
        private bool validateStr(string str, string pattern)
        {
            bool isValid = true;
            WordFilterNS.WordFilter wordFilter = new WordFilterNS.WordFilter();
            
            if(!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase)) isValid = false;
            if(wordFilter.Blacklisted(str)) isValid = false;
            return isValid;
            
        }
        private void registrate(string name, string surname, string login, 
            string passwordHash,string email, string phone, string fathersName = null)
        {
            cafeEntities ent = new cafeEntities();
            try
            {


                User newUser = new User()
                {
                    name = name,
                    surname = surname,
                    login = login,
                    password = passwordHash,
                    fathersName = fathersName,
                    email = email,
                    phone = phone,
                    idUserRole = 1
                };
                ent.Users.Add(newUser);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            ent.SaveChanges();
        }
        private bool isLoginUnique(string login)
        {
            cafeEntities ent = new cafeEntities();

            var l = (from p in ent.Users
                     where p.login == login
                     select p.login).Count();

          return l==0? true: false;
        }
    }
}
