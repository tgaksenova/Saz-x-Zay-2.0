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
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
            CmbSorted.SelectedIndex = 0;
            CheckTeacher.IsChecked = false;
            var currentUsers = Entities.GetContext().User.ToList();
            ListUser.ItemsSource = currentUsers;
            UpdateUsers();
        }

        private void FIO_changed(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void Sort_changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void Teacher_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            FIO_Search.Text = "";
            CmbSorted.SelectedIndex = 0;
            CheckTeacher.IsChecked = false;
            UpdateUsers();
        }

        private void Teacher_UnChecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }
        private void UpdateUsers()
        {
            //загружаем всех пользователей в список
            var currentUsers = Entities.GetContext().User.ToList();

            //осуществляем поиск по Ф.И.О. без учета регистра букв
            currentUsers = currentUsers.Where(x => x.FIO.ToLower().Contains(FIO_Search.Text.ToLower())).ToList();

            //обрабатываем фильтр по одной роли пользователей
            if (CheckTeacher.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Role.Contains("Преподаватель")).ToList();

            //осуществляем сортировку в зависимости от выбора пользователя
            if (CmbSorted.SelectedIndex == 0)
                ListUser.ItemsSource = currentUsers.OrderBy(x => x.FIO).ToList();
            else ListUser.ItemsSource = currentUsers.OrderByDescending(x => x.FIO).ToList();

        }
    }
}
