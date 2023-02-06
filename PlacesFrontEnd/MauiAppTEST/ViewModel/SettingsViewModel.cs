using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppTEST.View;

namespace MauiAppTEST.ViewModel
{
    public partial class SettingsViewModel : BaseViewModel
    {

        [RelayCommand]
        public Task NavigateToProfilePage() => Shell.Current.GoToAsync(nameof(ProfilePage));

        [RelayCommand]
        Task Back() => Shell.Current.GoToAsync("..");

        public SettingsViewModel() { }
    }
}
