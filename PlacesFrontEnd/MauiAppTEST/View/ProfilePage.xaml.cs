using MauiAppTEST.Models;
using MauiAppTEST.Services;
using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void OnProfileInfoButtonClicked(object sender, EventArgs e)
	{
        var animation = new Animation();

        if (!UserInfoFrame.IsVisible)
        {
            UserInfoFrame.IsVisible = true;
            animation = new((value) => { UserInfoFrame.Opacity = value; }, 0, 1);
            animation = new((value) => { UserInfoFrame.HeightRequest = value; }, 0, 300);
        }
        else
        {
            UserInfoFrame.IsVisible = false;
        

        UserInfoFrame.Animate("HeightRequest", animation, length: 100);
        }

    }

	void LoadUserActivities()
	{
        foreach (var user in UserServices.GetUsers())
        {
            if(GlobalService.user.Id == user.Id)
            {
                foreach (var activity in GlobalService.user.Post)
                {
                    var abc = activity.Name;
                }
            }
        }
    }


}