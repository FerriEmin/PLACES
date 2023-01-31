using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}