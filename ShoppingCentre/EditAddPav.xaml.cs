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
    /// Логика взаимодействия для EditAddPav.xaml
    /// </summary>
    public partial class EditAddPav : Window
    {
        private Pavilions _currentPavilions = new Pavilions();
        private int reg = 0;
        private Shop curS;
        public EditAddPav(Pavilions selectedPavilions, Shop shop)
        {
            InitializeComponent();
            curS = shop;
            ComboStatusEdit.ItemsSource = pavilionsEntities.GetContext().Pavilions.Select(x => x.Status).Distinct().ToList();
            if (selectedPavilions != null)
            {
                _currentPavilions = selectedPavilions;
                reg = 1;
            }

            DataContext = _currentPavilions;

        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPavilions.Floor.ToString()))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentPavilions.Number_Pavilion.ToString()))
                errors.AppendLine("Укажите город");
            if (string.IsNullOrWhiteSpace(_currentPavilions.Status.ToString()))
                errors.AppendLine("Укажите количество павильонов");
            if (string.IsNullOrWhiteSpace(_currentPavilions.Square.ToString()))
                errors.AppendLine("Укажите стоимость тц");
            if (string.IsNullOrWhiteSpace(_currentPavilions.Coefficient_Pavilion.ToString()))
                errors.AppendLine("Укажите коэф.добав.стоим.");
            if (_currentPavilions.Coefficient_Pavilion < 0.1)
                errors.AppendLine("Коэф.добав.стоим. должен быть больше или равен 0.1");
            if (string.IsNullOrWhiteSpace(_currentPavilions.PriceSquare.ToString()))
                errors.AppendLine("Укажите этажность");
            if (reg == 0) pavilionsEntities.GetContext().Pavilions.Add(_currentPavilions);

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            try
            {
                pavilionsEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена. Обновите таблицу");
                _currentPavilions = new Pavilions();
                Shopping win1 = new Shopping();
                win1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            Pavilion_Shop win1 = new Pavilion_Shop(curS);
            win1.Show();
            this.Close();
        }
    }
       
}
