using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; // Button()
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media; // SolidColorBrush() || Colors
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ViewModels; // MainWindowViewModel()

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();

            Button myButton = new Button();
            myButton.Width = 100;
            myButton.Height = 30;
            myButton.Content = "Тест";
            // myButton.Margin = 10;
            // myButton.Click = ButtonClick();
            myButton.Background = new SolidColorBrush(Colors.Green);

            stackPanel.Children.Add(myButton);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string text = textBox1.Text;
            if (text != "")
            {
                MessageBox.Show(text);
            }
            else
            {
                MessageBox.Show("Необходимо ввести текст!");
            }
        }

    }

    public class Phone
    {
        public string Name { get; set; }
        public int Price { get; set; }
        
        public override string ToString()
        {
            return $"Смартфон {this.Name} цена: {this.Price}";
        }
    }

}
