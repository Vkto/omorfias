using API.Omorfias.Data.Mapping;
using API.Omorfias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

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

        #region Propriedades
 
        public DbSet<User> User { get; set; }

        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public virtual void SetState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
