using Microsoft.Win32;
using stroyka.db;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EditMaterial.xaml
    /// </summary>
    public partial class EditMaterial : Page
    {
        public Material material = new Material(); 
        public EditMaterial()
        {
            InitializeComponent();
            comboboxManufacturer.ItemsSource = dbStroyka.getContext().Manufacturers.ToList();
            comboboxManufacturer.SelectedIndex = 0;
            comboboxSupplier.ItemsSource = dbStroyka.getContext().Suppliers.ToList();
            comboboxSupplier.SelectedIndex = 0;
            comboboxUnit.ItemsSource = dbStroyka.getContext().Units.ToList();
            comboboxUnit.SelectedIndex = 0;
            comboboxCategory.ItemsSource = dbStroyka.getContext().MaterialCategories.ToList();
            comboboxCategory.SelectedIndex = 0;
        }

        public Material getMaterial()
        {
            material.articul = boxArticul.Text;
            material.price = Convert.ToDouble( boxPrice.Text);
            material.idSupplier = (comboboxSupplier.SelectedItem as Supplier).idSupplier;
            material.idUnit = (comboboxUnit.SelectedItem as Unit).idUnit;
            material.idManufacturer = (comboboxManufacturer.SelectedItem as Manufacturer).idManufacturer;
            material.idCategory = (comboboxCategory.SelectedItem as MaterialCategory).idCategory;
            material.discountMax = Convert.ToDouble( boxDiscountMax.Text );
            material.discount = Convert.ToDouble(boxDiscount.Text);
            material.description = boxDescription.Text;
            material.name = boxName.Text;
            material.stock = Convert.ToInt32( boxStock.Text);

            return material;
        }

        public void setMaterial(Material mt)
        {
            this.material = mt;
            boxArticul.Text = mt.articul;
            boxPrice.Text = mt.price.ToString();
            comboboxSupplier.SelectedItem = dbStroyka.getContext().Suppliers.Where(s=>s.idSupplier==mt.idSupplier).SingleOrDefault();
            comboboxUnit.SelectedItem = dbStroyka.getContext().Units.Where(u=>u.idUnit== mt.idUnit).SingleOrDefault();
            comboboxManufacturer.SelectedItem = dbStroyka.getContext().Manufacturers.Where(m => m.idManufacturer == mt.idManufacturer).SingleOrDefault();
            comboboxCategory.SelectedItem = dbStroyka.getContext().MaterialCategories.Where(c => c.idCategory == mt.idCategory).SingleOrDefault();
            boxDiscountMax.Text = mt.discountMax.ToString();
            boxDiscount.Text = mt.discount.ToString();
            boxDescription.Text = mt.description.ToString();
            boxName.Text = mt.name;
            boxStock.Text = mt.stock.ToString();
        }

        public void newMaterial()
        {
            this.material = new Material();
            boxArticul.Text = "";
            boxPrice.Text = "";
            comboboxSupplier.SelectedIndex = 0; 
            comboboxUnit.SelectedIndex = 0;
            comboboxManufacturer.SelectedIndex= 0;
            comboboxCategory.SelectedIndex = 0;
            boxDiscountMax.Text = "";
            boxDiscount.Text = "";
            boxDescription.Text = "";
            boxName.Text = "";
            boxStock.Text = "";
        }

        private void loadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();

            try
            {


                string directory;
                directory = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\'), dialog.FileName.Length - dialog.FileName.Substring(0, dialog.FileName.LastIndexOf('\\')).Length);

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\img\\" + directory))
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\img\\" + directory);
                }

                File.Copy(dialog.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\" + directory);
                material.image = dialog.SafeFileName;
            }
            catch
            {
                material.image = "plug.jpg";
            }
        }
    }
}
