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
using System.Collections.ObjectModel;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int result = 0;
        int coordinate = 5;
        int num;
        public MainWindow()
        {
            InitializeComponent();
            label_res.Content = result;
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();
            mySP.Children.Add(stackPanel);

            TextBox textBox = new TextBox()
            {
                Margin = new Thickness(5, coordinate, 5, 5)

            };

            textBox.TextChanged += Text_Changed;
            coordinate += 1;
            stackPanel.Children.Add(textBox);

            ComboBox comboBox = new ComboBox();
            stackPanel.Children.Add(comboBox);
            ObservableCollection<string> mathOp = new ObservableCollection<string>();
            mathOp.Add("+");
            mathOp.Add("-");
            mathOp.Add("*");
            mathOp.Add("/");
            comboBox.ItemsSource = mathOp;
        }


        public void Text_Changed(object sender, RoutedEventArgs e)
        {
            foreach (var element in mySP.Children)
            {
                if (element is StackPanel panel)
                {
                    foreach (var item in panel.Children)
                    {
                        if (item is TextBox textBox)
                        {
                            try
                            {
                                num = int.Parse(textBox.Text);
                            }
                            catch
                            {
                                if (textBox.Text == "") { }
                                else MessageBox.Show("Это не число. Введи нормально.");
                            }
                        }
                        if (item is ComboBox comboBox)
                        {
                            switch (comboBox.SelectedItem)
                            {
                                case "+":
                                    {
                                        result += num;
                                        break;
                                    }
                                case "-":
                                    {
                                        result -= num;
                                        break;
                                    }
                                case "*":
                                    {
                                        result *= num;
                                        break;
                                    }
                                case "/":
                                    {
                                        result /= num;
                                        break;
                                    }

                            }
                        }
                    }

                }
            }
            label_res.Content = result;
            result = 0;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int spLength = mySP.Children.Count - 1;
            for (int i = spLength; i >= 0; i--)
            {
                if (mySP.Children[i] is StackPanel)
                    mySP.Children.RemoveAt(i);
                break;
            }
            Text_Changed(sender, e);
        }
    }
}
