using MauiAppTEST.TestData;
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
                new User(){ UserName="Prince_Charming69", CommentList = new List<string>() { "HAHAHAHA", "VAD GÖR DU?!??!"} },
                new User(){ UserName="Janne", CommentList = new List<string>() { "SVETTIG XD", "WHAT?!", "hehehe, sluta"} },
                new User(){ UserName="Svettig_Runkare", CommentList = new List<string>() { "HAHAHAHA", "What's wrong with being racist LuL XD?", "snopp", "mutta" } },
                new User(){ UserName="Apan",  CommentList = new List<string>() { "ahmed kommer doda dig mannen" }},
                new User(){ UserName="Peddo_Björnkillen1992", CommentList = new List<string>() { "ehh?"}},
                new User(){ UserName="Svettig", CommentList = new List<string>() { "bryschaaaaan", "tror du på det själv eller?!"} },
                new User(){ UserName="Coolaste_Shonon", CommentList = new List<string>() { "eyy grabbar, loogna er", "nae jag käkar pix o sont du vet, cool kille liksom"} },
                new User(){ UserName="Mannen123", CommentList = new List<string>() { "son javla hurra hon e"}, FirstName="Lasse" },
            };

            return userList;
        }
    }
}
