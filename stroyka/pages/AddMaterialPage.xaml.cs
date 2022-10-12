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
    /// Interaction logic for AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        User currentUser { get; set; }  
        public AddMaterialPage(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            EditMaterial page = new EditMaterial();
            frame.NavigationService.Navigate(page);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var dataPage = frame.Content as EditMaterial;
            Material material = dataPage.getMaterial();
            try
            {
                dbStroyka.getContext().Materials.Add(material);
                dbStroyka.getContext().SaveChanges();
                MessageBox.Show(material.name + " успешно добавлен.");
                dataPage.newMaterial();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MaterialsPage page = new MaterialsPage(currentUser);
            NavigationService.Navigate(page);
        }
    }
}
