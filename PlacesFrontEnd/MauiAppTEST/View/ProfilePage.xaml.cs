using MauiAppTEST.Models;
using MauiAppTEST.Services;
using MauiAppTEST.ViewModel;
using MauiAppTEST.CustomUI;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Handlers;

namespace MauiAppTEST.View;

public partial class ProfilePage : ContentPage
{
    ProfileViewModel profileViewModel;
	public ProfilePage(ProfileViewModel vm)
	{
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(IView.Background), (handler, view) =>
        {
            if (view is CustomEntry)
            {
                Color colorFromButton = view.Background.ToColor();

#if ANDROID
                handler.PlatformView.SetBackgroundColor(colorFromButton.ToPlatform());
#elif IOS
                handler.PlatformView.BackgroundColor = colorFromButton.ToPlatform();
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.Background = colorFromButton.ToPlatform();
#endif

            }
        });

        profileViewModel = vm;
		InitializeComponent();
		BindingContext = vm;
	}

    public void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        profileViewModel.Back();
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