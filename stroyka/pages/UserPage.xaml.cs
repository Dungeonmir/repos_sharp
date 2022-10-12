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
using stroyka.db;
namespace stroyka.pages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        User currentUser;
        public UserPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            listViewUsers.ItemsSource = dbStroyka.getContext().Users.Where(u=>u.login!="guest").ToList();
        }

        private void Itemselected(object sender, SelectionChangedEventArgs e)
        {
            User editUser = listViewUsers.SelectedItem as User;
            EditUserPage p = new EditUserPage(currentUser, editUser);
            NavigationService.Navigate(p);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MaterialsPage p = new MaterialsPage(currentUser);
            NavigationService.Navigate(p);
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserPage p = new AddUserPage(currentUser);
            NavigationService.Navigate(p);
        }
    }
}
