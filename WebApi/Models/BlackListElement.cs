using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models;

namespace WebApi.Models
{
    [Table("BlackList")]
    public class BlackListElement : IBlackAndWhiteElement
    {
        public int ID { get; set; }
        public string Ip { get; set; }
        public DateTime Duration { get; set; }
        public int Server_id { get; set; }
        [ForeignKey("Server_id")]
        public virtual Server Server { get; set; }
    }
}