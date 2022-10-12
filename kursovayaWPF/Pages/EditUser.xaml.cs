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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        bool shouldUpdate;
        User user;
        User editUser;
        public EditUser(User user, bool shouldUpdate, User userToUpdate = null)
        {
            this.shouldUpdate = shouldUpdate;
            this.user = user;
            editUser = userToUpdate;
            InitializeComponent();

            if (shouldUpdate)
            {
                if (user.UserRole.roleName == "admin")
                {
                    comboboxUserRole.ItemsSource = cafeEntities.getContext().UserRoles.ToList();
                    comboboxUserRole.SelectedIndex = comboboxUserRole.Items.IndexOf(userToUpdate.UserRole);
                    
                }
                else
                {
                    comboboxUserRole.Visibility = Visibility.Hidden;
                }
                textboxEmail.Text = userToUpdate.email;
                textboxLogin.Text = userToUpdate.login;
                textboxName.Text = userToUpdate.name;
                textboxPhone.Text = userToUpdate.phone;
                textboxFathersName.Text = userToUpdate.fathersName;
                textboxSurname.Text = userToUpdate.surname;

            }
            else
            {
                comboboxUserRole.ItemsSource = cafeEntities.getContext().UserRoles.ToList();
                comboboxUserRole.SelectedIndex = 0;
            }
            
            
        }
        private void btnBack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Menu menu= new Menu(user);
            NavigationService.Navigate(menu);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            User data = new User();
            data = getDataFromTextBoxes();
            if (validateUser(data))
            {
                editUser = data;
                if (shouldUpdate)
                    updateUsers();
                else
                    addUser();
                
            }
            
        }

        private User getDataFromTextBoxes()
        {
            User dataUser = new User();
            dataUser.name = textboxName.Text;
            dataUser.email = textboxEmail.Text;
            dataUser.phone = textboxPhone.Text;
            dataUser.surname = textboxSurname.Text;
            dataUser.fathersName = textboxFathersName.Text;
            if (shouldUpdate)
            {
                dataUser.idUser = editUser.idUser;
                dataUser.password = editUser.password;
            }
            dataUser.login = textboxLogin.Text;
            if (textboxPassword.Text != "")
            {
                dataUser.password = textboxPassword.Text;
            }

            if (comboboxUserRole.Visibility != Visibility.Hidden)
            {
                dataUser.idUserRole = (comboboxUserRole.SelectedItem as UserRole).idUserRole;
            }
            else
            {
                dataUser.idUserRole = cafeEntities.getContext().UserRoles.Where(r => r.roleName == "user").FirstOrDefault().idUserRole;
            }
            return dataUser;
        }
        private void addUser()
        {
            editUser.password = makeHash(editUser.password);
            cafeEntities.getContext().Users.Add(editUser);
            cafeEntities.getContext().SaveChanges();
        }
        private bool validateUser(User user)
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
            string errorLoginIsNotUnique = "Пользователь с таким логином уже существует";
            string errorEmail = "Почта введенна неверно";
            string errorPhone = "Телефон должен быть записан в формате 8 цифр";

            
            if (strHasErrors(user.name, isStringPattern, errorName)) return false;
            if (strHasErrors(user.surname, isStringPattern, errorSurname)) return false;

            if (!shouldUpdate)
            {
                if (strHasErrors(user.login, isLoginPattern, errorLogin)) return false;
                if (!isLoginUnique(user.login))
                {
                    MessageBox.Show(errorLoginIsNotUnique);
                    return false;
                }
            }
            else
            {
                if (editUser.login != user.login)
                {
                    if (strHasErrors(user.login, isLoginPattern, errorLogin)) return false;
                    if (!isLoginUnique(user.login))
                    {
                        MessageBox.Show(errorLoginIsNotUnique);
                        return false;
                    }
                }
            }

            if (textboxPassword.Text != "" || !shouldUpdate)
            {
                if (strHasErrors(user.password, hasNumberPattern, errorPassNumber)) return false;
                if (strHasErrors(user.password, hasEnoughChars, errorPassChars)) return false;
                if (strHasErrors(user.password, hasLowerChar, errorPassLowerChar)) return false;
                if (strHasErrors(user.password, hasUpperChar, errorPassUpperChar)) return false;
                if (strHasErrors(user.password, hasSpecialSymbol, errorPassSpecialSymbol)) return false;
            }
            
            if (strHasErrors(user.email, isEmailPattern, errorEmail)) return false;
            if (strHasErrors(user.phone, isPhonePattern, errorPhone)) return false;
            if (user.fathersName != null)
            {
                if (strHasErrors(user.fathersName, isStringPattern, errorFathersName)) return false;
            }
            
            return true;

        }
        private bool isLoginUnique(string login)
        {
            cafeEntities ent = new cafeEntities();

            var l = (from p in ent.Users
                     where p.login == login
                     select p.login).Count();

            return l == 0 ? true : false;
        }

        private bool strHasErrors(string str, string pattern, string errorMessage)
        {
            bool hasError = false;
            if (str != null)
            {
                hasError = !validateStr(str, pattern);
            }
            else
            {
                hasError = true;
            }
            if (hasError)
            {
                MessageBox.Show(errorMessage);

            }
            return hasError;
        }
        private bool validateStr(string str, string pattern)
        {
            bool isValid = true;
            WordFilterNS.WordFilter wordFilter = new WordFilterNS.WordFilter();

            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase)) isValid = false;
            if (wordFilter.Blacklisted(str)) isValid = false;
            return isValid;

        }
        private void updateUsers()
        {
            User updatedUser = cafeEntities.getContext().Users.Where(u => u.idUser == editUser.idUser).SingleOrDefault();
            updatedUser.email = editUser.email;
            updatedUser.phone = editUser.phone;
            updatedUser.idUserRole = editUser.idUserRole;
            updatedUser.name = editUser.name;
            updatedUser.login = editUser.login;
            updatedUser.surname = editUser.surname;
            updatedUser.password = makeHash(editUser.password);
            updatedUser.fathersName = editUser.fathersName;
            cafeEntities.getContext().SaveChanges();
        }
        private string makeHash(string pass)
        {
            HashFunction hashFunction = new HashFunction();
            return hashFunction.makeHash(pass);
        }
    }
}
