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

namespace NumberToWords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int inputValue = int.Parse(NumberTxt.Text);
                ResultTxtBlock.Text = NumberConversion(inputValue);
            }
            catch (Exception)
            {
                ResultTxtBlock.Text = "Please enter zero to 999999999";
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            NumberTxt.Text = string.Empty;
            ResultTxtBlock.Text = string.Empty;  
        }

        public string NumberConversion(int number)
        {
            if (number == 0)
                return "zero";

            string words = "";
            try
            {
                if ((number / 100000) > 0)
                {
                    words += NumberConversion(number / 1000000) + " million ";
                    number %= 1000000;
                }

                if ((number / 1000) > 0)
                {
                    words += NumberConversion(number / 1000) + " thousand ";
                    number %= 1000;
                }

                if ((number / 100) > 0)
                {
                    words += NumberConversion(number / 100) + " hundred ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (words != "")
                        words += "and ";

                    if (number < 20)
                    {
                        var singleValue = (SigleDigits)number;
                        words += singleValue.ToString();
                    }
                    else
                    {
                        var tens = (number / 10);
                        var enumValue = (DoubleDigits)tens;
                        words += enumValue.ToString();
                        if ((number % 10) > 0)
                        {
                            var single = (number % 10);
                            var singleEnum = (SigleDigits)single;
                            words += singleEnum.ToString();
                        }
                    }
                }

            }
            catch (Exception)
            {
                ResultTxtBlock.Text = "Please enter zero to 999999999";
            }

            return words;
        } 
    }

    public enum SigleDigits
    {
        zero, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen
    }

    public enum DoubleDigits
    {
        zero, ten, twenty, thirty, forty, fifty, sixty, seventy, eighty, ninety
    }
}
