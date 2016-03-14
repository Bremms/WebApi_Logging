using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models.DAL
{
    public interface IUserRepository
    {
        User FindBy(int userID);
        IQueryable<User> FindAll();
        void Add(User user);
        void Delete(User user);
        void SaveChanges();
    }
}