using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestOmgevingFail2ban.Models
{
    [Table("Banned_Client")]
    public class BannedClient
    {
        public int ID { get; set; }
        public string Ip { get; set; }
        public int Count { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Country { get; set; }
        public string Geo { get; set; }
        public DateTime Lastban { get; set; }
        public int Service_ID { get; set; }
        [ForeignKey("Service_ID")]
        public Service Service { get; set; }
        public int? IpScore_ID { get; set; }
        [ForeignKey("IpScore_ID")]
        public virtual IpScore Ipscore { get; set; }
    }
}