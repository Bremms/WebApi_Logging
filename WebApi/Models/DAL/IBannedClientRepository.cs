using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models.DAL
{
    public interface IBannedClientRepository
    {
        BannedClient FindBy(int banned_id);
        IQueryable<BannedClient> FindAll();
        void Add(BannedClient bannedClient);
        void Delete(BannedClient client);
        void SaveChanges();
    }
}