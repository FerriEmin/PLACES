using MauiAppTEST.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiAppTEST.ViewModel
{
    public partial class ActivityViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Activities { get; } = new();

        public ActivityViewModel()
        {

        }
     
    }
}