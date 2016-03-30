using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;
using WebApi.Models.DTO;
using WebApi.Models.Repositories;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/geo")]
    public class GeoController : ApiController
    {
        private readonly GeoRepository geoRepo;
        private readonly DtoOrganiser organiser;

        public GeoController()
        {
            geoRepo = new GeoRepository();
            organiser = new DtoOrganiser();
        }
        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(GeoDto))]
        public IHttpActionResult GetGeo(string ip)
        {
            var s = geoRepo.getGeoFromIp(ip);
            if (s == null)
            {
                return Content(HttpStatusCode.NotFound, $"The geolocation for ip: {ip}, is not found in the database");
            }
            return Ok(organiser.convertGeoToDto(s));
        }
    }
}
