using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models.DAL
{
    public interface ISubscriptionRepository
    {
        Subscription FindBy(int sub_id);
        IQueryable<Subscription> FindAll();
        void Add(Subscription subs);
        void Delete(Subscription subs);
        void SaveChanges();
    }
}