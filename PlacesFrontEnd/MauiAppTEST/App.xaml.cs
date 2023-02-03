
using MauiAppTEST.Services;
using MauiAppTEST.Models;
using MauiAppTEST.View;
using MauiAppTEST.CustomUI;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Handlers;


namespace MauiAppTEST;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();


        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(IView.Background), (handler, view) =>
        {
            if (view is CustomEntry)
            {
                var color = view.Background.ToColor();
                Color apa = Color.FromRgb(color.Red, color.Green, color.Blue);

#if ANDROID
                handler.PlatformView.SetBackgroundColor(apa.ToPlatform());
#elif IS
                handler.PlatformView.BackgroundColor = Colors.LightGray.ToPlatform();
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.Line;
#elif WINDOWS
                handler.PlatformView.Background = Colors.LightGray.ToPlatform();
#endif

            }
        });

        GlobalService.user = new()
        {
            Username = "MonaLisa",
            FirstName = "Mona",
            LastName = "Lisa",
            Id = 123,
            DateOfBirth = new DateTime(1980, 12, 11),
        };

        MainPage = new AppShell();
	}
}
