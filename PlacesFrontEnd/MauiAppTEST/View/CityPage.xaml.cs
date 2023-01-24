using MauiAppTEST.TestData;
using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class CityPage : ContentPage
{
    CityViewModel cityViewModel;
    public CityPage()
	{
		InitializeComponent();
		BindingContext = cityViewModel = new CityViewModel();
		//BindingContext = cityViewModel = new ActivityViewModel();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    //		BindingContext = cityViewModel = new CityViewModel();
}

//Gömma visa, isvisible osv activities och city
//Lesson 02a

//Transient, varje gång du öppnar sidan
//Singleton, varje gång du öppnar applikationen