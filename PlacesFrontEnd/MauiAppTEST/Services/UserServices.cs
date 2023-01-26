using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.Services
{
    public class UserServices
    {
        public static List<User> GetUsers()
        {
            List<User> userList = new List<User>()
            {
                new User(){ Username="Prince_Charming69", CommentList = new List<string>() { "HAHAHAHA", "VAD GÖR DU?!??!"} },
                new User(){ Username="Janne", CommentList = new List<string>() { "SVETTIG XD", "WHAT?!", "hehehe, sluta"} },
                new User(){ Username="Svettig_Runkare", CommentList = new List<string>() { "HAHAHAHA", "What's wrong with being racist LuL XD?", "snopp", "mutta" } },
                new User(){ Username="Apan",  CommentList = new List<string>() { "ahmed kommer doda dig mannen" }},
                new User(){ Username="Peddo_Björnkillen1992", CommentList = new List<string>() { "ehh?"}},
                new User(){ Username="Svettig", CommentList = new List<string>() { "bryschaaaaan", "tror du på det själv eller?!"} },
                new User(){ Username="Coolaste_Shonon", CommentList = new List<string>() { "eyy grabbar, loogna er", "nae jag käkar pix o sont du vet, cool kille liksom"} },
                new User(){ Username="Mannen123", CommentList = new List<string>() { "son javla hurra hon e"}, FirstName="Lasse" },
            };

            return userList;
        }
    }
}
