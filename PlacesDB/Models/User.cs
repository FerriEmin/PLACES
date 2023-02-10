using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace PlacesDB.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserGroup { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;

        // Relations
        public virtual ICollection<Token>? Tokens { get; set; }
        public virtual ICollection<Event>? Events { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
