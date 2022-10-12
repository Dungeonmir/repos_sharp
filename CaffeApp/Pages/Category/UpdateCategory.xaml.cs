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
    /// Interaction logic for UpdateCategory.xaml
    /// </summary>
    public partial class UpdateCategory : Page
    {
        int id;
        string name;
        public UpdateCategory(string[] prms)
        {
            InitializeComponent();
            id = Convert.ToInt32(prms[0]);
            name = prms[1];
            tboxCategory.Text = prms[1];
        }

        private void btnSaveClicked(object sender, RoutedEventArgs e)
        {

            name = tboxCategory.Text;


            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);
            string query = $"UPDATE `category` SET " +
                $"`name`='{name}' " +
                $"WHERE `category`.`idCategory`= {id}" +
                $";";
            MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
            command.ExecuteNonQuery();
            db.mySqlConnection.Close();

            Category category= new Category();
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

        private void btnCancelClicked(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            NavigationService.Navigate(category);
        }
    }
}
