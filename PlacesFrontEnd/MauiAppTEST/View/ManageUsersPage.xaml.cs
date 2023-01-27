using MauiAppTEST.Services;
using MauiAppTEST.Models;
using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ManageUsersPage : ContentPage
{
	public ManageUsersPage(ManageUsersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
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

    private void OnSeeUserInfoClicked(object sender, EventArgs e)
    {
        var animation = new Animation();

        if (!UserInfoFrame.IsVisible)
        {
            UserInfoFrame.IsVisible = true;
            animation = new((value) => { UserInfoFrame.Opacity = value; }, 0, 1);
            animation = new((value) => { UserInfoFrame.HeightRequest = value; }, 0, 300);
        }
        else
            UserInfoFrame.IsVisible = false;

        //ManageUsersFrame.Animate("Opacity", animation, length: 200);
        UserInfoFrame.Animate("HeightRequest", animation, length: 100);
    }

    private void OnRemoveUserClicked(object sender, EventArgs e)
    {
        if (!RemoveUserPopUp.IsVisible)
        {
            RemoveUserPopUp.IsVisible = true;
        }
        else
            RemoveUserPopUp.IsVisible = false;

    }
}