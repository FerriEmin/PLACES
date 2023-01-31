using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryDTO() { }
        public CategoryDTO(Category category) => (Id, Name) = (category.Id, category.Name);
    }
}
