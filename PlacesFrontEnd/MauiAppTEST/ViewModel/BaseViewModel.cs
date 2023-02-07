using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.View;
using MauiAppTEST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel() { }

    [RelayCommand]
    public Task Navigation() => Shell.Current.GoToAsync(nameof(CityPage));

    [RelayCommand]
    public Task NavigateToLoginPage() => Shell.Current.GoToAsync(nameof(LoginPage));

    [RelayCommand]
    public Task NavigateToSignUpPage() => Shell.Current.GoToAsync(nameof(SignUpPage));

    [RelayCommand]
    public Task NavigateToProfilePage() => Shell.Current.GoToAsync(nameof(ProfilePage));

    [RelayCommand]
    public Task NavigateToAdminPage() => Shell.Current.GoToAsync(nameof(AdminPage));

    [RelayCommand]
    public Task NavigateToManageUsersPage() => Shell.Current.GoToAsync(nameof(ManageUsersPage));

    [RelayCommand]
    public Task NavigateToActivityPage() => Shell.Current.GoToAsync(nameof(ActivityPage));

    [RelayCommand]
    public Task NavigateToMapPage() => Shell.Current.GoToAsync(nameof(MapPage));

    [RelayCommand]
    public Task NavigateToActivityDetailsPage() => Shell.Current.GoToAsync(nameof(ActivityDetailsPage));

    [RelayCommand]
    public Task NavigateToSettingsPage() => Shell.Current.GoToAsync(nameof(SettingsPage));

    [RelayCommand]
    public Task NavigateToAddActivityPage() => Shell.Current.GoToAsync(nameof(AddActivityPage));

    [RelayCommand]
    public Task NavigateToSearchPage() => Shell.Current.GoToAsync(nameof(SearchPage));

    [RelayCommand]
    public Task NavigateToSignLogPage() => Shell.Current.GoToAsync(nameof(SignLogPage));

    [RelayCommand]
    public Task Back() => Shell.Current.GoToAsync("..");
}

