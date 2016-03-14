using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models
{
    [Table("Banned_Client_History")]
    public class BannedClientHistory
    {

        public int ID { get; set; }
        public string Ip { get; set; }
        public string Country { get; set; }
        public string Geo { get; set; }
        public DateTime Created { get; set; }
        public double? Score { get; set; }
        [Column("Service_Name")]
        public string ServiceName { get; set; }
        [Column("Server_Name")]
        public string ServerName { get; set; }
        public int Service_ID { get; set; }
        public int? Server_ID { get; set; }
        public string Operation { get; set; }

    }
}