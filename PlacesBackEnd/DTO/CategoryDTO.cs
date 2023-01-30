using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }

        public CategoryDTO() { }
        public CategoryDTO(Category category) => Name = category.Name;
    }
}
