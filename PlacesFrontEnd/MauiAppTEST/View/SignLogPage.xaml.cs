using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class SignLogPage : ContentPage
{
    public SignLogViewModel signLogViewModel;

	public SignLogPage(SignLogViewModel vm)
	{
        signLogViewModel = vm;
        BindingContext = vm;
		InitializeComponent();
	}
}
