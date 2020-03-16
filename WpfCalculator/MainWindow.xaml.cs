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
        int coordinate = 5;
        public MainWindow()
        {
            InitializeComponent();
            label_res.Content = result;
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox()
            {
                Margin = new Thickness(5, coordinate, 5, 5)

            };

            textBox.TextChanged += Text_Changed;
            coordinate += 1;
            mySP.Children.Add(textBox);

            //ComboBox operations = OperComboBox();

        }

        //private ComboBox OperComboBox()
        //{
        //    ComboBox CB = new ComboBox();
        //    //foreach (TextBox textBox in )
        //    {

        //        < ComboBox CB = "Operations" >
        //        {
        //        < TextBlock > + </ TextBlock >
        //        < TextBlock > - </ TextBlock >
        //        < TextBlock > * </ TextBlock >
        //        < TextBlock > / </ TextBlock >
        //        }
        //    </ ComboBox >

        //    }
        //    return CB;
        //}


        public void Text_Changed(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            foreach (var element in mySP.Children)
            {
                if (element is TextBox text)
                {
                    if (int.TryParse(text.Text, out var num)) ;

                    sum += num;
                }
            }
            label_res.Content = sum;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int spLength = mySP.Children.Count - 1;
            for (int i = spLength; i >= 0; i--)
            {
                if (mySP.Children[i] is TextBox)
                    mySP.Children.RemoveAt(i);
                break;
            }
            Text_Changed(sender, e);
        }
    }
}
