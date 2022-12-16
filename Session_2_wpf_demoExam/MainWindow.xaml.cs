using Session_2_wpf_demoExam.pages;
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

namespace Session_2_wpf_demoExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }


        public bool Init()
        {
            MaterialsPage materialsPage = new MaterialsPage();
            frame.NavigationService.Navigate(materialsPage);
            return true;
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMaterialPage p = new AddMaterialPage();
            frame.NavigationService.Navigate(p);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frame.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
