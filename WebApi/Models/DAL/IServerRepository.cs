using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models.DAL
{
    public interface IServerRepository
    {
        Server FindBy(int serverID);
        IQueryable<Server> FindAll();
        void Add(Server server);
        void Delete(Server server);
        void SaveChanges();
    }
}