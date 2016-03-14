using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models.DAL
{
    public class Fail2BanInitializer : System.Data.Entity.DropCreateDatabaseAlways<DbEntitiesContext>
    {
        protected override void Seed(DbEntitiesContext context)
        {
           
        }
    }
}