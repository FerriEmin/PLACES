namespace PlacesBackEnd.DTO
{
    public class CommentDTO
    {
        // Used in conjunction with commentlist in EventDTO
        public int ReviewId { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public bool Liked { get; set; }
        public DateTime? Date { get; set; }
    }
}
