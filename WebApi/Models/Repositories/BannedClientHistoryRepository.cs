using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models.DAL;

namespace TestOmgevingFail2ban.Models.Repositories
{
    public class BannedClientHistoryRepository : IBannedClientHistory
    {
        private DbEntitiesContext context;
        private DbSet<BannedClientHistory> clients;
        public BannedClientHistoryRepository(DbEntitiesContext context)
        {
            this.context = context;
            clients = context.BannedClientsHistory;
        }
        public void Add(BannedClientHistory bannedClient)
        {
            clients.Add(bannedClient);
        }

        public void Delete(BannedClientHistory client)
        {
            clients.Remove(client);
        }

        public IQueryable<BannedClientHistory> FindAll()
        {
            return clients;
        }

        public BannedClientHistory FindBy(int banned_id)
        {
            return clients.Find(banned_id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}