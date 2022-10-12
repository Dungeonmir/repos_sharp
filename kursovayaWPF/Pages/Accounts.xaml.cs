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
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Page
    {
        User user;
        public Accounts(User user)
        {
            this.user = user;
            InitializeComponent();
            userList.ItemsSource = cafeEntities.getContext().Users.ToList();
        }

        private void selected(object sender, SelectionChangedEventArgs e)
        {
            User selectedUser = (userList.SelectedItem as User);
            EditUser editUser = new EditUser(user,true ,selectedUser);
            NavigationService.Navigate(editUser);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(user);
            NavigationService.Navigate(menu);
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            
            EditUser editUser = new EditUser(user, false);
            NavigationService.Navigate(editUser);
        }
    }
}
