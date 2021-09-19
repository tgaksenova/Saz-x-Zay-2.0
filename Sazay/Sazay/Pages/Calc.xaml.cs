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
            if (s == "+/–")
            {

                if (rightop == "")
                {
                    textBlock.Text = textBlock.Text.Substring(0, textBlock.Text.LastIndexOf(leftop));
                    double a = Double.Parse(leftop);
                    a *= -1;
                    leftop = a.ToString();
                    textBlock.Text += leftop;
                }
                if (rightop != "")
                {
                    textBlock.Text = textBlock.Text.Substring(0, textBlock.Text.LastIndexOf(rightop));
                    double a = Double.Parse(rightop);
                    a *= -1;
                    rightop = a.ToString();
                    textBlock.Text += rightop;
                }
            }
            else
            {
                textBlock.Text += s;
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
                        if (textBlock.Text.Contains("Sqrt(x)")==true || textBlock.Text.Contains("Sqr(x)") == true || textBlock.Text.Contains("1/x") == true)
                        {
                           
                        }
                        else
                        {
                            textBlock.Text =textBlock.Text.Substring(0, textBlock.Text.Length-1);
                            rightop = leftop;
                            textBlock.Text += rightop;
                            textBlock.Text += "=";
                        }
                        
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
                    if (rightop != "")
                    {
                        rightop += ",";
                    }
                    else
                    leftop += ",";
                }
                else if (s== "стереть последний символ")
                {
                    textBlock.Text = textBlock.Text.Substring(0, textBlock.Text.Length - s.Length);
                    if (rightop != "")
                    {
                        rightop = rightop.Substring(0, rightop.Length - 1);

                    }
                    else if (leftop != "")
                    {
                        leftop = leftop.Substring(0, leftop.Length - 1);

                    }
                    textBlock.Text = textBlock.Text.Substring(0, textBlock.Text.Length - 1);
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
            double num2;
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    num2 = Double.Parse(rightop);
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    num2 = Double.Parse(rightop);
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    num2 = Double.Parse(rightop);
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    num2 = Double.Parse(rightop);
                    rightop = (num1 / num2).ToString();
                    break;
                case "1/x":
                    if (rightop != "")
                    {
                        num2 = Double.Parse(rightop);
                        rightop = (1/num2).ToString();
                    }
                    else
                    {
                        rightop = (1 / num1).ToString();
                    }
                    break;
                case "Sqr(x)":
                    if (rightop != "")
                    {
                        num2 = Double.Parse(rightop);
                        rightop = Math.Pow(num2,2).ToString();
                    }
                    else
                    {
                        rightop = Math.Pow(num1, 2).ToString();
                    }
                    break;
                case "Sqrt(x)":
                    if (rightop != "")
                    {
                        num2 = Double.Parse(rightop);
                        rightop = Math.Sqrt(num2).ToString();
                    }
                    else
                    {
                        rightop = Math.Sqrt(num1).ToString();
                    }
                    break;

            }
        }
    }
}
