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
    /// Interaction logic for UpdateNotePage.xaml
    /// </summary>
    public partial class UpdateNotePage : Page
    {
        Note note = null;
        public UpdateNotePage(Note noteInit)
        {
            InitializeComponent();
            note = noteInit;
            TextBoxTitle.Text = note.Title;
            TextBoxText.Text = note.Text;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var noteDB = uchebnayaPraktikaEntities.getContext().Note.Where(n => n.IdNote == note.IdNote).SingleOrDefault();
                noteDB.Title = TextBoxTitle.Text;
                noteDB.Text = TextBoxText.Text;
                uchebnayaPraktikaEntities.getContext().SaveChanges();
                MessageBox.Show($"Запись `{noteDB.Title}` обновлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NotesPage p = new NotesPage();
            NavigationService.Navigate(p);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var db = uchebnayaPraktikaEntities.getContext();
            try
            {
                db.Note.Remove(db.Note.Where(n => n.IdNote == note.IdNote).SingleOrDefault());
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Запись удалена!");
            NavigationService.Navigate(new NotesPage());
        }
    }
}
