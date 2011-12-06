using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Achievements.Domain.Repositories;
using Achievements.Domain.Specification;

namespace Achievements.Domain.Infra
{
    public abstract class EFGenericRepository<TEntity> : IRepository<TEntity>  where TEntity : class
    {
        private GameModelContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        protected EFGenericRepository(GameModelContext gameModelContext)
        {
            _dbContext = gameModelContext;
            _dbSet = DataContext.Set<TEntity>();
        }

        protected GameModelContext DataContext
        {
            get { return _dbContext ?? (_dbContext = new GameModelContext()); }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Add(entity);
        }
        
        public void Edit(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Remove(entity);
        }
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var records = Find(predicate);

            foreach (var record in records)
            {
                Delete(record);
            }
        }

        public void Delete(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }
        /*
        public void DeleteRelatedEntities(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var releatedEntities =
                ((IEntityWithRelationships)entity).RelationshipManager.GetAllRelatedEnds().SelectMany(
                    e => e.CreateSourceQuery().OfType<TEntity>()).ToList();
            foreach (var releatedEntity in releatedEntities)
            {
                _dbSet.DeleteObject(releatedEntity);
            }
            _dbSet.DeleteObject(entity);
        }
        */
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAllPaged(int page, int pageSize)
        {
            return _dbSet.AsEnumerable().Skip(pageSize).Take(page);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }

        public IEnumerable<TEntity> Find(ISpecification<Func<TEntity, bool>> specification)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindPaged(int page, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).Skip(pageSize).Take(page).AsEnumerable();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Single(predicate);
        }
        
        public TEntity Single(ISpecification<Func<TEntity, bool>> specification)
        {
            throw new NotImplementedException();
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        public TEntity First(ISpecification<Func<TEntity, bool>> specification)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> criteria)
        {
            return _dbSet.Where(criteria).Count();
        }

        public int Count(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext == null) return;
            _dbContext.Dispose();
            _dbContext = null;
        } 
        #endregion
    }
}
