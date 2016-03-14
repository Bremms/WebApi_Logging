using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models
{
    [Table("Service")]
    public class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Port { get; set; }
        public int Server_ID { get; set; }
        public int? Subscription_ID { get; set; }
        [ForeignKey("Server_ID")]
        public virtual Server Server { get; set; }
        [ForeignKey("Subscription_ID")]
        public virtual Subscription Subscription { get; set; }
        public virtual ICollection<BannedClient> BannedIps { get; set; }
    }
}