using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; } 

        public UserDTO() { }
        public UserDTO(User user) => (
            Id,
            FirstName,
            LastName,
            ProfileImage,
            Email,
            Username,
            Password,
            DateOfBirth
        ) = (
            user.Id,
            user.FirstName,
            user.LastName,
            user.ProfileImage,
            user.Email,
            user.Username,
            user.Password,
            user.DateOfBirth
        );
    }
}
