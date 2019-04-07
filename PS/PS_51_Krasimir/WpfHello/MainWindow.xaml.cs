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

namespace WpfHello
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
            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("Дължината на името трябва да бъде поне 2 символа.");
            }
            else
            {
                MessageBox.Show($"Здрасти {txtName.Text}! Това е твоята първа WPF програма.");
            }
        }

        private void TxtFactorial_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtNumber.Text = "";
        }

        private void TxtPower_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtPower.Text = "";
        }

        private void BtnFactorial_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumber.Text))
            {
                var result = Factorial_Recursion(int.Parse(txtNumber.Text));
                MessageBox.Show(result.ToString());
            }
            else
            {
                MessageBox.Show("Не е въведено число");
            }
        }

        private double Factorial_Recursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * Factorial_Recursion(number - 1);
        }

        private void BtnPower_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPower.Text) && !string.IsNullOrEmpty(txtNumber.Text))
            {
                var result = Math.Pow(double.Parse(txtNumber.Text), double.Parse(txtPower.Text));
                MessageBox.Show(result.ToString());
            }
            else
            {
                MessageBox.Show("Не е въведено число");
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show("Да затворя ли програмата?", "Затваряне на програмата", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
