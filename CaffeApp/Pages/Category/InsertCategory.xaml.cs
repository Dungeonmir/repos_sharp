using MySql.Data.MySqlClient;
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

namespace CaffeApp.Pages.Category
{
    /// <summary>
    /// Interaction logic for InsertCategory.xaml
    /// </summary>
    public partial class InsertCategory : Page
    {
        public InsertCategory()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string id = tboxId.Text;
            string category = tboxCategory.Text;

            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);

            string query = $"INSERT INTO `category`(`name`) VALUES ('{category}')";
            MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
            command.ExecuteNonQuery();
            db.mySqlConnection.Close();

           Category categoryPage = new Category();
            NavigationService.Navigate(categoryPage);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            NavigationService.Navigate(category);
        }
        private DBconnection? getConnection(string[] dbStrings)
        {

            DBconnection db = new DBconnection(dbStrings);
            string status = db.connect();
            if (status == "Connected")
            {
                return db;
            }
            else
            {
                MessageBox.Show("Подключение к бд невозможно");
                return null;
            }
        }
    }
}
