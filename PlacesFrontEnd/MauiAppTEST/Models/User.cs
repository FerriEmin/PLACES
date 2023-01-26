using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.TestData
{
    public class User
    {
        public User()
        {


        }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Post> Activity { get; set; }
        public List<string> CommentList { get; set; }
        public List<bool> Likes { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
