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
    /// Логика взаимодействия для ClassesList.xaml
    /// </summary>
    public partial class StudentsList : Page
    {
        public StudentsList()
        {
            InitializeComponent();
            CheckTeacher.IsChecked = false;
            var currentStudents = Entities.GetContext().Studenti.ToList();
            ListUser.ItemsSource = currentStudents;
            UpdateStudents();
        }

        private void FIO_changed(object sender, TextChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void Spec_changed(object sender, TextChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void Photo_Checked(object sender, RoutedEventArgs e)
        {
            UpdateStudents();
        }

        private void Photo_UnChecked(object sender, RoutedEventArgs e)
        {
            UpdateStudents();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Family_Search.Text = "";
            Spec_Search.Text = "";
            CheckTeacher.IsChecked = false;
            UpdateStudents();
        }
        private void UpdateStudents()
        {
            //загружаем всех пользователей в список
            var currentStudents = Entities.GetContext().Studenti.ToList();

            //осуществляем поиск по фамилии без учета регистра букв
            currentStudents = currentStudents.Where(x => x.Familia.ToLower().Contains(Family_Search.Text.ToLower())).ToList();

            //обрабатываем фильтр по наличию фото
            if (CheckTeacher.IsChecked.Value)
                currentStudents = currentStudents.Where(x => x.Photo!=null).ToList();

            //осуществляем поиск по специальности без учета регистра букв
            currentStudents = currentStudents.Where(x => x.Specialnost.ToLower().Contains(Spec_Search.Text.ToLower())).ToList();

            ListUser.ItemsSource = currentStudents;

        }
    }
}
