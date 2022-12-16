using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;
using swf = System.Windows.Forms;
namespace UchebnayaPractika.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        Theme theme;
        public SettingsPage()
        {
            InitializeComponent();
           theme = uchebnayaPraktikaEntities.getContext().Theme.Where(i => i.IdUser == 1).SingleOrDefault();
            if(theme == null)
            {
                theme = new Theme();
                theme.IdUser = 1;
                uchebnayaPraktikaEntities.getContext().Theme.Add(theme);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            uchebnayaPraktikaEntities.getContext().SaveChanges();
            MessageBox.Show("Настройки сохранены");
            NavigationService.Navigate(new NotesPage());
        }

        private void BtnFontDialog_Click(object sender, RoutedEventArgs e)
        {
            swf.FontDialog f = new swf.FontDialog();
            if(f.ShowDialog() == swf.DialogResult.OK)
            {
                MessageBox.Show("Новый шрифт: "+f.Font.Name.ToString());
                theme.FontFamily = f.Font.Name;
                labelTextFont.FontFamily = new  FontFamily(theme.FontFamily);
            }
        }

        private void BtnBackgroundChange_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new swf.OpenFileDialog();
            fileDialog.Filter = "Jpeg Image|*.jpg";
            fileDialog.Title = "Save Image";

            
            if (fileDialog.ShowDialog() == swf.DialogResult.OK)
            {
                var uri = new Uri(fileDialog.FileName);
                var bitmap = new BitmapImage(uri);
                var encoder = new JpegBitmapEncoder(); 
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.QualityLevel = 100;
                

                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/images/");
                
                if(!File.Exists(Directory.GetCurrentDirectory() + "/images/" + fileDialog.SafeFileName))
                {
                    using (var stream = new FileStream((Directory.GetCurrentDirectory() + "/images/" + fileDialog.SafeFileName), FileMode.Create))
                    {
                        encoder.Save(stream);
                        theme.Image = fileDialog.SafeFileName;
                    }
                }
                else
                {
                    theme.Image = fileDialog.SafeFileName;
                }
                
            }
        }

        private void BtnColorPicker_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new swf.ColorDialog();
            if(colorDialog.ShowDialog()== swf.DialogResult.OK)
            {
                theme.FontColor = colorDialog.Color.ToArgb();
                string rgb;
                ColorToRGB(colorDialog.Color, out rgb);
                MessageBox.Show("Новый цвет: "+ rgb);

                byte[] bytes = BitConverter.GetBytes((int)theme.FontColor);
                labelTextColor.Foreground = new SolidColorBrush(Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]));
            }
        }

        public static bool ColorToRGB(System.Drawing.Color clr, out string RGBstring)
        {
            try
            {
                RGBstring = $"{clr.R} {clr.G} {clr.B}";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RGBstring = "";
                return false;
            }
        }
    }
}
