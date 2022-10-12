using CaffeApp.Pages;
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

namespace CaffeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] dbStrings;
        public MainWindow(string[] _dbStrings)
        {
            dbStrings = _dbStrings;
            InitializeComponent();
        }

        private void mainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void menu_click(object sender, RoutedEventArgs e)
        {
            string str = "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where table_schema = 'cafedb' and table_name = 'item'";

            DBtable dbTable = new DBtable(dbStrings, "category");
            pageRoot.Content = dbTable;
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
