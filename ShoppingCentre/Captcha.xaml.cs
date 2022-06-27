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

namespace ShoppingCentre
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
        }
        private void Genkapchaa(object sender, RoutedEventArgs e)
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = "";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            txtkapcha.Text = pwd;

        }

        private void Checkapcha(object sender, RoutedEventArgs e)
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = "";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            
            string check = txtkek.Text;
            string kapcha = txtkapcha.Text;

            if (check != kapcha || check == "" && kapcha == "" || kapcha == "" && check == "")
            {
                MessageBox.Show("Вы робот, повторите ввод!!!");
                txtkapcha.Text = pwd;
            }
            else
            {
                MessageBox.Show("Успешно, ура!!!");
                MainWindow win1 = new MainWindow();
                win1.Show();
                this.Close();
            }
            
            

        }
       
    }
}
    

