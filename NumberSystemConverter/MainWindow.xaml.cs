using System;
using System.Windows;
using System.Windows.Controls;

namespace NumberSystemConverter {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void convertButton_Click(object sender, RoutedEventArgs e) {
            string result = Converter.convert(getFromSelection(), getToSelection(), inputTextBox.Text.ToUpper());
            Clipboard.SetText(result);
            MessageBox.Show(result + "\nResult cut to clipboard");
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
