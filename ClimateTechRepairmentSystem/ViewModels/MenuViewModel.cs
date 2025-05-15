using ClimateTechRepairmentSystem.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClimateTechRepairmentSystem.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    [RelayCommand]
    public void GoToRequests()
    {
        MainWindow.ContentFrame.Navigate(new RequestsPage());
    }
}
