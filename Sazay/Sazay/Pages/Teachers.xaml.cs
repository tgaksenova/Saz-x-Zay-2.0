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
    /// Логика взаимодействия для Teachers.xaml
    /// </summary>
    public partial class Teachers : Page
    {
        public Teachers()
        {
            InitializeComponent();
            DataGridTeachers.ItemsSource = Entities.GetContext().Prepodavateli.ToList();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditTeachers((sender as Button).DataContext as Prepodavateli));
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEditTeachers(null));
        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            var TeachersForRemoving = DataGridTeachers.SelectedItems.Cast<Prepodavateli>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {TeachersForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    Entities.GetContext().Prepodavateli.RemoveRange(TeachersForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridTeachers.ItemsSource = Entities.GetContext().Prepodavateli.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


        }

        private void Teachers_VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridTeachers.ItemsSource = Entities.GetContext().Prepodavateli.ToList();
            }
        }
    }
}
