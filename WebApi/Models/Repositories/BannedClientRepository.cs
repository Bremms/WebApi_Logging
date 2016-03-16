using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestOmgevingFail2ban.Models.DAL;

namespace TestOmgevingFail2ban.Models
{
    public class BannedClientRepository : IBannedClientRepository
    {
        private DbEntitiesContext context;
        private DbSet<BannedClient> bannedClients;

        public BannedClientRepository(DbEntitiesContext context)
        {
            this.context = context;
            this.bannedClients = context.BannedClients;
        }
        public void Add(BannedClient bannedClient)
        {
            bannedClients.Add(bannedClient);
        }

        public void Delete(BannedClient client)
        {
            bannedClients.Remove(client);
        }

        public IQueryable<BannedClient> FindAll()
        {
            return bannedClients.Include(s =>s.Service).Include(b=>b.Ipscore);
        }

        public BannedClient FindBy(int banned_id)
        {
            return bannedClients.Find(banned_id);
        }
        public BannedClient FindByServiceAndIp(int service_id,string ip)
        {
            return bannedClients.Where(b => b.Ip.Equals(ip) && b.Service_ID == service_id).FirstOrDefault();
        }
        public void DeleteList(ICollection<BannedClient> bannedClients)
        {
            foreach(BannedClient bc in bannedClients)
            {
                Delete(bc);
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}