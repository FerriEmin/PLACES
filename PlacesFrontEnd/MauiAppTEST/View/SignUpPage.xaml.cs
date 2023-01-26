using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}