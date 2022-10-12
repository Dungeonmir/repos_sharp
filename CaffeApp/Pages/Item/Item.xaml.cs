using CaffeApp.Pages.Insert;
using CaffeApp.Pages.Update;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CaffeApp.Pages
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : Page
    {
        public Item()
        {
            InitializeComponent();
            updateDataGrid();
            datagrid.SelectionMode = DataGridSelectionMode.Single;
            datagrid.MaxColumnWidth = 300;
            datagrid.CanUserAddRows = false;
            datagrid.CanUserDeleteRows = false;
        }
        private void updateDataGrid()
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);
            
            string query = "select * from item;";
            MySqlCommand cmdSQL = new MySqlCommand(query, db.mySqlConnection);
            DataTable datatable = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdSQL);
            dataAdapter.Fill(datatable);
            DataContext = datatable;
            datagrid.ItemsSource = datatable.DefaultView;
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

        private void btnInsertClick(object sender, RoutedEventArgs e)
        {
            InsertItem insertItem = new InsertItem();
            NavigationService.Navigate(insertItem);
        }

        private void btnUpdateClick(object sender, RoutedEventArgs e)
        {
            string[] prms = new string[6];
            
            for (int i = 0; i < datagrid.Columns.Count-1; i++)
            {
                prms [i]= getCellByIndex(datagrid, i);
            }

            UpdateItem updateItem = new UpdateItem(prms);
            NavigationService.Navigate(updateItem);
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            if (getCellByIndex(datagrid, 0)==null)
            {
                
            }
            else
            {
                int id = Convert.ToInt32(getCellByIndex(datagrid, 0));

                string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
                DBconnection? db = getConnection(dbStrings);

                string query = $"DELETE FROM `item` WHERE item.id={id}";
                MySqlCommand command = new MySqlCommand(query, db.mySqlConnection);
                command.ExecuteNonQuery();
                db.mySqlConnection.Close();
            }
            
            Item item = new Item();
            NavigationService.Navigate(item);

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
        private string getSelectedCell(DataGrid dtgrd)
        {
            DataRowView dataRow = (DataRowView)dtgrd.SelectedItem;
            int index = dtgrd.CurrentCell.Column.DisplayIndex;
            string cellValue = dataRow.Row.ItemArray[index].ToString();
            return cellValue;
        }
    }
}
