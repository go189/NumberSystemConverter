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
            string input = inputTextBox.Text;

            if (validateInput(from, to, input)) {
                convert(from, to, input);
            } else { 
                //INFORM USER INVALID INPUT
            }
        }

        private void convert(string from, string to, string input) {
            
        }

        private bool validateInput(string from, string to, string input) {
            if (from != null && to != null && input != "") {
                if (from == "binary" || from == "octal" || from == "decimal") {
                    if (int.TryParse(input, out int result)) {
                        return true;
                    }
                } else {
                    return input.IsHex();
                }
            }
        }

        private string getToSelection() {
            foreach (RadioButton radioButton in toStackPanel.Children) {
                if (radioButton.IsChecked == true) {
                    return radioButton.Name;
                }
            }
            return null;
        }

        private string getFromSelection() {
            foreach (RadioButton radioButton in fromStackPanel.Children) {
                if (radioButton.IsChecked == true) {
                    return radioButton.Name;
                }
            }
            return null;
        }
    }
}
