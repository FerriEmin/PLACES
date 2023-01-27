using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ActivityDetailsPage : ContentPage
{
	public ActivityDetailsPage(ActivityDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //MainThread.BeginInvokeOnMainThread(async () => { await RunService(); });
    }
}