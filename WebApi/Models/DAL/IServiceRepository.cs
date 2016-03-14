using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models.DAL
{
    public interface IServiceRepository
    {
        Service FindBy(int serviceID);
        IQueryable<Service> FindAll();
        void Add(Service service);
        void Delete(Service service);
        void SaveChanges();
    }
}