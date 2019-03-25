using Roldaice.Dal.Attributes;
using Roldaice.Dal.Entities;
using Roldaice.Dal.Helpers;
using Roldaice.Helpers.Logger;
using Roldaice.Dal.Migrations;
using Roldaice.IDal.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Runtime.ExceptionServices;
using System.Data.Entity.Validation;

namespace Roldaice.Dal.Context
{
    public class RoldaiceContext : DbContext
    {
        [Dependency]
        public ILogger Logger { get; set; }
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

        public DbSet<TEntity> Repository<TEntity>() where TEntity : class, IEntityBase
        {
            return Set<TEntity>();
        }

        /// <summary>
        /// Commit the changes made in entities. In case of exception, errors are kept in the message
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            var result = false;

            try
            {
                result = SaveChanges() >= 0;
            }
            catch (DbEntityValidationException ex)
            {
                //When DbEntityValidationException occurs, details of the errors are found in ValidationErrors, but there are not log correctly.
                //In this case, we create a new exception and setting the message with the validation errors
                var errorMessages = ex.EntityValidationErrors
                   .SelectMany(x => x.ValidationErrors)
                   .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                var newException = new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                Logger.Error(newException);
                ExceptionDispatchInfo.Capture(newException).Throw();
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }

            return result;
        }

        public bool TransactIt(Action action)
        {
            using (var transaction = Database.BeginTransaction())
            {
                try
                {
                    action();
                    if (!Commit()) throw new Exception("Une erreur est survenue durant l'enregistrement");
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {
                        //When exception occurs on rollback we just log the error and continue
                        Logger.Error(e);
                    }
                    throw;
                }
            }
        }
    }
}
