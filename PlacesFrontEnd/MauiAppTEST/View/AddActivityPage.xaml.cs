using MauiAppTEST.Services;
using MauiAppTEST.Models;
using MauiAppTEST.View;
using MauiAppTEST.CustomUI;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Handlers;
using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class AddActivityPage : ContentPage
{
    public AddActivityViewModel addActivityViewModel;

	public AddActivityPage(AddActivityViewModel vm)
	{
        addActivityViewModel = vm;
		BindingContext= vm;

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

        InitializeComponent();

    }

    public void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        addActivityViewModel.Back();
    }
      
}