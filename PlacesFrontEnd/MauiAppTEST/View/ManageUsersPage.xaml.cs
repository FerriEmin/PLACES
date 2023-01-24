using MauiAppTEST.Services;
using MauiAppTEST.TestData;
using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ManageUsersPage : ContentPage
{
	public ManageUsersPage(ManageUsersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        SetUserList(UserServices.GetUsers());
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    private void SetUserList(List<User> users)
    {
        UserView.ItemsSource = users;
    }
    private void ManageUserComments(object sender, EventArgs e)
    {
        var animation = new Animation();

        if (!ManageUsersFrame.IsVisible)
        {
            ManageUsersFrame.IsVisible = true;
            animation = new((value) => { ManageUsersFrame.Opacity = value; }, 0, 1);
            animation = new((value) => { ManageUsersFrame.HeightRequest = value; }, 0, 300);
        }
        else
            ManageUsersFrame.IsVisible = false;

        //ManageUsersFrame.Animate("Opacity", animation, length: 200);
        ManageUsersFrame.Animate("HeightRequest", animation, length: 100);
    }

 
}