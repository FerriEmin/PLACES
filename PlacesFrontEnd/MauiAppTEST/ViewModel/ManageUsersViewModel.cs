using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Services;
using MauiAppTEST.TestData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.ViewModel
{
    [QueryProperty(nameof(User), nameof(User))]
    public partial class ManageUsersViewModel : BaseViewModel
    {
        //public ObservableCollection<string> ThisUserCommentList { get; } = new();

        [ObservableProperty]
        User user;


        public ObservableCollection<User> Users = new();



        public ManageUsersViewModel()
        {
            LoadUsers();
            //LoadUserComments();
        }

        //void LoadUserComments()
        //{
        //    var users = UserServices.GetUsers().FirstOrDefault(x => x.UserName == User.UserName);

        //    foreach (var comment in users.CommentList)
        //    {
        //        CommentList.Add(comment);
        //    }
        //}

        public void LoadUsers()
        {

            List<User> users = UserServices.GetUsers();

            foreach (var item in users)
            {
                Users.Add(item);
            }

            //foreach (var user in users)
            //    Users.Add(user);
        }
    }
}
