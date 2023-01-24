using MauiAppTEST.View;

namespace MauiAppTEST;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CityPage), typeof(CityPage));
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(ActivityPage), typeof(ActivityPage));
		Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
		Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
		Routing.RegisterRoute(nameof(ManageUsersPage), typeof(ManageUsersPage));
	}
}
