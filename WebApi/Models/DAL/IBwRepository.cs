using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DAL
{
    public interface IBwRepository
    {
        IBlackAndWhiteElement FindBy(int el_id);
        IQueryable<IBlackAndWhiteElement> FindAll();
        void Add(IBlackAndWhiteElement element);
        void Delete(IBlackAndWhiteElement element);
        void SaveChanges();
    }
}