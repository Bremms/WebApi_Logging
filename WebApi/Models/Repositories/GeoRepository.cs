using MaxMind.GeoIP2;
using WebApi.Models.DAL;

namespace WebApi.Models.Repositories
{
    public class GeoRepository : IGeoRepository
    {
        private readonly DatabaseReader reader;

        public GeoRepository()
        {
            reader = new DatabaseReader("C:\\GeoDatabase\\GeoLite2-City.mmdb");
        }
        public Geo getGeoFromIp(string ip)
        {
            var response = reader.City(ip);
            Geo geo = new Geo();
            geo.Ip = ip;
            geo.CountryCode = response.Country.IsoCode;
            if (response.Location.Latitude != null && response.Location.Longitude != null)
            {
                geo.Latitude = (double) response.Location.Latitude;
                geo.Longitude = (double) response.Location.Longitude;
            }
            geo.GeoCityCountry = $"{response.City}, {response.Country}";
            return geo;
        }
    }
}