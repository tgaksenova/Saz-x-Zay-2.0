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

        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEditClasses());
        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
