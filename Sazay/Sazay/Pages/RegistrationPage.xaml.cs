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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Login.Text)|| String.IsNullOrEmpty(Password.Text) || String.IsNullOrEmpty(ConfirmPassword.Text) || String.IsNullOrEmpty(FIO.Text)) // проверка заполнения данными всех полей
            {
                MessageBox.Show("Заполните данные!");
            }
            else // проверка пароля
            {
                if (Password.Text.Length < 6)
                {
                    MessageBox.Show("Пароль должен содержать 6 или более символов");
                }
                else
                {
                    bool en = true; // английская раскладка
                    bool number = false; // цифра

                    for (int i = 0; i < Password.Text.Length; i++) // перебираем символы
                    {
                        if (Password.Text[i] >= 'А' && Password.Text[i] <= 'я') en = false; // если русская раскладка
                        if (Password.Text[i] >= '0' && Password.Text[i] <= '9') number = true; // если цифры
                    
                    }
                    if (en == false)
                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                    else if (number == false)
                    MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                    if (en == true && number == true) // проверяем соответствие
                    {
                        if (Password.Text == ConfirmPassword.Text)
                        {
                            MessageBox.Show($"Пользователь {FIO.Text} успешно зарегистрирован под ролью: "+Role.Text);
                            Entities db = new Entities();
                            User userObject = new User
                            {
                                FIO = FIO.Text,
                                Login = Login.Text,
                                Password = Password.Text,
                                Role = Role.Text
                            };
                            db.User.Add(userObject);
                            db.SaveChanges();
                            NavigationService?.Navigate(new AuthPage());

                        }
                        else MessageBox.Show("Пароли не совпадают!");
                    }
                }
                    
            }
        }
    }
}
