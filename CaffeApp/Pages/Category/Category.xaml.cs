using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace CaffeApp.Pages.Category
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category()
        {
            InitializeComponent();
            updateDataGrid();
        }
        private void updateDataGrid()
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);

            string query = "select * from category;";
            MySqlCommand cmdSQL = new MySqlCommand(query, db.mySqlConnection);
            DataTable datatable = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdSQL);
            dataAdapter.Fill(datatable);
            DataContext = datatable;
            db.close();
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

        private void btnUpdateClick(object sender, RoutedEventArgs e)
        {
            string[] prms = new string[2];

            for (int i = 0; i < datagrid.Columns.Count - 1; i++)
            {
                prms[i] = getCellByIndex(datagrid, i);
            }

            UpdateCategory updateCategory= new UpdateCategory(prms);
            NavigationService.Navigate(updateCategory);
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            if (getCellByIndex(datagrid, 0) == null)
            {

            }
            else
            {
                int id = Convert.ToInt32(getCellByIndex(datagrid, 0));

                string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
                DBconnection? db = getConnection(dbStrings);

                string query = $"DELETE FROM `category` WHERE category.idCategory={id}";
                MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
                command.ExecuteNonQuery();
                db.mySqlConnection.Close();
            }

            Category category = new Category();
            NavigationService.Navigate(category);
        }

        private void btnInsertClick(object sender, RoutedEventArgs e)
        {
            InsertCategory insertCategory = new InsertCategory();
            NavigationService.Navigate(insertCategory);
        }
        private string getCellByIndex(DataGrid dtgrd, int index)
        {
            DataRowView dataRow = null;
            try
            {
                dataRow = (DataRowView)dtgrd.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (dataRow != null)
            {
                string cellValue = dataRow.Row.ItemArray[index].ToString();
                return cellValue;
            }
            else return null;

        }
    }
}

