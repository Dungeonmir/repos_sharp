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
    public partial class DBtable : Page
    {
        public string SQLTable;
        public string[] dbStrings;
        DBconnection dbc;
        public DBtable(string[] _dbStrings, string _SQLTable)
        {
            InitializeComponent();
            dbStrings = _dbStrings;
            SQLTable = _SQLTable;

            loadData();
        }
        private void loadData()
        {
            makeConnection();
            MessageBox.Show(SQLTable);
            string sql = $"SELECT * FROM {SQLTable};";
            MySqlCommand cmdSQL = new MySqlCommand(sql, dbc.mySqlConnection);
            DataTable datatable = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdSQL);
            dataAdapter.Fill(datatable);
            DataContext = datatable;

            closeConnection();
        }
        private void closeConnection()
        {
            dbc.close();
        }
        private void makeConnection()
        {

            dbc = new DBconnection(dbStrings);
            string status = dbc.connect();
            if (status == "Connected")
            {
               
            }
            else
            {
                MessageBox.Show("Подключение к бд невозможно");
            }
        }

        private void btnInsertClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {

            int id = Convert.ToInt32(getCellByIndex(datagrid, 0));

           

            string query = $"DELETE FROM {SQLTable} WHERE {SQLTable}.id={id}";
            MySqlCommand command = new MySqlCommand(query, dbc.mySqlConnection);
            command.ExecuteNonQuery();
            dbc.mySqlConnection.Close();
            DBtable dBtable = new DBtable(dbStrings, SQLTable);
            NavigationService.Navigate(dBtable);

        }
        private string getCellByIndex(DataGrid dtgrd, int index)
        {
            DataRowView dataRow = (DataRowView)dtgrd.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[index].ToString();
            return cellValue;
        }
    }
}
