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
    /// Interaction logic for DBtable.xaml
    /// </summary>
    public partial class DBtable : Page
    {
        public DBtable()
        {
            InitializeComponent();

            updateDataGrid();
            

        }
        private void updateDataGrid()
        {
            string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
            DBconnection? db = getConnection(dbStrings);

            string sql = (string)App.Current.Properties["SQLstring"];
            MySqlCommand cmdSQL = new MySqlCommand(sql, db.mySqlConnection);
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

        private void datagrid_cell_edit_ending(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedTextbox = e.EditingElement as TextBox;
            
            if (editedTextbox != null)
            {
                var column = e.Column.Header.ToString();
                var row = ((TextBlock)datagrid.SelectedCells[0].Column.GetCellContent(datagrid.SelectedItem)).Text;
                var cellContent = editedTextbox.Text;
                string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
                DBconnection? db = getConnection(dbStrings);


                MessageBox.Show(column + "  "+ cellContent + " row = " + row);
                string sqlCommand = "";
                updateDataGrid();
            }
        
        }

        private void datagrid_key_down(object sender, KeyEventArgs e)
        {
            if (e.Key ==Key.Delete)
            {
                string[] dbStrings = (string[])App.Current.Properties["DBconnString"];
                string table = (string)App.Current.Properties["Table"];
                DBconnection? db = getConnection(dbStrings);

                var row = (datagrid.SelectedCells[0].Column.GetCellContent(datagrid.SelectedItem) as TextBlock).Text;
                string sql = $"DELETE FROM `{table}` WHERE id={row}";
                MySqlCommand command = new MySqlCommand(sql, db.mySqlConnection);
                command.ExecuteNonQuery();
                db.mySqlConnection.Close();
                updateDataGrid();
            }
        }
    }
}
