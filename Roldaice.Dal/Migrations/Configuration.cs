namespace Roldaice.Dal.Migrations
{
    using Roldaice.Dal.Context;
    using Roldaice.Dal.Helpers;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RoldaiceContext>
    {
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new RoldaiceSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(RoldaiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
