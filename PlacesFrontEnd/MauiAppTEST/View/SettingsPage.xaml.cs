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
}