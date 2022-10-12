using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CaffeApp.Pages.Insert
{
    /// <summary>
    /// Interaction logic for InsertItem.xaml
    /// </summary>
    public partial class InsertItem : Page
    {
        public InsertItem()
        {
            InitializeComponent();
            loadCategories();
        }
        private void loadCategories()
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);
            string query = $"SELECT * FROM `category`;";
            MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
            MySqlDataReader reader =  command.ExecuteReader();
            
            while (reader.Read())
            {
                string option = (string)reader.GetValue(1);
                cmbboxCategory.Items.Add(option);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item();
            NavigationService.Navigate(item);
        }
        private bool checkStr(string input, string regexStr)
        {
            Regex regex = new Regex(regexStr);
            return regex.IsMatch(input) ? true : false;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string id = tboxId.Text;
            string name = tboxName.Text;
            string price = tboxPrice.Text;
            TextRange textRange = new TextRange(tboxrichDescription.Document.ContentStart,
            tboxrichDescription.Document.ContentEnd);
            string description = textRange.Text;
            string amount = tboxAmount.Text;
            string category = cmbboxCategory.Text;

            MessageBox.Show("category = " + category);
            
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);
 
            string query = $"INSERT INTO `item`( `name`, `price`, `description`, `amount`, `category_idCategory`) " +
                $"SELECT '{name}', {price}, '{description}', {amount},  category.idCategory " +
                $"FROM category WHERE category.name = '{category}';";
            MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
            command.ExecuteNonQuery();
            db.mySqlConnection.Close();
            
            Item item = new Item();
            NavigationService.Navigate(item);
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
