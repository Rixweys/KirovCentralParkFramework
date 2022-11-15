using KirovCentralParkFramework.Classes;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace KirovCentralParkFramework.Pages
{
    public partial class LoginPage : Page
    {
        int _entryAttempt = 0;
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

        private async void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var employee = await DBConnect.DBContext.Employee.ToListAsync();
            if (employee.Any(u => u.Login == LoginTextBox.Text && (u.Password == HidePasswordBox.Password || u.Password == ShowPassTextBox.Text)))
            {
                Data.Firstname = employee.FirstOrDefault(u => u.Login == LoginTextBox.Text).Firstname;
                Data.Lastname = employee.FirstOrDefault(u => u.Login == LoginTextBox.Text).Lastname;
                int userId = (await DBConnect.DBContext.Employee.FirstOrDefaultAsync(u => u.Login == LoginTextBox.Text)).IDRole;
                Data.Role = (await DBConnect.DBContext.Role.FirstOrDefaultAsync(r => r.ID == userId)).Name;


                using (var ms = new MemoryStream(employee.FirstOrDefault(e => e.Login == LoginTextBox.Text).Image))
                {

                    using (var memory = new MemoryStream())
                    {
                        new Bitmap(ms).Save(memory, ImageFormat.Png);
                        memory.Position = 0;

                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memory;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();

                        Data.Image = bitmapImage;
                    }
                }

                NavigationService.Navigate(new UserPage());
            }
            else
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
