using AutoMapper;
using Roldaice.Common.Dto.Base;
using Roldaice.Dal.Context;
using Roldaice.Dal.Entities;
using Roldaice.IDal.Interfaces.Dal;
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
    /// Base of the Dal. Contains some base CRUD operations for an entity type and its common dto mapping
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDto">Dto derive from entity</typeparam>
    public abstract class EntityDalBase<TEntity, TDto> : DalBase, IBaseDal<TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
    {

        /// <summary>
        /// Get the repository of the Dal entity type
        /// </summary>
        /// <returns>Repository</returns>
        public DbSet<TEntity> Repository()
        {
            return Context.Repository<TEntity>();
        }

        #region CRUD
        /// <summary>
        /// Get the entity by id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>Dto or null</returns>
        public virtual TDto Get(int id)
        {
            return ToDto(Repository().SingleOrDefault(x => x.Id == id));
        }

        /// <summary>
        /// Check if an entity exist for the given id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>true if the entity exists else false</returns>
        public virtual bool Exists(int id)
        {
            return Repository().Any(x => x.Id == id);
        }

        /// <summary>
        /// Get all the entities
        /// </summary>
        /// <returns>List of Dto</returns>
        public virtual List<TDto> Get()
        {
            return ToDtos(Repository());
        }

        /// <summary>
        /// Insert the dto in the context
        /// </summary>
        /// <param name="dto">Dto to insert</param>
        /// <returns>Saved Dto (with generated elements)</returns>
        public virtual TDto Insert(TDto dto)
        {
            var entity = Repository().Create();
            Repository().Add(entity);

            Mapper.Map(dto, entity);

            Context.Commit();
            return ToDto(entity);
        }

        /// <summary>
        /// Update the dto in the context. Use only if the dto already exists
        /// </summary>
        /// <param name="dto">Dto to update</param>
        /// <returns>Saved Dto (with generated elements)</returns>
        public virtual TDto Update(TDto dto)
        {
            Context.TransactIt(() =>
            {
                var entity = Repository().FirstOrDefault(x => x.Id == dto.Id);
                if (entity == null) throw new Exception($"Entité introuvable : {dto.Id}");

                Mapper.Map(dto, entity);

                Context.Commit();
                dto = ToDto(entity);
            });
            return dto;
        }

        /// <summary>
        /// Insert the dto or upadte it if it arleady exists in the context
        /// </summary>
        /// <param name="dto">Dto to insert or update</param>
        /// <returns>Saved Dto (with generated elements)</returns>
        public virtual TDto InsertOrUpdate(TDto dto)
        {
            if (dto.Id == default(int) || !Exists(dto.Id))
            {
                return Insert(dto);
            }
            else
            {
                return Update(dto);
            }
        }


        /// <summary>
        /// Delete the entity for the given id
        /// </summary>
        /// <param name="id">Id to update</param>
        /// <returns>True if the entity was deleted else false</returns>
        public virtual bool Delete(int id)
        {
            var entity = Repository().FirstOrDefault(x => x.Id == id);
            var result = false;
            if (entity != null)
            {
                Repository().Remove(entity);
            }
            Context.Commit();
            return result;
        }
        #endregion CRUD

        #region mapping
        /// <summary>
        /// Map the given entity to the base dto type
        /// </summary>
        /// <param name="entity">Entity to map</param>
        /// <returns>Entity mapped in a dto</returns>
        protected virtual TDto ToDto(TEntity entity)
        {
            return Mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Map the given entities to the base dto type (by using ToDto(TEntity) method).
        /// </summary>
        /// <param name="entity">Entities to map</param>
        /// <returns>Entities mapped in dtos</returns>
        protected virtual List<TDto> ToDtos(IEnumerable<TEntity> entity)
        {
            return entity.Select(x=>ToDto(x)).ToList();
        }

        /// <summary>
        /// Map the given dto into the given entity
        /// </summary>
        /// <param name="dto">Dto to map</param>
        /// <param name="entity">Existing entity</param>
        /// <returns>Dto mapped into the entity</returns>
        protected virtual TEntity ToEntity(TDto dto, TEntity entity)
        {
            Mapper.Map(dto, entity);
            return entity;                
        }
        #endregion mapping
    }
}
