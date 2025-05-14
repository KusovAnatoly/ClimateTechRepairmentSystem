using System.Windows;
using ClimateTechRepairmentSystem.Models.Generated;

namespace ClimateTechRepairmentSystem.Views;

public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var dbContext = new Database1Context())
        {
            var login = TextBox.Text;
            var password = PasswordBox.Password;
            if (dbContext.Users.Any(u => u.Password == password && u.Login == login))
            {
                App.User = dbContext.Users.First(u => u.Password == password && u.Login == login);
                new MainWindow().Show();
                Close();
            }
        }
    }
}
