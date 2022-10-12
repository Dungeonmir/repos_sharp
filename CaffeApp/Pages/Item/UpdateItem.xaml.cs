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

namespace CaffeApp.Pages.Update
{
    /// <summary>
    /// Interaction logic for UpdateItem.xaml
    /// </summary>
    public partial class UpdateItem : Page
    {
        private int id;
        private string name;
        private int price;
        private string description;
        private int amount;
        private int categoryId;
        public UpdateItem(string[] prms)
        {

            InitializeComponent();
            id = Convert.ToInt32(prms[0]);
            name = prms[1];
            price = Convert.ToInt32(prms[2]);
            description = prms[3];
            amount = Convert.ToInt32(prms[4]);
            categoryId = Convert.ToInt32(prms[5]);
            
            loadCategories();

            tboxId.Text = id.ToString();
            tboxName.Text = name.ToString();
            tboxPrice.Text = price.ToString();
            tboxrichDescription.AppendText(description);
            tboxAmount.Text = amount.ToString();
            cmbboxCategory.SelectedItem = getCategoryName(categoryId);
        }
        private void loadCategories()
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);
            string query = $"SELECT * FROM `category`;";
            MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string option = (string)reader.GetValue(1);
                cmbboxCategory.Items.Add(option);
            }
            db.close();

        }
        private string getCategoryName(int categoryId)
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);

            string query = $"SELECT category.name FROM category WHERE category.idCategory={categoryId}";
            MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
            string str =  (string)command.ExecuteScalar();
            db.mySqlConnection.Close();
            return str;
        }
        private int getCategoryId(string categoryName)
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);

            string query = $"SELECT category.id FROM category WHERE category.name={categoryName}";
            MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
            int ctgrId = (int)command.ExecuteScalar();
            db.mySqlConnection.Close();
            return ctgrId;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item();
            NavigationService.Navigate(item);
        }

        private void updateParams()
        {
            id = Convert.ToInt32(tboxId.Text);
            name = tboxName.Text;
            price = Convert.ToInt32(tboxPrice.Text);
            description = new TextRange(tboxrichDescription.Document.ContentStart, tboxrichDescription.Document.ContentEnd).Text;
            amount =Convert.ToInt32( tboxAmount.Text);
            cmbboxCategory.SelectedItem = getCategoryName(categoryId);
        }
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            //parameters validation

            //get parameters
            updateParams();


            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);
            string query = $"UPDATE `item` SET " +
                $"`name`='{name}', " +
                $"`price`='{price}', " +
                $"`description`='{description}', " +
                $"`amount`='{amount}', " +
                $"`category_idCategory`='{categoryId}' " +
                $"WHERE `item`.`id`= {id}" +
                $";";
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
