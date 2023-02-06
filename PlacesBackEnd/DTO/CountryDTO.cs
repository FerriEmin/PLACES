using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public CountryDTO() { }
        public CountryDTO(Country country) => (Id, Name, CountryCode) = (country.Id, country.Name, country.CountryCode);
    }
}
