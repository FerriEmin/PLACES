using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class AddActivityPage : ContentPage
{
	public AddActivityPage(AddActivityViewModel vm)
	{
		BindingContext= vm;
		InitializeComponent();
	}
}