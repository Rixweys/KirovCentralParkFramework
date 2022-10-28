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

namespace KirovCentralParkFramework.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void ShowHideButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShowHideButton.Content.ToString() == "Show")
            {
                if (!string.IsNullOrWhiteSpace(HidePasswordBox.Password))
                {
                    HidePasswordBox.Visibility = Visibility.Hidden;
                    ShowPassTextBox.Visibility = Visibility.Visible;
                    ShowHideButton.Content = "Hide";
                    ShowPassTextBox.Text = HidePasswordBox.Password;
                }
                else
                    MessageBox.Show("nope");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(ShowPassTextBox.Text))
                {
                    ShowHideButton.Content = "Show";
                    HidePasswordBox.Visibility = Visibility.Visible;
                    ShowPassTextBox.Visibility = Visibility.Hidden;
                    HidePasswordBox.Password = ShowPassTextBox.Text;
                }
                else
                    MessageBox.Show("nope");
            }
        }
    }
}
