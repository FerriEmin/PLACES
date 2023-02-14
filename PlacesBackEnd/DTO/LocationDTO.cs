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
        public LocationDTO(Location location)
        {
            Id = location.Id;
            Name = location.Name;
            Address = location.Address;
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            City = new CityDTO(location.City);
        }
    }
}
