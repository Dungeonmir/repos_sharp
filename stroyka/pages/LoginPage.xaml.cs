using stroyka.db;
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

namespace stroyka.pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public LoginPage()
        {
            InitializeComponent();
            Timer();
            panelCaptcha.Visibility = Visibility.Hidden;
        }


        private void RegistrationClicked(object sender, MouseButtonEventArgs e)
        {
            RegistrationPage page = new RegistrationPage();
            NavigationService.Navigate(page);
        }

        private void GuestLoginClicked(object sender, MouseButtonEventArgs e)
        {
            User guest = login("guest", "guest");
            gotoMaterialsPage(guest);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool captchaChecked = true;
            captchaChecked = captcha.Text == checkCaptcha.Text;
            User currentUser = login(boxLogin.Text, boxPass.Password);
            if (currentUser!=null && captchaChecked)
            {
                MessageBox.Show("Добро пожаловать " + currentUser.firstName + "!");
                gotoMaterialsPage(currentUser);
            }
            else
            {
                btnLogin.IsEnabled = false;
                timer.Start();

                string captchaV = makeCaptcha();
                captcha.Text = captchaV;
                checkCaptcha.Text = "";
                panelCaptcha.Visibility = Visibility.Visible;
                MessageBox.Show($"Неверный логин или пароль.\n Пожалуйста введите капчу...");
            }
        }
        private User login(string login, string pass)
        {
            User currentUser = dbStroyka.getContext().Users.Where(u => u.login == login && u.password == pass).SingleOrDefault();
            return currentUser;
        }
        private void gotoMaterialsPage(User user)
        {
            MaterialsPage p = new MaterialsPage(user);
            NavigationService.Navigate(p);
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
        private void Timer()
        {

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 10);
        }
        private void timerTick(object sender, EventArgs e)
        {
            btnLogin.IsEnabled = true;
            timer.Stop();
        }
    }
}
