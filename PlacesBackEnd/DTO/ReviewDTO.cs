using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class ReviewDTO
    {
        public bool Like { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }

        public ReviewDTO() { }
        public ReviewDTO(Review review) => (Like, Comment, Created) = (review.Like, review.Comment, review.Created);


    }
}
