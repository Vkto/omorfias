using API.Omorfias.Data.Mapping;
using API.Omorfias.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace API.Omorfias.Data.Base
{
    public class OmorfiasContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public OmorfiasContext(DbContextOptions<OmorfiasContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Enterprise> Enterprise { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Premium> Premium { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }
        public DbSet<ServiceLocation> ServiceLocation { get; set; }
        public DbSet<Services> Services { get; set; }

        #region Propriedades


        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public virtual void SetState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(m => m.Id);
            modelBuilder.HasDefaultSchema("dbo");
            //modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
