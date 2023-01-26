using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiAppTEST.ViewModel
{

    public partial class SignUpViewModel : BaseViewModel
    {
        public string SignupFirstname { get; set; }
        public string SignupLastname { get; set; }
        public string SignupEmail { get; set; }
        public string SignupPassword { get; set; }
        public string SignupEmailVerify { get; set; }
        public SignUpViewModel() {
        
        }
        

        [RelayCommand]
        async Task RegisterUser()
        {
            Console.WriteLine("Testar att registera");

            // Gör ett api-call

            //boolean signedUp = await api.sigup(SignupFirstname, SignupLastname, SignupEmail, SignupEmailVerify, SignupPassword,  );

            // if (signedUp)
            // {
            // sätta cookie eller session lr något
            // gå till profilsidan eller nån startsida
            await Application.Current.MainPage.DisplayAlert("Registration done", "You have created a user account", "OK");
            await Shell.Current.GoToAsync(nameof(ProfilePage));
            // }
        }
    }
}
