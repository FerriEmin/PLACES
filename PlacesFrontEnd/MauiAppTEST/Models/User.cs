﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.Models
{
    public class User
    {
        public User()
        {

        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<Post> Post { get; set; }
        public List<string> CommentList { get; set; }
        public List<bool> Likes { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
