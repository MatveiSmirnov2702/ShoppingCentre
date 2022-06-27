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

namespace ShoppingCentre
{
    /// <summary>
    /// Логика взаимодействия для Arenda_shop.xaml
    /// </summary>
    public partial class Arenda_shop : Window
    {
        private Pavilions pavilion;
        int Tent_ID;
        public List<Arendators> tenantsCollection { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public Arenda_shop(Pavilions selectedPavilon)
        {
            InitializeComponent();
            Start = DateTime.Today;
            Stop = DateTime.Today;
            tenantsCollection = pavilionsEntities.GetContext().Arendators.ToList();
            ComboTenants.ItemsSource = pavilionsEntities.GetContext().Arendators.Select(x => x.Name).Distinct().ToList();
            pavilion = selectedPavilon;
            DataContext = pavilion;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Start <= Stop && Start >= DateTime.Today)
            {

                Start = StartPick.SelectedDate.GetValueOrDefault();
                bool stat = Start == DateTime.Today;
                Stop = EndPick.SelectedDate.GetValueOrDefault();
                Tent_ID = pavilionsEntities.GetContext().Arendators.Where(x => x.Name == ComboTenants.Text).Select(x => x.ID_Arendators).FirstOrDefault();

                try
                {
                    pavilionsEntities.GetContext().RentPr(Tent_ID, MainWindow.index, pavilion.ID_Shop, pavilion.Number_Pavilion, Start, Stop);
                    MessageBox.Show(stat ? "Арендовано" : "Забронировано");
                }
                catch
                {
                    MessageBox.Show("Вероятно вы пытаетесь арендовать уже арендованный павильон");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Pavilion_Shop users = new Pavilion_Shop(null);
            this.Close();
            users.Show();
        }
    }
}
