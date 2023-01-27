using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Models;
using MauiAppTEST.Services;
using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class ActivityPage : ContentPage
{


    public ActivityPage(ActivityViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        //LoadAllPosts();
    }
    void LoadAllPosts()
    {
        var Posts = PostServices.GetPosts();

        Dictionary<int, ICollection<Review>> ReviewDictionary = new Dictionary<int, ICollection<Review>>();


 

    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //MainThread.BeginInvokeOnMainThread(async () => { await RunService(); });
    }
}






//foreach (var item in Posts)
//{
//    if(item == null) continue;
//    ReviewDictionary.TryAdd(item.Id, item.Reviews);
//}

//foreach (var key in ReviewDictionary)
//{
//    foreach (var review in key.Value)
//    {
//        switch (review.Rating)
//        {
//            case 0:  return;
//            case 1:  star1.IsVisible = true; break;
//            case 2:  star2.IsVisible = true; break;
//            case 3:  star3.IsVisible = true; break;
//            case 4:  star4.IsVisible = true; break;
//            case 5:  star5.IsVisible = true; break;

//        }
//    }
//}