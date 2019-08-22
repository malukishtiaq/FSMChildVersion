using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FSMChildVersion.Repository.EntityFramework.GenericHandler
{
    public interface IGenericHandler<TEntity> where TEntity : class
    {
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IQueryable<TEntity> GetAsQuerable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool trackChanges = true);
        TEntity GetByID(object id);

        TEntity Insert(TEntity entity);
        void InsertRange(ICollection<TEntity> entity);
        void DeleteById(object id);
        void Delete(TEntity entityToDelete);
        void DeleteRange(ICollection<TEntity> entity);
        void Update(TEntity entityToUpdate);
        void UpdateRange(ICollection<TEntity> entity);
        void Refresh(TEntity entityToRefresh);
        DbSet<TEntity> DbSet { get; set; }
    }
}
