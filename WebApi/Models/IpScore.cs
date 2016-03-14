using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models
{
    [Table("IpScore")]
    public class IpScore
    {
        public int ID { get; set; }
        public string Ip { get; set; }
        public double? Score { get; set; }
        public double? Total_score { get; set; }
        public Boolean IsPreviouslyBanned { get; set; }
        public virtual ICollection<BannedClient> BannedClients { get; set; }
    }
}