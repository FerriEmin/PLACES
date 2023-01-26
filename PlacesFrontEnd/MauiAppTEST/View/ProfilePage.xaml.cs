using MauiAppTEST.Models;
using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void OnProfileInfoButtonClicked(object sender, EventArgs e)
	{
		Console.WriteLine("hej");
	}

	void LoadUserActivities()
	{
        Dictionary<int, ICollection<Review>> ReviewDictionary = new Dictionary<int, ICollection<Review>>();

    }


}