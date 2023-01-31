using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Services;
using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.ViewModel
{
    [QueryProperty(nameof(User), nameof(User))]
    public partial class ManageUsersViewModel : BaseViewModel
    {
        [ObservableProperty]
        User user;

        public ManageUsersViewModel()
        {

        }
    }
}
