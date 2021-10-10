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
    /// Логика взаимодействия для Classes.xaml
    /// </summary>
    public partial class Classes : Page
    {
        public Classes()
        {
            InitializeComponent();
            DataGridClasses.ItemsSource = Entities.GetContext().Disciplini.ToList();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditClasses((sender as Button).DataContext as Disciplini));
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEditClasses(null));
        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            var ClassesForRemoving = DataGridClasses.SelectedItems.Cast<Disciplini>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ClassesForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    Entities.GetContext().Disciplini.RemoveRange(ClassesForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridClasses.ItemsSource = Entities.GetContext().Disciplini.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void Classes_VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridClasses.ItemsSource = Entities.GetContext().Disciplini.ToList();
            }
        }
    }
}
