using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using AccountManagerApp.BLL;
using AccountManagerApp.Models;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace AccountManagerApp.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private AccountsService? _accountsService;

    [Reactive] private Guid? _id;
    [Reactive] private string? _login;
    [Reactive] private string? _password;
    [Reactive] private string? _lastName;
    [Reactive] private string? _firstName;
    [Reactive] private string? _description;
    [Reactive] private string? _email;
    [Reactive] private ObservableCollection<string> _phoneNumbers = [];
    [Reactive] private bool? _isActive;

    public ObservableCollection<Account> Accounts { get; } = [];
    [Reactive] private Account? _selectedAccount;

    [Reactive] private string? _searchQuery;

    [ReactiveCommand]
    private async Task Load()
    {
        if (_accountsService == null) _accountsService = new AccountsService();

        var accounts = _accountsService.GetAllAsync();
        var accountList = new List<Account>();

        await foreach (var account in accounts)
        {
            accountList.Add(account);
        }

        RxApp.MainThreadScheduler.Schedule(() =>
        {
            Accounts.Clear();
            foreach (var account in accountList)
            {
                Accounts.Add(account);
            }
        });
    }

    public MainWindowViewModel()
    {
        this.WhenAnyValue(vm => vm.SelectedAccount)
            .Subscribe(a =>
            {
                Id = a?.Id;
                Login = a?.Login;
                Password = a?.Password;
                LastName = a?.LastName;
                FirstName = a?.FirstName;
                Description = a?.Description;
                Email = a?.Email;
                IsActive = a?.IsActive;

                PhoneNumbers.Clear();
                foreach (var phoneNumber in a?.PhoneNumbers ?? [])
                {
                    PhoneNumbers.Add(phoneNumber);
                }
            });
    }
}
