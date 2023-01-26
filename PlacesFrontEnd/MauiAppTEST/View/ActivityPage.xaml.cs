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

    }
    void LoadAllPosts()
    {
        var Posts = PostServices.GetPosts();

        Dictionary<int, ICollection<Review>> ReviewDictionary = new Dictionary<int, ICollection<Review>>();

        foreach (var item in Posts)
        {
            ReviewDictionary.TryAdd(item.Id, item.Reviews);
        }

        foreach (var key in ReviewDictionary)
        {
            foreach (var review in key.Value)
            {
               var rating = review.Rating;

                //switch (review.Rating)
                //{
                //    case 0: { }
                //}
            }
        }


        for (int key = 0; key < ReviewDictionary.Keys.Count; key++)
        {
            for (int i = 0; i < ReviewDictionary[key].Count; i++)
            {
            }
        }
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //MainThread.BeginInvokeOnMainThread(async () => { await RunService(); });
    }
}