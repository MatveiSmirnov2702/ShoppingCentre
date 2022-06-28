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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int index = 1;
        public static string Surname, ClientName, Patronymic;
        string _login, _password;
        public MainWindow()
        {
            InitializeComponent();
        }
        int maxattemtps = 3;
        private void Login_Clicked(object sender, RoutedEventArgs e)
        {
            Sotrudniki Sotrudniki = null;
            StringBuilder errors = new StringBuilder();
            _login = LoginText.Text;
            _password = PasswordText.Password;
            Sotrudniki = pavilionsEntities.GetContext().Sotrudniki.Where(b => b.Password_Employee == _password && b.Login_Employee == _login).FirstOrDefault();
            if (Sotrudniki == null)
            {
                MessageBox.Show("Не найдено");
                if (maxattemtps <= 1)
                {
                    Captcha win2 = new Captcha();
                    win2.Show();
                    this.Close();
                }
                else maxattemtps--;
            }
            else

            {
                if (Sotrudniki.Role == "Администратор")
                {
                    Main_MenuAdm users = new Main_MenuAdm();
                    this.Close();
                    users.Show();
                }
                else
                if (Sotrudniki.Role == "Менеджер А")
                {
                    Main_MenuManA users = new Main_MenuManA();
                    this.Close();
                    users.Show();
                }
                else
                {
                    index = Sotrudniki.ID_Sotrudnik;
                    Surname = Sotrudniki.surname;
                    ClientName = Sotrudniki.name;
                    Patronymic = Sotrudniki.fathername;
                    Main_menu win1 = new Main_menu();
                    win1.Show();
                    this.Close();
                }
            }
        }
    }
}
