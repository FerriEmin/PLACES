

namespace PlacesBackEndDB.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relations
        public virtual ICollection<Event> Events { get; set; }
    }
}
