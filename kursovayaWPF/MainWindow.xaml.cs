using kursovayaWPF.Pages;
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

namespace kursovayaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture =
            new System.Globalization.CultureInfo("ru-RU");

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("ru-RU");
            Login login = new Login();
            frame.NavigationService.Navigate(login);
        }
        
    }
}
