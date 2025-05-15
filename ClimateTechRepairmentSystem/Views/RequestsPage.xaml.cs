using System.Windows;
using System.Windows.Controls;

namespace ClimateTechRepairmentSystem.Views;

public partial class RequestsPage : Page
{
    public RequestsPage()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MainWindow.ContentFrame.Navigate(new AddRequestPage());
    }
}
