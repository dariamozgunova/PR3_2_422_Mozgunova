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

namespace PR3_2_422_Mozgunova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FigureChoice(object sender, RoutedEventArgs e)
        {
            InputSide1.Text = string.Empty;
            InputSide2.Text = string.Empty;
            InputSide3.Text = string.Empty;
            InputRadius.Text = string.Empty;

            ResultLabel.Text = "Площадь = ";

            Side1.Visibility = InputSide1.Visibility = Visibility.Collapsed;
            Side2.Visibility = InputSide2.Visibility = Visibility.Collapsed;
            Side3.Visibility = InputSide3.Visibility = Visibility.Collapsed;
            Radius.Visibility = InputRadius.Visibility = Visibility.Collapsed;

            if (RectangleRadio.IsChecked == true)
            {
                Side1.Visibility = InputSide1.Visibility = Visibility.Visible;
                Side2.Visibility = InputSide2.Visibility = Visibility.Visible;
            }
            else if (CircleRadio.IsChecked == true)
            {
                Radius.Visibility = InputRadius.Visibility = Visibility.Visible;
            }
            else if (TriangleRadio.IsChecked == true)
            {
                Side1.Visibility = InputSide1.Visibility = Visibility.Visible;
                Side2.Visibility = InputSide2.Visibility = Visibility.Visible;
                Side3.Visibility = InputSide3.Visibility = Visibility.Visible;
            }
        }

        private void CalculateArea(object sender, RoutedEventArgs e)
        {
            if (RectangleRadio.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(InputSide1.Text) || string.IsNullOrWhiteSpace(InputSide2.Text))
                {
                    MessageBox.Show("Заполните все поля ввода!");
                    return;
                }

                if (!double.TryParse(InputSide1.Text, out double a) || !double.TryParse(InputSide2.Text, out double b))
                {
                    MessageBox.Show("Неверное значение. Повторите ввод");
                    return;
                }

                if (a <= 0 || b <= 0)
                {
                    MessageBox.Show("Стороны прямоугольника не могут быть отрицательными");
                    return;
                }

                if (a == b)
                {
                    MessageBox.Show("Стороны прямоугольника не могут быть равны");
                    return;
                }
                ResultLabel.Text = $"Площадь = {a * b}";
            }
            else if (CircleRadio.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(InputRadius.Text))
                {
                    MessageBox.Show("Заполните все поля ввода!");
                    return;
                }

                if (!double.TryParse(InputRadius.Text, out double r))
                {
                    MessageBox.Show("Неверное значение. Повторите ввод");
                    return;
                }

                if (r < 0)
                {
                    MessageBox.Show("Радиус не может быть отрицательным");
                    return;
                }
                ResultLabel.Text = $"Площадь = {Math.PI * r * r:F2}";
            }
            else if (TriangleRadio.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(InputSide1.Text) || string.IsNullOrWhiteSpace(InputSide2.Text) || string.IsNullOrWhiteSpace(InputSide3.Text))
                {
                    MessageBox.Show("Заполните все поля ввода!");
                    return;
                }

                if (!double.TryParse(InputSide1.Text, out double a) || !double.TryParse(InputSide2.Text, out double b) || !double.TryParse(InputSide3.Text, out double c))
                {
                    MessageBox.Show("Неверное значение. Повторите ввод");
                    return;
                }

                if (a <= 0 || b <= 0 || c <= 0)
                {
                    MessageBox.Show("Стороны треугольника не могут быть отрицательными");
                    return;
                }

                if (a + b <= c || a + c <= b || b + c <= a)
                {
                    MessageBox.Show("Треугольник с такими сторонами невозможен");
                    return;
                }
                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                ResultLabel.Text = $"Площадь = {area:F2}";
            }
            else
            {
                MessageBox.Show("Выберите переключатель фигуры!");
            }
        }
    }
}
