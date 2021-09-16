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
    /// Логика взаимодействия для Calc.xaml
    /// </summary>
    public partial class Calc : Page
    {
        string leftop = ""; // Левый операнд
        string operation = ""; // Знак операции
        string rightop = ""; // Правый операнд

        public Calc()
        {
            InitializeComponent();
            // Добавляем обработчик для всех кнопок на гриде
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст кнопки
            string s = (string)((Button)e.OriginalSource).Content;
            // Добавляем его в текстовое поле
            if (s!= "+/-")
            {
                textBlock.Text += s;
            }
            else
            {

            }
            Double num;
            // Пытаемся преобразовать его в число
            bool result = Double.TryParse(s, out num);
            // Если текст - это число
            if (result == true)
            {
                // Если операция не задана
                if (operation == "")
                {
                    // Добавляем к левому операнду
                    leftop += s;
                }
                else
                {
                    // Иначе к правому операнду
                    rightop += s;
                }
            }
            // Если было введено не число
            else
            {
                // Если равно, то выводим результат операции
                if (s == "=")
                {
                    if (rightop == "")
                    {
                        textBlock.Text =textBlock.Text.Substring(0, textBlock.Text.Length-1);
                        rightop = leftop;
                        textBlock.Text += rightop;
                        textBlock.Text += "=";
                        
                    }
                    
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                    
                   
                }
                // Очищаем поле и переменные
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else if (s == ",")
                {
                    leftop += ",";
                }
                // Получаем операцию
                else
                {
                    
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }
        // Обновляем значение правого операнда
        private void Update_RightOp()
        {
            double num1 = Double.Parse(leftop);
            double num2 = Double.Parse(rightop);
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
                case "1/x":
                    rightop = (num1 / num2).ToString();
                    break;
                case "Sqr(x)":
                    rightop = (num1 / num2).ToString();
                    break;
                case "Sqrt(x)":
                    rightop = (num1 / num2).ToString();
                    break;
                case "+/–":
                    rightop = (num1 / num2).ToString();
                    break;

            }
        }
    }
}
