using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CityDTO() { }
        public CityDTO (City city) =>(Id, Name) = (city.Id, city.Name);
    }
}
