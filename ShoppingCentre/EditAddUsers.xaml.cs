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
    /// Логика взаимодействия для EditAddUsers.xaml
    /// </summary>
    public partial class EditAddUsers : Window
    {
        private Sotrudniki _currentSotr = new Sotrudniki();
        private int reg = 0;
        int maxid = pavilionsEntities.GetContext().Sotrudniki.Max(u => u.ID_Sotrudnik);
        public EditAddUsers(Sotrudniki SelectedSotr)
        {
            InitializeComponent();
 
            ComboRoleEdit.ItemsSource = pavilionsEntities.GetContext().Sotrudniki.Select(x => x.Role).Distinct().ToList();
            if (SelectedSotr     != null)
            {
                _currentSotr = SelectedSotr;
                reg = 1;
            }
            else
            {
                _currentSotr.ID_Sotrudnik = maxid + 1;
            }

            DataContext = _currentSotr;
        }

        private void DownLoad_Click(object sender, RoutedEventArgs e)
        {
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";
                fileDialog.InitialDirectory = @"D:\Users\Matvey\Desktop\УП 0201\Image Сотрудники";

                fileDialog.Title = "Выбор фото ТЦ";

                if (fileDialog.ShowDialog() == true)
                {

                    _currentSotr.Photo = File.ReadAllBytes(fileDialog.FileName);
                }
                MessageBox.Show(" Файл выбран ");
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Users win1 = new Users();
            win1.Show();
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentSotr.name.ToString()))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentSotr.fathername.ToString()))
                errors.AppendLine("Укажите город");
            if (string.IsNullOrWhiteSpace(_currentSotr.Login_Employee.ToString()))
                errors.AppendLine("Укажите количество павильонов");
            if (string.IsNullOrWhiteSpace(_currentSotr.Password_Employee.ToString()))
                errors.AppendLine("Укажите стоимость тц");
            if (string.IsNullOrWhiteSpace(_currentSotr.Gender.ToString()))
                errors.AppendLine("Укажите коэф.добав.стоим.");
            if (string.IsNullOrWhiteSpace(_currentSotr.Role.ToString()))
                errors.AppendLine("Укажите этажность");
            if (string.IsNullOrWhiteSpace(_currentSotr.Telephone_Number.ToString()))
                errors.AppendLine("Укажите этажность");
            if (reg == 0) pavilionsEntities.GetContext().Sotrudniki.Add(_currentSotr);

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            try
            {
                pavilionsEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена. Обновите таблицу");
                _currentSotr = new Sotrudniki();
                Users win1 = new Users();
                win1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
