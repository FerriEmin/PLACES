
using MauiAppTEST.Services;
using MauiAppTEST.Models;
using MauiAppTEST.View;

namespace MauiAppTEST;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

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
