using PlacesDB.Models;

namespace PlacesBackEnd.DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public CityDTO City { get; set; }

        public LocationDTO() { }
        public LocationDTO(Location location) =>
            (Id, Name, Address, Latitude, Longitude, City) = (location.Id, location.Name, location.Address, location.Latitude, location.Longitude, new CityDTO(location.City));
    }
}
