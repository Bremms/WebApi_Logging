using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models.DAL;

namespace TestOmgevingFail2ban.Models.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private DbEntitiesContext context;
        private DbSet<Service> services;
        public ServiceRepository(DbEntitiesContext context)
        {
            this.context = context;
            this.services = context.Services;
        }
        public void Add(Service service)
        {
            services.Add(service);
        }
        public void Delete(Service server)
        {
            List<BannedClient> bannedClients = server.BannedIps.ToList();
            bannedClients.ForEach(bc => context.BannedClients.Remove(bc));
            services.Remove(server);
        }
        
        public IQueryable<Service> FindAll()
        {
            return services.Include(s=>s.BannedIps);
        }
        public Service FindByNameAndServerID(string name,int id)
        {
            return services.Where(w => w.Name.Equals(name) && w.Server_ID == id).FirstOrDefault();
        }
        public Service FindBy(int serviceID)
        {
            return services.Find(serviceID);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public async void SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}