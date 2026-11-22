using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPM9_Collection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   public partial class MainWindow : Window
    {
        // Используем обобщенную коллекцию List<T> (Лекция стр. 32)
        List<int> mas = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Генерация массива (в меню)
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            mas.Clear(); 
            Random rnd = new Random();
            int count = rnd.Next(5, 15); 
            string displayStr = "";

            for (int i = 0; i < count; i++)
            {
                // Генерируем числа от 1 до 30
                int num = rnd.Next(1, 31); 
                mas.Add(num); 
                displayStr += num + " ";
            }

            txtArrayDisplay.Text = displayStr;
            txtResult.Text = ""; 
        }

        // Проверка (кнопка)
        private void CheckArray_Click(object sender, RoutedEventArgs e)
        {
            if (mas.Count == 0)
            {
                MessageBox.Show("Сначала сгенерируйте массив через верхнее меню!", "Ошибка");
                return;
            }

            if (!int.TryParse(txtA.Text, out int a) || !int.TryParse(txtB.Text, out int b))
            {
                MessageBox.Show("Введите корректные целые числа для границ a и b!", "Ошибка");
                return;
            }

            // Если a больше b, меняем их местами для корректной работы интервала
            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            bool hasElementInside = false;
            int insideElement = 0;

            // Ищем элемент, который ПОПАДАЕТ в интервал
            for (int i = 0; i < mas.Count; i++)
            {
                // Условие: элемент больше или равен a И меньше или равен b
                if (mas[i] >= a && mas[i] <= b)
                {
                    hasElementInside = true;
                    insideElement = mas[i];
                    break; // Нашли хотя бы один - выходим
                }
            }

            // Вывод результата
            if (hasElementInside)
            {
                txtResult.Text = $"Результат: ДА.\nНайден элемент, попадающий в интервал [{a}; {b}]: {insideElement}";
            }
            else
            {
                txtResult.Text = $"Результат: НЕТ.\nВ массиве нет ни одного элемента в интервале [{a}; {b}].";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        private void Infa_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №9\nВариант 12\nРазработал: [Ваше ФИО]\nЗадание: Проверить, имеется ли в массиве хотя бы один элемент, попадающий в интервал [a; b]", "О программе");
        }
    }
}