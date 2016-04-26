using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestOmgevingFail2ban.Models;
using WebApi.Models.DAL;

namespace WebApi.Models.Repositories
{
    public class WhiteListRepository : IBwRepository
    {
        private DbSet<WhiteListElement> whiteList;
        private DbEntitiesContext context;
        public WhiteListRepository(DbEntitiesContext context)
        {
            this.context = context;
            this.whiteList = context.WhiteList;
        }
        public void Add(IBlackAndWhiteElement element)
        {
            whiteList.Add((WhiteListElement)element);
        }

        public void Delete(IBlackAndWhiteElement element)
        {
            whiteList.Remove((WhiteListElement)element);
        }

        public IQueryable<IBlackAndWhiteElement> FindAll()
        {
            throw new NotImplementedException();
        }

        public WhiteListElement FindBy(int el_id)
        {
            throw new NotImplementedException();
        }
        public Task<WhiteListElement> FindByAsync(int el_id)
        {
            return whiteList.FindAsync(el_id);
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