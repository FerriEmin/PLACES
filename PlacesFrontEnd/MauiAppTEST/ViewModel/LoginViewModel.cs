using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.View;
using MauiAppTEST.Models;
using MauiAppTEST.Services;

namespace MauiAppTEST.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        public string LoginPassword { get; set; }
        public string LoginEmail { get; set; }
        public User user { get; set; }
        public LoginViewModel()
        {
            user = GlobalService.user;
        }
        [RelayCommand]
        async Task AuthenticateUser()
        {
            Console.WriteLine("Testar att logga in");
            Console.WriteLine(user.UserName);
            Console.WriteLine(user.FirstName);

            // Gör ett api-call

            //boolean loggedIn = await api.login(LoginEmail, LoginPassword);

            // if (loggedIn)
            // {
            // sätta cookie eller session lr något
            // gå till profilsidan
            await Shell.Current.GoToAsync(nameof(ProfilePage));
            // }
        }

    }

       
    }


