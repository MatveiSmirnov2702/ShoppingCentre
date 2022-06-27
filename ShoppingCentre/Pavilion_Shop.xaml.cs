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
    /// Логика взаимодействия для Pavilion_Shop.xaml
    /// </summary>
    public partial class Pavilion_Shop : Window
    {
        int idShop = 0;
        string _name;
        string _name2;
        public Pavilion_Shop(Shop currentShop)
        {
            InitializeComponent();
            idShop = currentShop.ID_Shop;
            DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(x => x.Coefficient_Pavilion > 0.1 && x.ID_Shop == idShop).ToList();
            ComboFloor.ItemsSource = pavilionsEntities.GetContext().Pavilions.Select(x => x.Floor).Distinct().ToList();
            ComboStatus.ItemsSource = pavilionsEntities.GetContext().Pavilions.Select(x => x.Status).Distinct().ToList();
        }

        private void BtnClick_Delete(object sender, RoutedEventArgs e)
        {
            var PavilionsForRemoving = DGridPav.SelectedItems.Cast<Pavilions>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить эти(-от) ТЦ", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PavilionsForRemoving.ForEach(x => x.Status = "Удален");
                    pavilionsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены!");
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.Coefficient_Pavilion > 0.1).ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnClick_Add(object sender, RoutedEventArgs e)
        {
            EditAddPav win = new EditAddPav(null, pavilionsEntities.GetContext().Shop.Find(idShop));
            win.Show();
            this.Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Shopping win1 = new Shopping();
            win1.Show();
            this.Close();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var update = DGridPav.SelectedItems.Cast<Pavilions>().FirstOrDefault();
            EditAddPav win = new EditAddPav(update, pavilionsEntities.GetContext().Shop.Find(idShop));
            win.Show();
            this.Close();
        }

        private void ComboFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = ComboFloor.SelectedItem;
            List<Pavilions> SearchType = null;
            SearchType = pavilionsEntities.GetContext().Pavilions.Where(b => b.Floor.ToString() == c.ToString() && b.Coefficient_Pavilion > 0.1 && b.ID_Shop == idShop).ToList();
            DGridPav.ItemsSource = SearchType;
        }

        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = ComboStatus.SelectedItem;
            List<Pavilions> SearchType = null;
            SearchType = pavilionsEntities.GetContext().Pavilions.Where(b => b.Status.ToString() == c.ToString() && b.Coefficient_Pavilion > 0.1 && b.ID_Shop == idShop).ToList();
            DGridPav.ItemsSource = SearchType;
        }

        private void SquareTextFrom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SquareTextTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            _name = SquareTextFrom.Text;
            _name2 = SquareTextTo.Text;
            double num1 = 0;
            double.TryParse(_name, out num1);
            double num2 = 0;
            double.TryParse(_name2, out num2);

            DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.Square > num1 && b.Square < num2 && b.ID_Shop == idShop && b.Coefficient_Pavilion > 0.1).ToList();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            _name = SquareTextFrom.Text;
            _name2 = SquareTextTo.Text;
            double num1 = 0;
            double.TryParse(_name, out num1);
            double num2 = 0;
            double.TryParse(_name2, out num2);
            var c = ComboStatus.SelectedItem;
            var a = ComboFloor.SelectedItem;
            try
            {
                if (c == null)
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.Square > num1 && b.Square < num2 && b.ID_Shop == idShop
                   && b.Coefficient_Pavilion > 0.1 && b.Floor.ToString() == a.ToString()).ToList();
                if (a == null && num1.ToString() != null || num2.ToString() != null)
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.Square > num1 && b.Square < num2 && b.ID_Shop == idShop
                    && b.Coefficient_Pavilion > 0.1 && b.Status.ToString() == c.ToString()).ToList();
                if (num1 == 0 && num2 == 0)
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.ID_Shop == idShop && b.Floor.ToString() == a.ToString()
                    && b.Coefficient_Pavilion > 0.1 && b.Status.ToString() == c.ToString()).ToList();
                if (num1.ToString() == null && num2.ToString() == null)
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.ID_Shop == idShop && b.Floor.ToString() == a.ToString()
                    && b.Coefficient_Pavilion > 0.1 && b.Status.ToString() == c.ToString()).ToList();
                if (num1 != 0 || num2 != 0 && c != null && a != null)
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.Square > num1 && b.Square < num2 && b.ID_Shop == idShop && b.Floor.ToString() == a.ToString()
                    && b.Coefficient_Pavilion > 0.1 && b.Status.ToString() == c.ToString()).ToList();
                if (a == null && c != null && num1.ToString() != null && num2.ToString() != null)
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.Square > num1 && b.Square < num2 && b.ID_Shop == idShop
                    && b.Coefficient_Pavilion > 0.1 && b.Status.ToString() == c.ToString()).ToList();
                if (a == null && num1 != 0 && num2 != 0)
                    DGridPav.ItemsSource = pavilionsEntities.GetContext().Pavilions.Where(b => b.Square > num1 && b.Square < num2 && b.ID_Shop == idShop
                    && b.Coefficient_Pavilion > 0.1 && b.Status.ToString() == c.ToString()).ToList();

            }
            catch
            {
            }
        }

        private void BtnRent_Click(object sender, RoutedEventArgs e)
        {
            var rnt = DGridPav.SelectedItems.Cast<Pavilions>().FirstOrDefault();
            Arenda_shop users = new Arenda_shop(rnt);
            this.Close();
            users.Show();
        }
    }
    
}
