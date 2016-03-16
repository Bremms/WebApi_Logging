using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTO
{
    public class BannedClientDto
    {
        public int ID { get; set; }
        public string Ip { get; set; }
        public int Count { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Country { get; set; }
        public string Geo { get; set; }
        public DateTime Created { get; set; }
        public int Service_Id { get; set; }
        public int? IpScore_Id { get; set; }
    }
}