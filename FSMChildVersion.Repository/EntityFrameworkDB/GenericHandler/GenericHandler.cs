using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FSMChildVersion.Repository.EntityFramework.Database;
using FSMChildVersion.Repository.EntityFramework.GenericHandler;
using Microsoft.EntityFrameworkCore;

namespace FSMChildVersion.Repository.EntityFramework
{
    public class GenericHandler<TEntity> : IGenericHandler<TEntity> where TEntity : class
    {
        public SFMDatabaseContext Context { get; set; }
        public DbSet<TEntity> DbSet { get; set; }

        public GenericHandler(SFMDatabaseContext context)
        {
            Context = context;

            Context.Database.EnsureCreated();
            Context.Database.Migrate();

            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            return query.FirstOrDefault();
        }

        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {

            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public virtual IQueryable<TEntity> GetAsQuerable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool trackChanges = true)
        {

            try
            {
                IQueryable<TEntity> query = DbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }
                else
                {
                    return query;
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }
        public virtual void InsertRange(ICollection<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        public virtual void DeleteById(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);

        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Update(entityToUpdate);
        }

        public virtual void Refresh(TEntity entityToRefresh)
        {

            Context.Entry(entityToRefresh).Reload();

        }

        public void DeleteRange(ICollection<TEntity> entity)
        {
            DbSet.RemoveRange(entity);
        }

        public void UpdateRange(ICollection<TEntity> entity)
        {
            DbSet.UpdateRange(entity);
        }
    }
}
