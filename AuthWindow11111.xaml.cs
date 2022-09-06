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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow11111.xaml
    /// </summary>
    public partial class AuthWindow11111 : Page
    {
        public AuthWindow11111()
        {
            InitializeComponent();
            
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            

            if (login.Length < 5)                                                    //проверка полей (логин)
            {
                textBoxLogin.ToolTip = "Длина поля долна быть больше пяти символов";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 7)                                                // проверка пароля
            {
                passBox.ToolTip = "Длина поля долна быть больше семи символов";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b=>b.Login== login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)

                    MessageBox.Show("Все хорошо");
                else
                    MessageBox.Show("Ошибка");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            //тут ошибка. Нужно переключиться на основное окно mainwindow
            
            LogFrame.Content = null;


        }

    }
}
