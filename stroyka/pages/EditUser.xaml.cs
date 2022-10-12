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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        public User newUser = new User();
        public EditUser()
        {
            InitializeComponent();

            boxRole.ItemsSource = dbStroyka.getContext().Roles.ToList();
        }

        public User GetUser()
        {
            newUser.phone = boxPhone.Text;
            newUser.email = boxEmail.Text;
            newUser.birthday = (DateTime)boxDate.SelectedDate;
            newUser.firstName = boxFirstName.Text;
            newUser.secondName = boxSecondName.Text;
            newUser.middleName = boxMiddleName.Text;
            newUser.idRole = dbStroyka.getContext().Roles.Where(role => role.name == boxRole.Text).Single().idRole;
            newUser.login = boxLogin.Text;
            newUser.password = boxPass.Text;
            
            return newUser;
        }
        public void SetUser(User user)
        {
            newUser = user;
            boxPhone.Text = newUser.phone;
            boxEmail.Text = newUser.email;
            boxDate.SelectedDate = newUser.birthday;
            boxFirstName.Text = newUser.firstName;
            boxSecondName.Text = newUser.secondName;
            boxMiddleName.Text = newUser.middleName;
            boxLogin.Text = newUser.login;
            boxPass.Text = newUser.password;
            boxRole.SelectedItem = dbStroyka.getContext().Roles.Where(role => role.name == newUser.Role.name).Single();

        }

    }
}
