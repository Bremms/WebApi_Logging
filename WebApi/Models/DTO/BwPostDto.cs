using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTO
{
    public class BwPostDto
    {
        public string Ip { get; set; }
        public DateTime Duration { get; set; }
        public int Server_id { get; set; }
    }
}