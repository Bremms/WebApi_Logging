using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models
{
    [Table("User")]
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Server> Servers { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }

    }
}