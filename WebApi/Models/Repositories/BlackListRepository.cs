using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models;
using TestOmgevingFail2ban.Models.DAL;
using WebApi.Models.DAL;

namespace WebApi.Models.Repositories
{
    public class BlackListRepository : IBwRepository
    {
        private DbSet<BlackListElement> blackList;
        private DbEntitiesContext context;
        public BlackListRepository(DbEntitiesContext context)
        {
            this.context = context;
            this.blackList = context.BlackList;
        }

        public void Add(IBlackAndWhiteElement element)
        {
            blackList.Add((BlackListElement)element);
        }

        public void Delete(IBlackAndWhiteElement element)
        {
            blackList.Remove((BlackListElement)element);
        }

        public IQueryable<IBlackAndWhiteElement> FindAll()
        {
            throw new NotImplementedException();
        }

        public IBlackAndWhiteElement FindBy(int el_id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public async void SaveChangesAsync()
        {
           await  context.SaveChangesAsync();
        }
    }
}