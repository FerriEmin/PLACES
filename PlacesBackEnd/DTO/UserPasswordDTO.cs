namespace PlacesBackEnd.DTO
{
    public class UserPasswordDTO
    {
        public int userId { get; set; }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}