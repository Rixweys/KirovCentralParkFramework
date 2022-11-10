using KirovCentralParkFramework.Classes;
using System.Windows.Controls;

namespace KirovCentralParkFramework.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            FirstnameTextBlock.Text = Data.Firstname;
            LastnameTextBlock.Text = Data.Lastname;
            RoleTextBlock.Text = Data.Role;
        }
    }
}
