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
	public AddActivityPage(AddActivityViewModel vm)
	{
		BindingContext= vm;

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(IView.Background), (handler, view) =>
        {
            if (view is CustomEntry)
            {
                Color colorFromButton = view.Background.ToColor();

#if ANDROID
                handler.PlatformView.SetBackgroundColor(colorFromButton.ToPlatform());
#elif IS
                handler.PlatformView.BackgroundColor = Colors.LightGray.ToPlatform();
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.Line;
#elif WINDOWS
                handler.PlatformView.Background = Colors.LightGray.ToPlatform();
#endif

            }
        });

        InitializeComponent();

    }


    private void entry_Focused(object sender, FocusEventArgs e)
    {

    }
}