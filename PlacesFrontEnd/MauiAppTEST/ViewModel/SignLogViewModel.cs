using MauiAppTEST.View;
using CommunityToolkit.Mvvm.Input;


namespace MauiAppTEST.ViewModel
{
	public partial class SignLogViewModel : BaseViewModel
	{
        [RelayCommand]
        Task NavigateToLoginPage() => Shell.Current.GoToAsync(nameof(LoginPage));

        [RelayCommand]
        Task NavigateToSignUpPage() => Shell.Current.GoToAsync(nameof(SignUpPage));

        public SignLogViewModel()
		{
		}
	}
}

