using CaffeApp.Pages;
using CaffeApp.Pages.Category;
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

namespace CaffeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void menu_click(object sender, RoutedEventArgs e)
        {
           MenuPage menu = new MenuPage();
           pageRoot.Content = menu;
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item();
            pageRoot.Content = item;
        }

        private void btnCategoryClick(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            pageRoot.Content = category;
        }
    }
}
