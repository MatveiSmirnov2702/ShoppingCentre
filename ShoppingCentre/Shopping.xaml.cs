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
    /// Логика взаимодействия для Shopping.xaml
    /// </summary>
    public partial class Shopping : Window
    {
        public Shopping()
        {
            InitializeComponent();
            
            DGridShopping.ItemsSource = pavilionsEntities.GetContext().Shop.Where(x => x.Status_Shop != "Удален").ToList();
            ComboCity.ItemsSource = pavilionsEntities.GetContext().Shop.Select(x => x.City).Distinct().ToList();
            ComboStatus.ItemsSource = pavilionsEntities.GetContext().Shop.Where(x => x.Status_Shop != "Удален").Select(x => x.Status_Shop).Distinct().ToList();

        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Main_menu win1 = new Main_menu();
            win1.Show();
            this.Close();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var ShopForEdit = DGridShopping.SelectedItems.Cast<Shop>().FirstOrDefault();
            EditAddPage win1 = new EditAddPage(ShopForEdit);
            win1.Show();
            this.Close();
        }

        private void ComboCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = ComboCity.SelectedItem;
            List<Shop> SearchType = null;
            SearchType = pavilionsEntities.GetContext().Shop.Where(b => b.City == c.ToString() && b.Status_Shop != "Удален").ToList();
            DGridShopping.ItemsSource = SearchType;
        }

        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = ComboStatus.SelectedItem;
            List<Shop> SearchType = null;
            SearchType = pavilionsEntities.GetContext().Shop.Where(b => b.Status_Shop == c.ToString() && b.Status_Shop != "Удален").ToList();
            DGridShopping.ItemsSource = SearchType;
        }

        private void BtnClick_Delete(object sender, RoutedEventArgs e)
        {
                var ShoppingsForRemoving = DGridShopping.SelectedItems.Cast<Shop>().ToList();
                if (MessageBox.Show("Вы уверены, что хотите удалить этот ТЦ", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ShoppingsForRemoving.ForEach(x => x.Status_Shop = "Удален");
                    pavilionsEntities.GetContext().SaveChanges();
                        MessageBox.Show("Запись удалена!");
                        DGridShopping.ItemsSource = pavilionsEntities.GetContext().Shop.ToList();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
        }
        

        private void BtnClick_Add(object sender, RoutedEventArgs e)
        {
            EditAddPage win = new EditAddPage(null);
            win.Show();
            this.Close();
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {

            DGridShopping.ItemsSource = pavilionsEntities.GetContext().Shop.OrderBy(x => x.City).ThenBy(x => x.Status_Shop).Where(x => x.Status_Shop != "Удален").ToList();
            ComboCity.ItemsSource = pavilionsEntities.GetContext().Shop.Select(x => x.City).Distinct().ToList();
            ComboStatus.ItemsSource = pavilionsEntities.GetContext().Shop.OrderBy(x => x.City).ThenBy(x => x.Status_Shop).Where(x => x.Status_Shop != "Удален").Select(x => x.Status_Shop).Distinct().ToList();
        }
    }
}
