using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTO
{
    public class ServiceDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Port { get; set; }
        public int Server_ID { get; set; }
        public int? Sub_ID { get; set; }
    }
}