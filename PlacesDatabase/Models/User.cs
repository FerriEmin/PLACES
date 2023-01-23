using System.Security.Cryptography;
using System.Text;

namespace PlacesDB.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserGroup { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }

        // DateOfBirth
        // Email

        // Relations
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        /*
        public bool VerifyPassword(string input)
        {
            // Salt will always be the half of password column regardless of keysize
            byte[] salt = Hasher.GenerateSalt(Password.Substring(Password.Length / 2, Password.Length / 2));
            return Password.SequenceEqual(Hasher.HashPassword(input, salt));
        }
        */
    }
}
