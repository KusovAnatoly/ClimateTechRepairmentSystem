using System.Collections.ObjectModel;
using ClimateTechRepairmentSystem.Models.Generated;
using ClimateTechRepairmentSystem.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace ClimateTechRepairmentSystem.ViewModels;

public partial class RequestsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Request> _requests;

    public RequestsViewModel()
    {
        Task.Run(LoadDataAsync);
    }


    [RelayCommand]
    public void GoToAddRequest()
    {
        MainWindow.ContentFrame.Navigate(new AddRequestPage());
    }

    private async Task LoadDataAsync()
    {
        using var dbContext = new Database1Context();
        var data = await dbContext.Requests
            .Include(r => r.Client)
            .Include(r => r.Master)
            .Include(r => r.TechType)
            .Include(r => r.RequestStatus)
            .ToListAsync();
        Requests = new ObservableCollection<Request>(data);
    }
}
