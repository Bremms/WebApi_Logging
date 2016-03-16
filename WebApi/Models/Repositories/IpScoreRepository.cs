using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models.DAL;

namespace TestOmgevingFail2ban.Models.Repositories
{
    public class IpScoreRepository : IIpScoreRepository
    {
        private DbEntitiesContext context;
        private DbSet<IpScore> scores;
        public IpScoreRepository(DbEntitiesContext context)
        {
            this.context = context;
            this.scores = context.IpScores;
        }
        public void Add(IpScore ipScore)
        {
            this.scores.Add(ipScore);
        }

        public void Delete(IpScore ipScore)
        {
            this.scores.Remove(ipScore);
        }

        public IQueryable<IpScore> FindAll()
        {
            return this.scores;
        }

        public IpScore FindBy(int score_id)
        {
            return this.scores.Find(score_id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Truncate()
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE IpScore");
        }
    }
}