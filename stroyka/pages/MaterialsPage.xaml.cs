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
    /// Interaction logic for MaterialsPage.xaml
    /// </summary>
    public partial class MaterialsPage : Page
    {
        private User currentUser { get; set; }
        bool canEditMaterial;
        public MaterialsPage(User user)
        {
            currentUser = user;
            InitializeComponent();
            listViewMaterials.ItemsSource = dbStroyka.getContext().Materials.ToList();

            comboboxOrderByPrice.Items.Add("Без сортировки");
            comboboxOrderByPrice.Items.Add("Цена по убыванию");
            comboboxOrderByPrice.Items.Add("Цена по возрастанию");
            comboboxOrderByPrice.SelectedIndex = 0;

            Supplier temp = new Supplier();
            temp.name = "Все  производители";
            comboboxFilterBySupplier.Items.Add(temp);
            comboboxFilterBySupplier.SelectedIndex = 0;
            List<Supplier>suppliers = dbStroyka.getContext().Suppliers.ToList();
            foreach (var s in suppliers)
            {
                comboboxFilterBySupplier.Items.Add(s);
            } 
            updateSearchResult();

            setFIO();
            checkRoles();
            
        }
        private void setFIO()
        {
            if (currentUser.login == "guest")
            {
                textFIO.Text = "Гость";
            }
            else textFIO.Text = $"{currentUser.secondName} {currentUser.firstName} {currentUser.middleName}";
            
        }
        private void checkRoles()
        {
            switch (currentUser.Role.name)
            {
                case "Администратор":
                    btnAdd.Visibility = Visibility.Visible;
                    btnAccounts.Visibility = Visibility.Visible;
                    canEditMaterial = true;
                    break;
                case "Менеджер":
                    btnAdd.Visibility = Visibility.Visible;
                    btnAccounts.Visibility= Visibility.Hidden;
                    canEditMaterial = true;
                    break;
                default:
                    btnAdd.Visibility = Visibility.Hidden;
                    btnAccounts.Visibility = Visibility.Hidden;
                    canEditMaterial = false;
                    break;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoginPage page = new LoginPage();
            NavigationService.Navigate(page);
        }

        private void updateSearchResult()
        {
            int all = dbStroyka.getContext().Materials.ToList().Count;
            int now = listViewMaterials.Items.Count;
            if (now > 0)
            {
                textSearhResult.Text = $"Результат {now} из {all} записей";
            }
            else
            {
                textSearhResult.Text = "Результаты отсутсвуют";
            }
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMaterialPage page = new AddMaterialPage(currentUser);
            NavigationService.Navigate(page);
        }

        private void filterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchUpdate();
        }

        private void filterOptionsChanged(object sender, SelectionChangedEventArgs e)
        {
            searchUpdate();
        }

        private void searchUpdate()
        {
            List<Material> list = dbStroyka.getContext().Materials.ToList();
            if (boxFilterByName.Text != "")
            {
                list = list.Where(m => m.name.ToLower().Contains(boxFilterByName.Text.ToLower())).ToList();
            }
            if (comboboxOrderByPrice.SelectedIndex != 0)
            {
                switch (comboboxOrderByPrice.SelectedIndex)
                {
                    case 1:
                         list = list.OrderByDescending(m => m.price).ToList();
                        break;
                    case 2:
                        list = list.OrderBy(m => m.price).ToList();
                        break;
                }
            }
            if (comboboxFilterBySupplier.SelectedIndex > 0)
            {
                int idSupplier = (comboboxFilterBySupplier.SelectedItem as Supplier).idSupplier;
                list = list.Where(m=> m.idSupplier==idSupplier).ToList();
            }
            listViewMaterials.ItemsSource = list;
            updateSearchResult();
        }
        private void itemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (canEditMaterial)
            {
                Material material = listViewMaterials.SelectedItem as Material;
                EditMaterialPage page = new EditMaterialPage(currentUser, material);
                NavigationService.Navigate(page);
            }
            
        }

        private void imageClicked(object sender, MouseButtonEventArgs e)
        {
            var img = sender as Image;
            MessageBox.Show(img.Source.ToString());
        }

        private void boxFilterByName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            UserPage p = new UserPage(currentUser);
            NavigationService.Navigate(p);
        }
    }
}
