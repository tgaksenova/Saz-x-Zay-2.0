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
    /// Логика взаимодействия для AddEditTeachers.xaml
    /// </summary>
    public partial class AddEditTeachers : Page
    {
        private Prepodavateli _currentTeacher = new Prepodavateli();
        public AddEditTeachers(Prepodavateli selectedTeacher)
        {
            InitializeComponent();
            if (selectedTeacher != null)
                _currentTeacher = selectedTeacher;
            DataContext = _currentTeacher;
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentTeacher.Tab_nomer <=0)
                errors.AppendLine("Укажите табельный номер!");
            if(string.IsNullOrWhiteSpace(_currentTeacher.Familia))
                errors.AppendLine("Введите фамилию!");
            if (string.IsNullOrWhiteSpace(_currentTeacher.Im9))
                errors.AppendLine("Введите имя!");
            if (string.IsNullOrWhiteSpace(_currentTeacher.Otchestvo))
                errors.AppendLine("Введите отчество!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_currentTeacher.ID == 0)
                    Entities.GetContext().Prepodavateli.Add(_currentTeacher);
                try
                {
                    Entities.GetContext().SaveChanges();
                    if (MessageBox.Show("Данные успешно сохранены!") == MessageBoxResult.OK)
                        NavigationService?.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }
    }
}
