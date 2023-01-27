using System.Security.Cryptography;
using System.Text;

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

    public class User2
    {
        public int Id { get; set; }
        public int UserGroup { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        // Relations
        public virtual ICollection<Token> Tokens { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
