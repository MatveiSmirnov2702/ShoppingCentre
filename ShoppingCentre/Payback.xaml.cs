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
    /// Логика взаимодействия для Payback.xaml
    /// </summary>
    public partial class Payback : Window
    {
        public Payback()
        {
            InitializeComponent();
            DGridSotr.ItemsSource = pavilionsEntities.GetContext().PerOc().ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Main_MenuManA win1 = new Main_MenuManA();
            win1.Show();
            this.Close();
        }
    }
}
