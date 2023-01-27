using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public UserDTO() { }
        public UserDTO(User user) =>
            (FirstName, LastName, Email, Username, Password, DateOfBirth) = (user.FirstName, user.LastName, user.Email, user.Username, user.Password, user.DateOfBirth);
    }
}
