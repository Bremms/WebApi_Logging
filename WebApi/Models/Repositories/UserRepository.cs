using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestOmgevingFail2ban.Models.DAL;

namespace TestOmgevingFail2ban.Models
{
    public class UserRepository : IUserRepository
    {
        private DbEntitiesContext context;
        private DbSet<User> users;
        public UserRepository(DbEntitiesContext context)
        {
            this.context = context;
            this.users = context.Users;
        }
        public void Add(User user)
        {
            users.Add(user);
        }

        public void Delete(User user)
        {
            users.Remove(user);
        }

        public IQueryable<User> FindAll()
        {
            return users;
        }

        public User FindBy(int userID)
        {
            return users.Find(userID);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}