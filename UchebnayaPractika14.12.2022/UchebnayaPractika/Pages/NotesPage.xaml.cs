using System;
using System.Collections.Generic;
using System.Drawing;
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
using Xceed.Wpf.AvalonDock.Converters;
using Xceed.Wpf.AvalonDock.Themes;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;

namespace UchebnayaPractika.Pages
{
    /// <summary>
    /// Interaction logic for NotesPage.xaml
    /// </summary>
    public partial class NotesPage : Page
    {
        public NotesPage()
        {
            InitializeComponent();

            uchebnayaPraktikaEntities entity = new uchebnayaPraktikaEntities();
            List<Note> list;
            getNotes(entity,out list);
            list.Sort((a, b) => a.CreationDate.CompareTo(b.CreationDate)) ;
            listView.ItemsSource = list;
            
            var theme = entity.Theme.Where(i => i.IdUser == 1).SingleOrDefault();
            if (theme != null)
            {
               
                    listView.FontFamily = new FontFamily(theme.FontFamily);

                SolidColorBrush brush;
                if(MakeSolidBrushFromArgbValue((int)theme.FontColor, out brush))
                {
                    listView.Foreground = brush;
                }

                if (theme.Image != null)
                {
                    imageContainer.Source = new BitmapImage(new Uri(theme.BackgroundFullImagePath));
                }
               
            }
            
            
        }

        public static bool MakeSolidBrushFromArgbValue(int ARGBcolor, out SolidColorBrush brush)
        {
            try
            {
                byte[] bytes = BitConverter.GetBytes(ARGBcolor);
                brush = new SolidColorBrush(Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                brush = null;
                return false;
            }
           
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateNotePage p = new UpdateNotePage((listView.SelectedItem as Note));
            NavigationService.Navigate(p);
        }

        public static bool getNotes(uchebnayaPraktikaEntities entity, out List<Note> notes)
        {
            try
            {
                notes = entity.Note.ToList();
                return true;
            }
            catch (Exception ex)
            {
                notes = new List<Note>();
                MessageBox.Show(ex.Message);
                return false;
            }
            
            
        }
    }
}
