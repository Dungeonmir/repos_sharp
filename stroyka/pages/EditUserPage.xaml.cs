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
    /// Interaction logic for EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User user;
        User editUser;
        public EditUserPage(User user, User editUser)
        {
            InitializeComponent();
            this.user = user;
            this.editUser = editUser;

            EditUser p = new EditUser();
            p.SetUser(editUser);
            frame.NavigationService.Navigate(p);
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            gotoUserPage();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var dataPage = frame.Content as EditUser;
            editUser =  dataPage.GetUser();
            try
            {
                User user = dbStroyka.getContext().Users.Where(u => u.idUser == editUser.idUser).SingleOrDefault();
                user.firstName  = editUser.firstName ;
                user.secondName = editUser.secondName;
                user.middleName = editUser.middleName;
                user.phone      = editUser.phone     ;
                user.email      = editUser.email     ;
                user.idRole     = editUser.idRole    ;
                user.birthday   = editUser.birthday  ;
                user.login      = editUser.login     ;
                user.password   = editUser.password  ;


                dbStroyka.getContext().SaveChanges();
                MessageBox.Show(user.firstName+ " успешно обновлен.");
                gotoUserPage();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            dbStroyka.getContext().Users.Remove(editUser);
            dbStroyka.getContext().SaveChanges();
            gotoUserPage();
        }
        
        private void gotoUserPage()
        {
            UserPage p = new UserPage(user);
            NavigationService.Navigate(p);
        }
    }
}

