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

namespace Session2.Pages
{
    /// <summary>
    /// Interaction logic for MaterialViewPage.xaml
    /// </summary>
    public partial class MaterialViewPage : Page
    {
        public MaterialViewPage()
        {
            InitializeComponent();

            listView.ItemsSource = session2Entities.getContext().Material.ToList();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new MaterialEditPage());
        }
    }
}
