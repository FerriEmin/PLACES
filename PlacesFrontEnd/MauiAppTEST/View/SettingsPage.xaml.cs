using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class SettingsPage : ContentPage
{
	SettingsViewModel settingsViewModel;
	public SettingsPage(SettingsViewModel vm)
	{
		settingsViewModel = vm;
		BindingContext = vm;
		InitializeComponent();
	}

    private void ProfileButton_Clicked(object sender, EventArgs e)
    {
		settingsViewModel.NavigateToProfilePage();
    }

    void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        settingsViewModel.Back();
    }

    void LogOutButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}