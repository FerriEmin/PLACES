using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.ViewModel
{
    //ObservableObject
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            
        }

        [RelayCommand]
        Task Navigation() => Shell.Current.GoToAsync(nameof(CityPage));

        [RelayCommand]
        Task NavigateToDetailPage() => Shell.Current.GoToAsync(nameof(DetailPage));

        [RelayCommand]
        Task NavigateToLoginPage() => Shell.Current.GoToAsync(nameof(LoginPage));

        [RelayCommand]
        Task NavigateToSignUpPage() => Shell.Current.GoToAsync(nameof(SignUpPage));

        [RelayCommand]
        Task NavigateToProfilePage() => Shell.Current.GoToAsync(nameof(ProfilePage));

        [RelayCommand]
        Task NavigateToAdminPage() => Shell.Current.GoToAsync(nameof(AdminPage));

        [RelayCommand]
        Task NavigateToManageUsersPage() => Shell.Current.GoToAsync(nameof(ManageUsersPage));

        [RelayCommand]
        Task NavigateToActivityPage() => Shell.Current.GoToAsync(nameof(ActivityPage));

        [RelayCommand]
        Task NavigateToMapPage() => Shell.Current.GoToAsync(nameof(MapPage));

        [RelayCommand]
        Task NavigateToActivityDetailsPage() => Shell.Current.GoToAsync(nameof(ActivityDetailsPage));

        [RelayCommand]
        Task NavigateToSettingsPage() => Shell.Current.GoToAsync(nameof(SettingsPage));

        [RelayCommand]
        Task NavigateToAddActivityPage() => Shell.Current.GoToAsync(nameof(AddActivityPage));

        [RelayCommand]
        public Task NavigateToSearchPage() => Shell.Current.GoToAsync(nameof(SearchPage));


        [RelayCommand]
        Task Back() => Shell.Current.GoToAsync("..");
    }
}
