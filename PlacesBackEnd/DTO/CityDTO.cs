using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDTO Country { get; set; }

        public CityDTO() { }
        public CityDTO (City city) => (Id, Name, Country) = (city.Id, city.Name, new CountryDTO(city.Country));
    }
}
