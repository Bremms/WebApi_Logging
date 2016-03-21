using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models;

namespace WebApi.Models
{
    public interface IBlackAndWhiteElement
    {
        int ID { get; set; }
        string Ip { get; set; }
        DateTime Duration { get; set; }
        int Server_id { get; set; }
        Server Server { get; set; }
    }
}