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
using UchebnayaPractika.Pages;

namespace UchebnayaPractika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NotesPage page = new NotesPage();
            frame.NavigationService.Navigate(page);
        }

        private void btnCreateNotePage_Click(object sender, RoutedEventArgs e)
        {
            AddNotePage page = new AddNotePage();
            frame.NavigationService.Navigate(page);
        }

        private void appLogo_Click(object sender, RoutedEventArgs e)
        {
            NotesPage page = new NotesPage();
            frame.NavigationService.Navigate(page);
        }

        private void btnSettingsPage_Click(object sender, RoutedEventArgs e)
        {
            SettingsPage page = new SettingsPage();
            frame.NavigationService.Navigate(page);
        }
    }
}
