using stroyka.db;
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

namespace stroyka.pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationClicked(object sender, MouseButtonEventArgs e)
        {
            LoginPage page = new LoginPage();
            NavigationService.Navigate(page);
        }

        private void btnRegistrate_Click(object sender, RoutedEventArgs e)
        {
          
            User newUser =  getNewUser();
            if (newUser!=null)
            {
                dbStroyka.getContext().Users.Add(newUser);
                dbStroyka.getContext().SaveChanges();
            }
            
        }
        private User getNewUser()
        {
            User user = new User();
            user.phone = boxPhone.Text;
            user.email = boxEmail.Text;
            user.birthday = (DateTime)boxDate.SelectedDate;
            user.firstName = boxFirstName.Text;
            user.secondName = boxSecondName.Text;
            user.middleName = boxMiddleName.Text;
            user.idRole = dbStroyka.getContext().Roles.Where(role => role.name == "Пользователь").Single().idRole;
            if (dbStroyka.getContext().Users.Where(u => u.login == boxLogin.Text).SingleOrDefault() != null)
            {
                user.login = boxLogin.Text;
            }
            else
            {
                MessageBox.Show("Логин уже существует");
                return null;
            }
            if (boxPass.Text==boxPassCheck.Text)
            {
                user.password = boxPass.Text;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
                return null;
            }
            return user;
        }
    }
}
