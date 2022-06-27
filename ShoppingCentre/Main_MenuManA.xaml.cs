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
    /// Логика взаимодействия для Main_MenuManA.xaml
    /// </summary>
    public partial class Main_MenuManA : Window
    {
        public Main_MenuManA()
        {
            InitializeComponent();
        }

        private void Payback_Click(object sender, RoutedEventArgs e)
        {
            Payback win1 = new Payback();
            win1.Show();
            this.Close();
        }

        private void ShoppingC_Click(object sender, RoutedEventArgs e)
        {
            Shopping win1 = new Shopping();
            win1.Show();
            this.Close();
        }
    }
}
