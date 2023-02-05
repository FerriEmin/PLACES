﻿using MauiAppTEST.View;
using MauiAppTEST.ViewModel;
using MauiAppTEST.Services;
using Microsoft.Extensions.Logging;


namespace MauiAppTEST;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .UseMauiMaps();

        builder.Services.AddSingleton<MapService>();
        builder.Services.AddSingleton<LocationService>();
        builder.Services.AddSingleton<PinsService>();
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<GoogleApiService>();

        builder.Logging.AddDebug();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<CityViewModel>();
        builder.Services.AddSingleton<DetailViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<SignUpViewModel>();
        builder.Services.AddSingleton<ActivityViewModel>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<MapViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddTransient<AddActivityViewModel>();
        builder.Services.AddTransient<AdminViewModel>();
        builder.Services.AddTransient<ManageUsersViewModel>();
        builder.Services.AddTransient<ActivityDetailsViewModel>();
        builder.Services.AddSingleton<SearchViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<CityPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<SignUpPage>();
        builder.Services.AddSingleton<ActivityPage>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<MapPage>();
        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddTransient<AdminPage>();
        builder.Services.AddTransient<ManageUsersPage>();
        builder.Services.AddTransient<ActivityDetailsPage>();
        builder.Services.AddTransient<AddActivityPage>();
        builder.Services.AddSingleton<SearchPage>();

        return builder.Build();
	}
}
