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

namespace kursovayaWPF.Pages
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        User userAccount;
        public Account(User user)
        {
            InitializeComponent();
            userAccount = user;
            textBlockName.Text = "Имя: "+user.name;
            textBlockSurname.Text = "Фамилия: " + user.surname;
            if (user.fathersName != null)
            {
                textBlockFathersName.Text = "Отчество: " + user.fathersName;
            }
            else
            {
                textBlockFathersName.Text = "Отчество не указано";
            }
            textBlockLogin.Text = "Логин: " + user.login;
            textBlockRole.Text ="Роль: "+ cafeEntities.getContext().UserRoles.Where(
                r => r.idUserRole == user.idUserRole).FirstOrDefault().roleName;
            textBlockEmail.Text = "Email: " + user.email;
            textBlockPhone.Text = "Телефон: " + user.phone;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(userAccount);
            NavigationService.Navigate(menu);
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            EditUser edit = new EditUser(userAccount, true, userAccount);
            NavigationService.Navigate(edit);
        }
    }
}
