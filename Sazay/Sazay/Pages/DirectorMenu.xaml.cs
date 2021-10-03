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
    /// Логика взаимодействия для CustomerMenu.xaml
    /// </summary>
    public partial class DirectorMenu : Page
    {
        public DirectorMenu()
        {
            InitializeComponent();
        }

        private void Groups_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Groups());
        }

        private void Classes_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Classes());
        }

        private void Teachers_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Teachers());
        }
    }
}
