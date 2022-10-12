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
    /// Interaction logic for EditMaterialPage.xaml
    /// </summary>
    public partial class EditMaterialPage : Page
    {
        Material mt = new Material();
        User currentUser { get; set; }
        public EditMaterialPage(User currentUser, Material material)
        {
            this.currentUser = currentUser;
            InitializeComponent();

            mt = material;
            EditMaterial page = new EditMaterial();
            page.setMaterial(material);
            frame.NavigationService.Navigate(page);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MaterialsPage p = new MaterialsPage(currentUser);
            NavigationService.Navigate(p);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var dataPage = frame.Content as EditMaterial;
            Material material = dataPage.getMaterial();
            try
            {
                Material original = dbStroyka.getContext().Materials.Where(mt => mt.idMaterial == material.idMaterial).SingleOrDefault();
                original.articul = material.articul;
                original.idManufacturer = material.idManufacturer;
                original.price = material.price;
                original.description = material.description;
                original.discount = material.discount;
                original.discountMax = material.discountMax;
                original.idCategory = material.idCategory;
                original.idSupplier = material.idSupplier;
                original.name = material.name;
                original.stock = material.stock;
                original.idUnit = material.idUnit;


                dbStroyka.getContext().SaveChanges();
                MessageBox.Show(material.name + " успешно обновлен.");
                goToMaterials();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Material trash = dbStroyka.getContext().Materials.Where(m => m.idMaterial == mt.idMaterial).SingleOrDefault();
            dbStroyka.getContext().Materials.Remove(trash);
            dbStroyka.getContext().SaveChanges();
            MessageBox.Show(trash.name + " успешно удален.");
            goToMaterials();
        }

        private void goToMaterials()
        {
            MaterialsPage p = new MaterialsPage(currentUser);
            NavigationService.Navigate(p);
        }
    }
}
