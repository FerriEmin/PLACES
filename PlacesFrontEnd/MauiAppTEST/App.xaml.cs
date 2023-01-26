﻿
using MauiAppTEST.Services;
using MauiAppTEST.Models;

namespace MauiAppTEST;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        GlobalService.user = new()
        {
            UserName = "MonaLisa",
            FirstName = "Mona",
            LastName = "Lisa",
            DateOfBirth = new DateTime(1980, 12, 11),
        };

        MainPage = new AppShell();
	}
}
