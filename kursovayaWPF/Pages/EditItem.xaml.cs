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
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Page
    {
        bool shouldUpdate;
        Item item;
        User user;
        public EditItem( User user, Item item)
        {
            this.shouldUpdate = true;
            this.item = item;
            this.user = user;
            InitializeComponent();

            textboxName.Text = item.name;
            textboxDescription.Text = item.description;
            textboxPrice.Text = item.price.ToString();
            textboxStock.Text = item.stock.ToString();
            textboxImage.Text = item.image.ToString();
            var categories = cafeEntities.getContext().Categories.ToList();
            comboboxCategory.ItemsSource = categories;
            comboboxCategory.SelectedValuePath = "idCategory";
            comboboxCategory.SelectedValue = item.idCategory;
        }

        public EditItem(User user)
        {
            
            shouldUpdate = false;
            this.user = user;
            InitializeComponent();

            btnDelete.Visibility = Visibility.Hidden;
            var categories = cafeEntities.getContext().Categories.ToList();
            comboboxCategory.ItemsSource = categories;
            comboboxCategory.SelectedIndex = 0;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(user);
            NavigationService.Navigate(menu);
        }
        private void updateItem( string name, string description, string image, int price, int stock)
        {
            Item editItem = (from p in cafeEntities.getContext().Items
                             where p.idItem == item.idItem
                             select p).SingleOrDefault();

            editItem.name = name;
            editItem.description = description;
            editItem.image = image;
            editItem.price = price;
            editItem.stock = stock;
            editItem.idCategory = (comboboxCategory.SelectedItem as Category).idCategory;
            cafeEntities.getContext().SaveChanges();
        }
        private void insertItem(string name, string description, string image, int price, int stock)
        {
            Item item = new Item
            {
               name = name,
               description = description,
               image = image,
               price = price,
               stock = stock,
               idCategory = (comboboxCategory.SelectedItem as Category).idCategory
        };

            // Add the new object to the Orders collection.
            cafeEntities.getContext().Items.Add(item);
            cafeEntities.getContext().SaveChanges();    

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = textboxName.Text;
            string description = textboxDescription.Text;
            string image = textboxImage.Text;
            int price = Convert.ToInt32( textboxPrice.Text);
            int stock = Convert.ToInt32(textboxStock.Text);

            if(shouldUpdate)updateItem(name, description, image, price, stock);
            else insertItem(name, description, image, price, stock);

            Menu menu = new Menu(user);
            NavigationService.Navigate(menu);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            cafeEntities.getContext().Items.Remove(item);
            cafeEntities.getContext().SaveChanges();
            Menu menu = new Menu(user);
            NavigationService.Navigate(menu);
        }
    }
}
