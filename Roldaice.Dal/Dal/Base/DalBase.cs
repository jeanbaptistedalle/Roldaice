using AutoMapper;
using Roldaice.Dal.Context;
using Roldaice.Dal.Entities;
using Roldaice.Helpers.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Roldaice.Dal.Dal.Base
{
    /// <summary>
    /// Base of the Dal which contains dependencies
    /// </summary>
    public abstract class DalBase
    {
        /// <summary>
        /// Database context
        /// </summary>
        [Dependency]
        public RoldaiceContext Context { get; set; }

        /// <summary>
        /// Logger
        /// </summary>
        [Dependency]
        public ILogger Logger { get; set; }

        /// <summary>
        /// Mapper
        /// </summary>
        [Dependency]
        public IMapper Mapper { get; set; }

        /// <summary>
        /// Get the repository for the given entity
        /// </summary>
        /// <typeparam name="TAnotherEntity">Entity type</typeparam>
        /// <returns>Repository for the given entity</returns>
        protected DbSet<TAnotherEntity> Repository<TAnotherEntity>() where TAnotherEntity : EntityBase
        {
            return Context.Repository<TAnotherEntity>();
        }
    }
}
