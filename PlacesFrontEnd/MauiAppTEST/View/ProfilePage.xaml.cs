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