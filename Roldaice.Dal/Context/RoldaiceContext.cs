using Roldaice.Dal.Attributes;
using Roldaice.Dal.Entities;
using Roldaice.Dal.Helpers;
using Roldaice.Dal.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Dal.Context
{
    public class RoldaiceContext : DbContext
    {

        public RoldaiceContext() : base(nameof(RoldaiceContext))
        {
            Database.SetInitializer<RoldaiceContext>(new MigrateDatabaseToLatestVersion<RoldaiceContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<SqlDefaultValueAttribute, string>(DalConstants.SqlDefaultValue, (p, attributes) => attributes.Single().DefaultValue));
        }
    }
}
