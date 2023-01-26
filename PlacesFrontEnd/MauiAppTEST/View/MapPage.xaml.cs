using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class MapPage : ContentPage
{
	public MapPage(MapViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}