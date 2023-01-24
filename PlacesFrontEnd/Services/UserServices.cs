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
                new User(){ UserName="Prince_Charming69" },
                new User(){ UserName="Janne" },
                new User(){ UserName="Svettig_Runkare" },
                new User(){ UserName="Apan" },
                new User(){ UserName="Peddo_Björnkillen1992" },
                new User(){ UserName="Svettig" },
                new User(){ UserName="Coolaste_Shonon" },
                new User(){ UserName="Mannen123" },
            };

            return userList;
        }
    }
}
