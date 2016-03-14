using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models.DAL
{
    public interface IIpScoreRepository
    {
        IpScore FindBy(int score_id);
        IQueryable<IpScore> FindAll();
        void Add(IpScore ipScore);
        void Delete(IpScore ipScore);
        void Truncate();
        void SaveChanges();
    }
}