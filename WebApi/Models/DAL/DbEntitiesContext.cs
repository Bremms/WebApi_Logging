using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestOmgevingFail2ban.Models
{
    public class DbEntitiesContext : DbContext
    {
        public DbEntitiesContext() : base("mysqlCon") { }
        public DbSet<User> Users { get; set; }
        public DbSet<BannedClient> BannedClients { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<BannedClientHistory> BannedClientsHistory { get; set; }
        public DbSet<IpScore> IpScores { get; set; }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<User>().HasMany(c => c.Servers).WithOptional(c => c.User).HasForeignKey(e=>e.User_ID);
            builder.Entity<User>().HasMany(u => u.Subscriptions).WithRequired(u => u.User).HasForeignKey(u => u.User_ID);
            builder.Entity<Server>().HasMany(s => s.Services).WithRequired(s => s.Server).HasForeignKey(e => e.Server_ID);
            builder.Entity<Service>().HasRequired(s => s.Server).WithMany(s => s.Services).HasForeignKey(s => s.Server_ID);
            builder.Entity<Service>().HasMany(s => s.BannedIps).WithRequired(s => s.Service).HasForeignKey(s => s.Service_ID);
            builder.Entity<Subscription>().HasMany(s => s.Services).WithOptional(ser => ser.Subscription).HasForeignKey(e => e.Subscription_ID);
            builder.Entity<BannedClientHistory>().HasKey(w=>w.ID);
            builder.Entity<IpScore>().HasMany(s => s.BannedClients).WithOptional(b => b.Ipscore).HasForeignKey(b => b.IpScore_ID);

            // Add other non-cascading FK declarations here

            base.OnModelCreating(builder);
        }
    }
}