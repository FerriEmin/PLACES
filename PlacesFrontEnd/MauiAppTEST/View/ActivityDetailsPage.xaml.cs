using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ActivityDetailsPage : ContentPage
{
	public ActivityDetailsPage(ActivityDetailsViewModel vm)
	{
		InitializeComponent();
        LoadAllStars();
		BindingContext = vm;
	}

    void LoadAllStars()
    {
        if (ActivityViewModel.rev.Rating == 1)
        {
            star1.IsVisible = true;
        }
        else if(ActivityViewModel.rev.Rating == 2)
        {
            star1.IsVisible = true;
            star2.IsVisible = true;
        }
        else if (ActivityViewModel.rev.Rating == 3)
        {
            star1.IsVisible = true;
            star2.IsVisible = true;
            star3.IsVisible = true;
        }
        else if (ActivityViewModel.rev.Rating == 4)
        {
            star1.IsVisible = true;
            star2.IsVisible = true;
            star3.IsVisible = true;
            star4.IsVisible = true;
        }
        else if (ActivityViewModel.rev.Rating == 5)
        {
            star1.IsVisible = true;
            star2.IsVisible = true;
            star3.IsVisible = true;
            star4.IsVisible = true;
            star5.IsVisible = true;
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //MainThread.BeginInvokeOnMainThread(async () => { await RunService(); });
    }
}