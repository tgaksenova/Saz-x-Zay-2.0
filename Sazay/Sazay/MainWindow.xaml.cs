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
using System.IO; //для осуществления чтения/записи в файл
using System.Diagnostics; //для запуска Блокнота
using Microsoft.Win32; //для работы диалоговых окон открытия/сохранения файла


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
        private void ExportClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.ShowDialog();
            if(saveFile.FileName != "")
            {
                StreamWriter sw = new StreamWriter(saveFile.FileName);
                using (var db = new Entities())
                {
                    
                    String IDline = String.Join(":", db.User.Select(x => x.ID));
                    String Login = String.Join(":", db.User.Select(x => x.Login));
                    String Password = String.Join(":", db.User.Select(x => x.Password));
                    String Role = String.Join(":", db.User.Select(x => x.Role));
                    String FIO = String.Join(":", db.User.Select(x => x.FIO));
                    sw.WriteLine(IDline);
                    sw.WriteLine(FIO);
                    sw.WriteLine(Login);
                    sw.WriteLine(Password);
                    sw.WriteLine(Role);
                    sw.Close();

                }
                Process.Start("notepad.exe", saveFile.FileName);
            }
            else
            {
                MessageBox.Show("Укажите имя файла!");
            }
        }
        private void ImportClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла
            {
                StreamReader sr = new StreamReader(ofd.FileName); // открываем файл
                while (!sr.EndOfStream) // перебираем строки, пока они не закончены
                {
                    string[] lines = new string[5];// массив данных 
                    for (int i = 0; i < 5; i++) // читаем 5 строк 
                    {
                        string line = sr.ReadLine(); // читаем строку  
                        string[] data = line.Split(':');
                        line = ""; // обнуляем переменную    
                        if (data.Length >= 2) // проверяем на целостность данных  
                        {
                            for (int j = 0; j < data.Length; j++) // складываем данные      
                            {
                                line += data[j]+"; "; // собираем строку  
                            }
                        }
                        lines[i] = line; // записываем значения в массив 
                    }
                    // выводим данные 
                    MessageBox.Show("Данные в файле: \nID: " + lines[0] + "\nФИО: " + lines[1] + "\nЛогин: " + lines[2] + "\nПароль: " + lines[3] + "\nРоль: " + lines[4]);
                }

            }
            else MessageBox.Show("Файл для импорта не выбран!");

        }

    }
}

