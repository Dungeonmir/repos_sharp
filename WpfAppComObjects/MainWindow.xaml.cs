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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WpfAppComObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application(); 
            excel.Visible = true;
            excel.SheetsInNewWorkbook = 7;
            excel.Workbooks.Add(Type.Missing);
            Excel.Workbook workbook = excel.Workbooks[1];
            Excel.Worksheet sheet = workbook.Worksheets.get_Item(1);

            for (int i = 1; i < 10; i++)
            {
                sheet.Cells[i, 1].Value = i;
            }
            sheet.Cells.get_Range("A1", "A10").Font.Bold = true;

            sheet.Cells.get_Range("A1", "B10").Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            sheet.Cells.get_Range("A1", "B10").Borders.Weight = Excel.XlBorderWeight.xlThick;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Object formula, result;
            formula = tbFormula.Text;
            result = app.Evaluate(formula);
            MessageBox.Show(result.ToString()); 
            app.Quit();
        }

        private void wordOpener_Click(object sender, RoutedEventArgs e)
        {
            

            Word.Application app = new Word.Application();
            app.Visible = true;

            Object template = Type.Missing;
            Object newTemplate = false;
            Object docType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;

            Word.Document doc = app.Documents.Add(ref template, ref newTemplate, ref docType, ref visible );
            doc.Select();
            app.Selection.TypeText("Heeeeello world!!!");
        }
    }
}
