using KirovCentralParkFramework.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            if (ShowHideButton.Content.ToString() == "Показать")
            {
                if (!string.IsNullOrWhiteSpace(HidePasswordBox.Password))
                {
                    HidePasswordBox.Visibility = Visibility.Hidden;
                    ShowPassTextBox.Visibility = Visibility.Visible;
                    ShowHideButton.Content = "Спрятать";
                    ShowPassTextBox.Text = HidePasswordBox.Password;
                }
                else
                    MessageBox.Show("nope");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(ShowPassTextBox.Text))
                {
                    ShowHideButton.Content = "Показать";
                    HidePasswordBox.Visibility = Visibility.Visible;
                    ShowPassTextBox.Visibility = Visibility.Hidden;
                    HidePasswordBox.Password = ShowPassTextBox.Text;
                }
                else
                    MessageBox.Show("nope");
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (DBConnect.DBContext.Emploee.Any(u => u.Login == LoginTextBox.Text && (u.Password == HidePasswordBox.Password || u.Password == ShowPassTextBox.Text)))
                NavigationService.Navigate(new UserPage());
            else
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
