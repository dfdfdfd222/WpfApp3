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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;


        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

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
            else if (pass != pass_2)                                                // проверка пароля2
            {
                passBox_2.ToolTip = "Пароли не одинаковы!";
                passBox_2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 | !email.Contains("@") || !email.Contains("."))                                                // проверка почты
            {
                textBoxEmail.ToolTip = "Введите правильную электронную почту!";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Все хорошо");
                User user = new User(login, email, pass);
                db.Users.Add(user);
                db.SaveChanges();


            }
        }

        public void Button_Log_Click(object sender, RoutedEventArgs e)
        {
            RegFrame.Content = new AuthWindow11111();
        }
    }
}
