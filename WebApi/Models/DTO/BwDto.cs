using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTO
{
    public class BwDto
    {
        public int ID { get; set; }
        public string Ip { get; set; }
        public DateTime Duration { get; set; }
        public int Server_Id { get; set; }
        public bool Is_Activated { get; set; }
    }
}