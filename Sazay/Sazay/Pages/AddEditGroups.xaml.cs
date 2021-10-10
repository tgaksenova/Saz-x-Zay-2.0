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
    /// Логика взаимодействия для AddEditGroups.xaml
    /// </summary>
    public partial class AddEditGroups : Page
    {
        private Sazay.Groups _currentGroup = new Sazay.Groups();
        public AddEditGroups(Sazay.Groups selectedGroup)
        {
            InitializeComponent();
            if (selectedGroup != null)
                _currentGroup = selectedGroup;
            DataContext = _currentGroup;
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentGroup.N_group <= 0)
                errors.AppendLine("Укажите номер группы!");
            if (_currentGroup.Kolvo_Students ==null)
                errors.AppendLine("Укажите количество студентов!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_currentGroup.ID == 0)
                    Entities.GetContext().Groups.Add(_currentGroup);
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
