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
using System.Windows.Shapes;

namespace CaffeApp
{
    /// <summary>
    /// Interaction logic for Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
            string allowchar = " ";

            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";

            allowchar += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' };

            string[] ar = allowchar.Split(a);
            string pwd = "";
            string temp = "";
            Random r = new Random();

            for (int i = 0; i < 6; i++)

            {

                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;

            }
            captchaShowLbl.Content = pwd;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if ((string)captchaShowLbl.Content != captchaBoxTbx.Text)
            {
                this.Hide();
                Captcha cap = new Captcha();
                cap.Show();
            }
            else
            {
                this.Hide();
                LoginWindow log = new LoginWindow();
                log.Show();
            }
           
        }

        private void closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
