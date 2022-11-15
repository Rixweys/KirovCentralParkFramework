using KirovCentralParkFramework.Classes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace KirovCentralParkFramework.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        DispatcherTimer _dispatcherTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
        Stopwatch _stopwatch = new Stopwatch();
        int _timerOff = 0;
        public UserPage()
        {
            InitializeComponent();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            _dispatcherTimer.Start();
            _stopwatch.Start();
            FirstnameTextBlock.Text = Data.Firstname;
            LastnameTextBlock.Text = Data.Lastname;
            RoleTextBlock.Text = Data.Role;
            ImageBox.Source = Data.Image;
            if (Data.Role == "Администратор\r\n")
            {
                MaterialsButton.Visibility = Visibility.Visible;
                CreateReportButton.Visibility = Visibility.Visible;
                EntryHistoryButton.Visibility = Visibility.Visible;
            }
            else if (Data.Role == "Продавец")
            {
                AcceptOrderButton.Visibility = Visibility.Visible;
            }
            else if (Data.Role == "Старший смены")
            {
                AcceptOrderButton.Visibility = Visibility.Visible;
                CreateOrderButton.Visibility = Visibility.Visible;
            }
        }

        private void _dispatcherTimer_Tick(object sender, EventArgs e)
        {
            SessionTime.Content = $"{_stopwatch.Elapsed.Hours}:{_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}";

            if (_stopwatch.Elapsed.Seconds == 5 && _timerOff == 0)
            {
                MessageBox.Show("Сеанс закончится через 5 минут.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (_stopwatch.Elapsed.Seconds >= 10)
            {
                _dispatcherTimer.Stop();
                _stopwatch.Stop();
                _stopwatch.Reset();
                MessageBox.Show("Сеанс завершен.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.Navigate(new LoginPage());
            }
        }

        private void Button_ClickBack(object sender, System.Windows.RoutedEventArgs e)
        {
            _dispatcherTimer.Stop();
            _stopwatch.Stop();
            _stopwatch.Reset();
            NavigationService?.Navigate(new LoginPage());
        }
    }
}
