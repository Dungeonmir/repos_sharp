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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        User userAccount;
        public Menu(User user)
        {
            InitializeComponent();
            userAccount = user;
            menuList.ItemsSource = cafeEntities.getContext().Items.ToList();
            var categories = cafeEntities.getContext().Categories.ToList();
            categories.Insert(0, new Category { name="Все категории"});
            filterOptions.ItemsSource = categories;
            filterOptions.SelectedIndex = 0;

            List<UserRole> roleList = cafeEntities.getContext().UserRoles.ToList();
            btnAccount.Visibility = Visibility.Hidden;
            btnAccounts.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Hidden;
            switch (user.UserRole.roleName)
            {
                case"admin":
                    btnAccount.Visibility = Visibility.Visible;
                    btnAccounts.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Visible;
                    break;
                case "user":
                    btnAccount.Visibility = Visibility.Visible;
                    break;
                case "guest":
                default:
                    break;
            }
        }
        private void updateItems()
        {
            var items = cafeEntities.getContext().Items.ToList();
            if (filterOptions.SelectedIndex!=0)
            {
                items = items.Where(p => p.idCategory == (filterOptions.SelectedItem as Category).idCategory).ToList();
            }
            string filterText = filterBox.Text;
            items = items.Where(p => p.name.ToLower().Contains(filterText)).ToList();
            menuList.ItemsSource = items;
            if (items.Count==0)
            {
                MessageBox.Show("Результаты отсутсвуют");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            NavigationService.Navigate(login);
        }

        private void filterTextChanged(object sender, TextChangedEventArgs e)
        {
            updateItems();
        }

        private void filterOptionsChanged(object sender, SelectionChangedEventArgs e)
        {
            updateItems();
            
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            Account ac = new Account(userAccount);
            NavigationService.Navigate(ac);
        }

        private void changed(object sender, SelectionChangedEventArgs e)
        {
            if (userAccount.UserRole.roleName=="admin")
            {
                Item selectedItem = (menuList.SelectedItem as Item);
                EditItem editItem = new EditItem(userAccount, selectedItem);
                NavigationService.Navigate(editItem);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditItem edit = new EditItem(userAccount);
            NavigationService.Navigate(edit);
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            Accounts acc = new Accounts(userAccount);
            NavigationService.Navigate(acc);
        }
    }
}
