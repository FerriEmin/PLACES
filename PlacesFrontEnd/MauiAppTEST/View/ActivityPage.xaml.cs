using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ActivityPage : ContentPage
{
	public ActivityPage(ActivityViewModel vm)
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