using System.Collections.ObjectModel;
using ClimateTechRepairmentSystem.Models.Generated;
using ClimateTechRepairmentSystem.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClimateTechRepairmentSystem.ViewModels;

internal partial class AddRequestViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Master> _masters;
    [ObservableProperty]
    private Master _master;
    [ObservableProperty]
    private ObservableCollection<Client> _clients;
    [ObservableProperty]
    private Client _client;
    [ObservableProperty]
    private int _clientIndex;
    [ObservableProperty]
    private ObservableCollection<TechType> _techTypes;
    [ObservableProperty]
    private TechType _techType;
    [ObservableProperty]
    private string _model;
    [ObservableProperty]
    private string _problemDescription;
    [ObservableProperty]
    private string _surname;
    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private string _patronymic;
    [ObservableProperty]
    private string _phoneNumber;

    public AddRequestViewModel()
    {
        Task.Run(LoadMasters);
        AddCommand = new AsyncRelayCommand(Add);
    }

    public IAsyncRelayCommand AddCommand { get; }


    public async Task Add()
    {
        var client = new Client()
        {
            Surname = Surname,
            Name = Name,
            Patronymic = Patronymic,
            PhoneNumber = PhoneNumber,
        };

        var request = new Request
        {
            DateStarted = DateOnly.FromDateTime(DateTime.Now),
            TechTypeId = TechType.TypeId,
            Model = Model,
            ProblemDescription = ProblemDescription,
            RequestStatusId = 1,
            DueDate = null,
            MasterId = Master.MasterId
        };

        if (ClientIndex > 0)
        {

            request.ClientId = Client.ClientId;
        }
        else
        {
            request.Client = client;
        }

        using var dbContext = new Database1Context();
        await dbContext.Requests.AddAsync(request);
        await dbContext.SaveChangesAsync();
        MainWindow.ContentFrame.Navigate(new RequestsPage());
    }

    [RelayCommand]
    public void Cancel()
    {
        MainWindow.ContentFrame.Navigate(new RequestsPage());
    }

    private async Task LoadMasters()
    {
        using var dbContext = new Database1Context();
        Masters = new ObservableCollection<Master>(dbContext.Masters);
        Clients = new ObservableCollection<Client>(dbContext.Clients);
        TechTypes = new ObservableCollection<TechType>(dbContext.TechTypes);
    }
}
