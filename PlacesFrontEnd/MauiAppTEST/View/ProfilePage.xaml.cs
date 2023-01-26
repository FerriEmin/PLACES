using MauiAppTEST.Models;
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
        Dictionary<int, ICollection<Review>> ReviewDictionary = new Dictionary<int, ICollection<Review>>();

    }


}