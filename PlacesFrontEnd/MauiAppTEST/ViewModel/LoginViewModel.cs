using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.View;

namespace MauiAppTEST.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        public string LoginPassword { get; set; }
        public string LoginEmail { get; set; }

        public LoginViewModel()
        {

        }

        [RelayCommand]
        async Task AuthenticateUser()
        {
            Console.WriteLine("Testar att logga in");
            Console.WriteLine(LoginEmail);
            Console.WriteLine(LoginPassword);

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
