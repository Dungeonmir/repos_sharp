using Session_2_wpf_demoExam.db;
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

namespace Session_2_wpf_demoExam.pages
{
    /// <summary>
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        string imageTextPath = "";
        public AddProductPage()
        {
            InitializeComponent();

            var list = materials2Entities.Ctx().ProductType.ToList();
            var fakeProductType = new ProductType();
            fakeProductType.ID = -1;
            fakeProductType.Title = "Выберите тип продукта";
            list.Insert(0, fakeProductType);
            productTypeComboBox.ItemsSource = list;
            productTypeComboBox.SelectedIndex = 0;
        }

        public void getParams()
        {
                Product p = new Product();
                p.ProductTypeID = (productTypeComboBox.SelectedItem as ProductType).ID;
                p.Image = imageTextPath;
                p.MinCostForAgent = Convert.ToDecimal(minCostForAgentTextBox.Text);
                p.ProductionWorkshopNumber = Convert.ToInt32(productionPersonCountTextBox.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void imageTextBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
