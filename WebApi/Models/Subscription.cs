using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestOmgevingFail2ban.Models
{
    [Table("Subscription")]
    public class Subscription
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual User User { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}