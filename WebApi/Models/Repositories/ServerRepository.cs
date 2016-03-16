using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestOmgevingFail2ban.Models.DAL;

namespace TestOmgevingFail2ban.Models
{
    public class ServerRepository : IServerRepository
    {
        private DbEntitiesContext context;
        private DbSet<Server> servers;
        public ServerRepository(DbEntitiesContext context)
        {
            this.context = context;
            this.servers = context.Servers;
        }
        public void Add(Server server)
        {
            servers.Add(server);
        }

        public void Delete(Server server)
        {
            List<Service> services = server.Services.ToList();
            List<BannedClient> bannedClients = new List<BannedClient>();
            foreach(Service s in services)
            {
                List<BannedClient> bcList = s.BannedIps.ToList();
                foreach (BannedClient bc in bcList)
                    context.BannedClients.Remove(bc);
                context.Services.Remove(s);
            }
            servers.Remove(server);
        }

        public IQueryable<Server> FindAll()
        {
            return servers;
        }
        public Server FindByName(string name)
        {
            return servers.Where(w => w.Name.Equals(name)).FirstOrDefault();
        }
        public Server FindBy(int serverID)
        {
            return servers.Find(serverID);
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