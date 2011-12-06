using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Achievements.Domain.Specification;

namespace Achievements.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Saves changes on given context against Database
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Adds entity to the context
        /// </summary>
        /// <param name="entity">Entity</param>
        void Add(TEntity entity);
        /// <summary>
        /// Edits entity on the context
        /// </summary>
        /// <param name="entity">Entity</param>
        /// 
        void Edit(TEntity entity);
        /// <summary>
        /// Deletes entity from the context
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Deletes entity or entities from the context based on given predicate
        /// </summary>
        /// <param name="predicate">where clause</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Deletes entity or entities from the context based on given specification
        /// </summary>
        /// <param name="specification">specification</param>
        void Delete(ISpecification<TEntity> specification);
        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>IEnumerable of entities</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Get all entities as paged
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="pageSize">page size</param>
        /// <returns>IEnumerable of entities as paged</returns>
        IEnumerable<TEntity> GetAllPaged(int page, int pageSize);
        /// <summary>
        /// Finds entity based on given predicate
        /// </summary>
        /// <param name="predicate">where clause</param>
        /// <returns>IEnumerable of entities</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Finds entity based on given specification
        /// </summary>
        /// <param name="specification">specification</param>
        /// <returns>IEnumerable of entities</returns>
        IEnumerable<TEntity> Find(ISpecification<Func<TEntity, bool>> specification);
        /// <summary>
        /// Finds entities as paged based on given predicate
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="predicate">where clause</param>
        /// <returns>IEnumerable of entities as paged</returns>
        IEnumerable<TEntity> FindPaged(int page, int pageSize, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets single entity
        /// </summary>
        /// <param name="predicate">where clause</param>
        /// <returns>Only one entity</returns>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Gets single entity
        /// </summary>
        /// <param name="specification">specification</param>
        /// <returns>Only one entity</returns>
        TEntity Single(ISpecification<Func<TEntity, bool>> specification);
        /// <summary>
        /// Gets first entity
        /// </summary>
        /// <param name="predicate">where clause</param>
        /// <returns>First Entity</returns>
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Gets first entity
        /// </summary>
        /// <param name="specification">specification</param>
        /// <returns>First Entity</returns>
        TEntity First(ISpecification<Func<TEntity, bool>> specification);
        /// <summary>
        /// Gets count
        /// </summary>
        /// <returns>count of entities</returns>
        int Count();
        /// <summary>
        /// Gets count based on given criteria
        /// </summary>
        /// <param name="criteria">where clause</param>
        /// <returns>count of entities</returns>
        int Count(Expression<Func<TEntity, bool>> criteria);
        /// <summary>
        /// Gets count based on given specification
        /// </summary>
        /// <param name="specification">specification</param>
        /// <returns>count of entities</returns>
        int Count(ISpecification<TEntity> specification);

    }
}
