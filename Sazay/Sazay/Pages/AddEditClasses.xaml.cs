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
    /// Логика взаимодействия для AddEditClasses.xaml
    /// </summary>
    public partial class AddEditClasses : Page
    {
        private Disciplini _currentClass = new Disciplini();
        public AddEditClasses(Disciplini selectedClass)
        {
            InitializeComponent();
            if (selectedClass != null)
                _currentClass = selectedClass;
            DataContext = _currentClass;
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentClass.Naimenovanie))
                errors.AppendLine("Укажите наименование дисциплины!");
            if (_currentClass.chasi_obucheni9 <=0)
                errors.AppendLine("Укажите время обучения!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_currentClass.ID == 0)
                    Entities.GetContext().Disciplini.Add(_currentClass);
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
