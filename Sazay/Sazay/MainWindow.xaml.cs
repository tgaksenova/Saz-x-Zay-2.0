using Sazay.Pages;
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

namespace Sazay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"LESSON - {page.Title}";
            if (page is AuthPage)
            {
                ButtonBack.Visibility = Visibility.Hidden; ButtonCalculator.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Visible; ButtonCalculator.Visibility = Visibility.Hidden;
            }
            if (page is Calc)
            {
                ButtonCalculator.Visibility = Visibility.Hidden;
                var uri = new Uri("DictionaryCalc.xaml", UriKind.Relative);
                // загружаем словарь ресурсов
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.MergedDictionaries.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            else
            {
              
                var uri = new Uri("Dictionary.xaml", UriKind.Relative);
                // загружаем словарь ресурсов
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.MergedDictionaries.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
        }

        private void ButtonCalculator_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService?.Navigate(new Calc()); 
        }
        
    }
}

