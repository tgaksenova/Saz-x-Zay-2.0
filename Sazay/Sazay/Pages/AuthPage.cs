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

namespace Sazay.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            Auth(TextBoxLogin.Text, PasswordBox.Password);
        }
        public bool Auth(string login, string password) 
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }
            using (var db = new Entities())
            {
                var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return false;
                }
                switch (user.Role)
                {
                    case "Преподаватель":
                        NavigationService?.Navigate(new TeacherMenu());
                        break;
                    case "Директор":
                        NavigationService?.Navigate(new DirectorMenu());
                        break;
                }
                return true;
            }
        }

        private void ButtonRegistration_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegistrationPage());
        }
    }
}
