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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();

            DGridSotr.ItemsSource = pavilionsEntities.GetContext().Sotrudniki.ToList();
        }

        private void BtnClick_Add(object sender, RoutedEventArgs e)
        {
            EditAddUsers win = new EditAddUsers(null);
            win.Show();
            this.Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Main_MenuAdm win1 = new Main_MenuAdm();
            win1.Show();
            this.Close();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var UserForEdit = DGridSotr.SelectedItems.Cast<Sotrudniki>().FirstOrDefault();
            EditAddUsers win1 = new EditAddUsers(UserForEdit);
            win1.Show();
            this.Close();
        }
    }
}
