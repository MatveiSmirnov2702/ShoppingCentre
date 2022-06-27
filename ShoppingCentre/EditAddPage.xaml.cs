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
using System.IO;
using Microsoft.Win32;

namespace ShoppingCentre
{
    /// <summary>
    /// Логика взаимодействия для EditAddPage.xaml
    /// </summary>
    public partial class EditAddPage : Window
    {
        private Shop _currentShop = new Shop();
        private int reg = 0;
        int maxid = pavilionsEntities.GetContext().Shop.Max(u => u.ID_Shop);
        public EditAddPage(Shop selectedShop)
        {
            InitializeComponent();
            ComboStatusEdit.ItemsSource = pavilionsEntities.GetContext().Shop.Where(x => x.Status_Shop != "Удален").Select(x => x.Status_Shop).Distinct().ToList();

            if (selectedShop != null)
            {
                _currentShop = selectedShop;
                reg = 1;
            }
            else
            {
                _currentShop.ID_Shop = maxid + 1;
            }

            DataContext = _currentShop;
        }

        private void DownLoad_Click(object sender, RoutedEventArgs e)
        {
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";
                fileDialog.InitialDirectory = @"D:\Users\Matvey\Desktop\УП 0201\Image ТЦ";

                fileDialog.Title = "Выбор фото ТЦ";

                if (fileDialog.ShowDialog() == true)
                {

                    _currentShop.image = File.ReadAllBytes(fileDialog.FileName);
                }
                MessageBox.Show(" Файл выбран ");
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentShop.Name_Shop.ToString()))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentShop.City.ToString()))
                errors.AppendLine("Укажите город");
            if (string.IsNullOrWhiteSpace(_currentShop.Count_pavillion.ToString()))
                errors.AppendLine("Укажите количество павильонов");
            if (string.IsNullOrWhiteSpace(_currentShop.Price_Shop.ToString()))
                errors.AppendLine("Укажите стоимость тц");
            if (string.IsNullOrWhiteSpace(_currentShop.Coefficient_Shopping.ToString()))
                errors.AppendLine("Укажите коэф.добав.стоим.");
            if (string.IsNullOrWhiteSpace(_currentShop.Count_floor.ToString()))
                errors.AppendLine("Укажите этажность");
            if (reg == 0) pavilionsEntities.GetContext().Shop.Add(_currentShop);

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            try
            {
                pavilionsEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена. Обновите таблицу");
                _currentShop = new Shop();
                Shopping win1 = new Shopping();
                win1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Shopping win = new Shopping();
            win.Show();
            this.Close();
        }

        private void BtnPav_ckick(object sender, RoutedEventArgs e)
        {
            var currentShop = _currentShop;
            Pavilion_Shop win1 = new Pavilion_Shop(currentShop);
            win1.Show();
            this.Close();
        }
    }
}
