using MauiAppTEST.View;

namespace MauiAppTEST;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CityPage), typeof(CityPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(ActivityPage), typeof(ActivityPage));
		Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
		Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(ManageUsersPage), typeof(ManageUsersPage));
        Routing.RegisterRoute(nameof(ActivityDetailsPage), typeof(ActivityDetailsPage));
        Routing.RegisterRoute(nameof(AddActivityPage), typeof(AddActivityPage));
        Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
        Routing.RegisterRoute(nameof(SignLogPage), typeof(SignLogPage));

    }
}
