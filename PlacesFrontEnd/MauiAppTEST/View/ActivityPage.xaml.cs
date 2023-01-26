using DocumentFormat.OpenXml.Spreadsheet;
using MauiAppTEST.ViewModel;
using MauiAppTEST.Services;

namespace MauiAppTEST.View;

public partial class ActivityPage : ContentPage
{
	public ActivityPage(ActivityViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        ReviewServices.GetReviewList();
        UserServices.GetUsers();
        PostServices.GetPosts();
	}
    void LoadRating()
    {

    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //MainThread.BeginInvokeOnMainThread(async () => { await RunService(); });
    }
}