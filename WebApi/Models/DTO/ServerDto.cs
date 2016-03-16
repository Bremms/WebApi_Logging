using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTO
{
    public class ServerDto
    {
        public string Name { get; set; }
        public int? User_id { get; set; }
        public int Server_id { get; set; }
    }
}