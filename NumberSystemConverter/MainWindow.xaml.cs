using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace NumberSystemConverter {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void convertButton_Click(object sender, RoutedEventArgs e) {
            
            string from = getFromSelection();
            string to = getToSelection();
            string input = inputTextBox.Text.ToUpper();

            if (validateInput(from, to, input)) {
                convert(from, to, input);
            } else {
                MessageBox.Show("Invalid Input");
            }
        }

        private void convert(string from, string to, string input) {
            try {
                string result = String.Empty;
                if (from == "fbinary" && to == "tbinary" || from == "foctal" && to == "toctal" || from == "fdecimal" && to == "tdecimal" || from == "fhexadecimal" && to == "thexadecimal") {
                    result = inputTextBox.Text;
                } else if (from == "fbinary" && to == "toctal") {
                    int integer = Convert.ToInt32(input, 2);
                    result = Convert.ToString(integer, 8);
                } else if (from == "fbinary" && to == "tdecimal") {
                    result = Convert.ToInt32(input, 2).ToString();
                } else if (from == "fbinary" && to == "thexadecimal") {
                    int integer = Convert.ToInt32(input, 2);
                    result = Convert.ToString(integer, 16);
                } else if (from == "foctal" && to == "tbinary") {
                    int integer = Convert.ToInt32(input, 8);
                    result = Convert.ToString(integer, 2);
                } else if (from == "foctal" && to == "tdecimal") {
                    result = Convert.ToInt32(input, 8).ToString();
                } else if (from == "foctal" && to == "thexadecimal") {
                    int integer = Convert.ToInt32(input, 8);
                    result = Convert.ToString(integer, 16);
                } else if (from == "fdecimal" && to == "tbinary") {
                    int integer = Convert.ToInt32(input, 10);
                    result = Convert.ToString(integer, 2);
                } else if (from == "fdecimal" && to == "toctal") {
                    int integer = Convert.ToInt32(input, 10);
                    result = Convert.ToString(integer, 8);
                } else if (from == "fdecimal" && to == "thexadecimal") {
                    int integer = Convert.ToInt32(input, 10);
                    result = Convert.ToString(integer, 16);
                } else if (from == "fhexadecimal" && to == "tbinary") {
                    int integer = Convert.ToInt32(input, 16);
                    result = Convert.ToString(integer, 2);
                } else if (from == "fhexadecimal" && to == "toctal") {
                    int integer = Convert.ToInt32(input, 16);
                    result = Convert.ToString(integer, 8);
                } else if (from == "fhexadecimal" && to == "tdecimal") {
                    int integer = Convert.ToInt32(input, 16);
                    result = Convert.ToString(integer, 10);
                }
                Clipboard.SetText(result);
                MessageBox.Show(result + "\nResult cut to clipboard");
            } catch (OverflowException ex) {
                MessageBox.Show("Number too big: Overflow");
            }
        }

        private bool validateInput(string from, string to, string input) {
            Regex r;
            if (from != String.Empty && to != String.Empty && input != String.Empty) {
                switch (from) {
                    case "fbinary":
                        r = new Regex(@"^[01]+$");
                        return r.Match(input).Success;
                    case "foctal":
                        r = new Regex(@"^[0-7]+$");
                        return r.Match(input).Success;
                    case "fdecimal":
                        r = new Regex(@"^[0-9]+$");
                        return r.Match(input).Success;
                    default:
                        r = new Regex(@"^[0-9A-F]+$");
                        return r.Match(input).Success;
                }
            }
            return false;
        }

        private string getToSelection() {
            foreach (RadioButton radioButton in toStackPanel.Children) {
                if (radioButton.IsChecked == true) {
                    return radioButton.Name;
                }
            }
            return String.Empty;
        }

        private string getFromSelection() {
            foreach (RadioButton radioButton in fromStackPanel.Children) {
                if (radioButton.IsChecked == true) {
                    return radioButton.Name;
                }
            }
            return String.Empty;
        }
    }
}
