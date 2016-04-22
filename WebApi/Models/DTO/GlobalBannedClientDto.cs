using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTO
{
    public class GlobalBannedClientDto
    {
        public int Id { get; set; }
        public String Ip { get; set; }
        public Boolean IsGlobalBanned { get; set; }
    }
}