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
    /// Interaction logic for MaterialsPage.xaml
    /// </summary>
    public partial class MaterialsPage : Page
    {
        
        public MaterialsPage()
        {
            InitializeComponent();
            materials2Entities entity = new materials2Entities();
            listbox.ItemsSource = getMaterials(entity);
        }

        public static List<Material> getMaterials(materials2Entities entity )
        {
            try
            {
                List<Material> materials = entity.Material.ToList();
                return materials;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }
            
        }
       

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
