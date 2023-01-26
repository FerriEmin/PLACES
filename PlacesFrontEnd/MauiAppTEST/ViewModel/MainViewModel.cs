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
        Task Back() => Shell.Current.GoToAsync("..");

        //[ObservableProperty]
        //ObservableCollection<string> items;

        //[ObservableProperty]
        //string text;

        //[RelayCommand]
        //async Task Tap(string s)
        //{
        //    await Shell.Current.GoToAsync(nameof(CityPage));
        //}

        //void NavigationPages()
        //{
        //    Items = new ObservableCollection<string>();

        //    Items.Add("MainPage");
        //}
    }
}
