using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models
{
    [Table("Server")]
    public class Server
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public int? User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual User User { get; set; }
    }
}