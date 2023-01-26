using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private void LoginEmail_TextChanged(object sender, TextChangedEventArgs e)
    {
        //Static user == e.New
    }
}