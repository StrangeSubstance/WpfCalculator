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

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int result = 0;
        public MainWindow()
        {
            InitializeComponent();
            label_res.Content = result;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox()
            {
                Width = 120,
                Height = 40,
                Margin = new Thickness(10, 0, 0, 0)

            };

            textBox.TextChanged += Text_Changed;

            myGrid.Children.Add(textBox);
        }

        private void Text_Changed(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            foreach (var element in myGrid.Children)
            {
                if (element is TextBox text)
                {
                    if (int.TryParse(text.Text, out var num)) ;
                    else
                        MessageBox.Show("Это не число. Введи нормально.");
                    sum += num;
                }
            }
            label_res.Content = sum;
        }

    }
}
