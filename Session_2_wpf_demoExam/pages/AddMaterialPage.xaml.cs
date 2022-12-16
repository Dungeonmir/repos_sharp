using Session_2_wpf_demoExam.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        string imageTextPath = "";
        
        public AddMaterialPage()
        {
            InitializeComponent();
           
            
            

        }
        void getParams()
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            getParams();
        }

        private void imageTextBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
