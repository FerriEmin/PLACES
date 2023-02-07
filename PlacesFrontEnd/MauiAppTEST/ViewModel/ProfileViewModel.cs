using MauiAppTEST.Services;
using MauiAppTEST.Models;
using MauiAppTEST.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiAppTEST.ViewModel
{
    public partial class ProfileViewModel : BaseViewModel
    {
        public User user { get; set; }
        public ProfileViewModel()
        {
            user = GlobalService.user;
        }
    }
}
