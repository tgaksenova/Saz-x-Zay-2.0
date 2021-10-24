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
    /// Логика взаимодействия для TeacherMenu.xaml
    /// </summary>
    public partial class TeacherMenu : Page
    {
        public TeacherMenu()
        {
            InitializeComponent();
        }

        private void Users_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new UserList());
        }

        private void Students_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudentsList());
        }
    }
}
