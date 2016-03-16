using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models.DAL;

namespace TestOmgevingFail2ban.Models.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private DbEntitiesContext context;
        DbSet<Subscription> subs;
        public SubscriptionRepository(DbEntitiesContext context)
        {
            this.context = context;
            subs = context.Subscriptions;
        }
        public void Add(Subscription subs)
        {
            this.subs.Add(subs);
        }

        public void Delete(Subscription subs)
        {
            this.subs.Remove(subs);
        }

        public IQueryable<Subscription> FindAll()
        {
            return subs;
        }

        public Subscription FindBy(int sub_id)
        {
            return this.subs.Find(sub_id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}