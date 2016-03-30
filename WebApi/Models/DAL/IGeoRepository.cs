using System.Security.Cryptography.X509Certificates;
using MaxMind.GeoIP2;

namespace WebApi.Models.DAL
{
    public interface IGeoRepository
    {
        Geo getGeoFromIp(string ip);

    }
}