using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTO
{
    public class PostBanDto
    {
        public string Ip { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string CountryCode { get; set; }
        public string Geo { get; set; }
        public int Service_Id { get; set; }
    }
}