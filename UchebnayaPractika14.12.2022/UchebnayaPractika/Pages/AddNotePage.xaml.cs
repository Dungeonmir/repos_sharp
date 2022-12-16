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
using UchebnayaPractika.db;

namespace UchebnayaPractika.Pages
{
    /// <summary>
    /// Interaction logic for AddNotePage.xaml
    /// </summary>
    public partial class AddNotePage : Page
    {
        public AddNotePage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           bool saved =  TryToSaveNote(TextBoxTitle.Text, TextBoxText.Text, 1);
            if (saved)
            {
                MessageBox.Show($"Запись `{TextBoxTitle.Text}` сохранена");
                ClearTextBoxes();
            }
            
        }

        static bool TryToSaveNote(string Title, string Text, int UserId)
        {
            try
            {
                Note note = new Note();
                note.Title = Title;
                note.Text = Text;
                note.CreationDate = DateTime.Now;
                note.IdUser = UserId;
                uchebnayaPraktikaEntities.getContext().Note.Add(note);
                uchebnayaPraktikaEntities.getContext().SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        void ClearTextBoxes()
        {
            TextBoxTitle.Clear();
            TextBoxText.Clear();
        }
    }
}
