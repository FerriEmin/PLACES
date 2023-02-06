using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiAppTEST.ViewModel
{
    public partial class AddActivityViewModel : BaseViewModel
    {

        [RelayCommand]
        public Task Back() => Shell.Current.GoToAsync("..");

        public AddActivityViewModel()
        {

        }

        
    }
}
