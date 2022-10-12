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

namespace kursovayaWPF.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private void Timer()
        {
            
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 10);
        }
        public Login()
        {
            InitializeComponent();
            Timer();
        }

        private void btnRegistrationClicked(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration(); 
            NavigationService.Navigate(registration);
        }

        private void btnLoginGuestClicked(object sender, MouseButtonEventArgs e)
        {
            HashFunction hashFunction = new HashFunction();
            string userHash = hashFunction.makeHash("");
            using (cafeEntities cafeEntities = new cafeEntities())
            {
                var result = (from ent in cafeEntities.Users
                              where ent.login == "guest" && ent.password == userHash
                              select ent).FirstOrDefault();
                if (result != null)
                {
                    Menu menu = new Menu(result);
                    NavigationService.Navigate(menu);
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }

            }
           
        }

        private void timerTick(object sender, EventArgs e)
        {
            btnLogin.IsEnabled = true;
            timer.Stop();
        }
        private void btnLoginClicked(object sender, RoutedEventArgs e)
        {
            HashFunction hashFunction = new HashFunction();
            string userHash = hashFunction.makeHash(passwordBox.Password);
            bool captchaChecked = true;
            using (cafeEntities cafeEntities = new cafeEntities())
            {
                captchaChecked = captcha.Content.ToString() == checkCaptcha.Text;
                var result = (from ent in cafeEntities.Users
                             where ent.login == textboxLogin.Text && ent.password == userHash
                             select ent).FirstOrDefault();
                if (result!=null && captchaChecked)
                {
                    var name = result.name;
                    var surname = result.surname;
                    Menu menu = new Menu(result);
                    NavigationService.Navigate(menu);
                }
                else
                {
                    btnLogin.IsEnabled=false;
                    timer.Start();
                    
                    string captchaV = makeCaptcha();
                    captcha.Content = captchaV;
                    checkCaptcha.Text = "";
                    captcha.Visibility = Visibility.Visible;
                    checkCaptcha.Visibility = Visibility.Visible;
                    MessageBox.Show($"Неверный логин или пароль.\n Пожалуйста введите капчу...");
                }
                
            }
            

        }

        private string makeCaptcha()
        {
            Random rand = new Random();
            int num = rand.Next(6, 8);
            string captchaValue = "";
            int totl = 0;
            do
            {
                int chr = rand.Next(48, 123);
                if ((chr >= 48 && chr <= 58) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captchaValue = captchaValue + (char)chr;
                    totl++;
                    if (totl == num)
                        break;
                    {

                    }
                }
            } while (true);
            return captchaValue;
        }
    }
}
