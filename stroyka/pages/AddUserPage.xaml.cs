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
    /// Interaction logic for AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        User currentUser;
        public AddUserPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            EditUser ed = new EditUser();
            frame.NavigationService.Navigate(ed);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            UserPage page = new UserPage(currentUser);
            NavigationService.Navigate(page);
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var dataPage = frame.Content as EditUser;
            User newUser = dataPage.GetUser();
            try
            {
                dbStroyka.getContext().Users.Add(newUser);
                dbStroyka.getContext().SaveChanges();
                MessageBox.Show(newUser.firstName + " успешно добавлен.");
                UserPage p = new UserPage(currentUser);
                NavigationService.Navigate(p);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
