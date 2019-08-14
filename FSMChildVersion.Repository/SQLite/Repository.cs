using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FSMChildVersion.Repository.SQLite
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection dBConnection;
        public Repository()
        {
            dBConnection = new SQLiteAsyncConnection(Config.LocalDBFile);
        }

        public AsyncTableQuery<T> AsQueryable()
        {
            return dBConnection.Table<T>();
        }

        public Task<List<T>> Get()
        {
            return dBConnection.Table<T>().ToListAsync();
        }

        public Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = dBConnection.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return query.ToListAsync();
        }

        public Task<T> Get(int id)
        {
            return dBConnection.FindAsync<T>(id);
        }

        public Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dBConnection.FindAsync<T>(predicate);
        }

        public Task<int> Insert(T entity)
        {
            return dBConnection.InsertAsync(entity);
        }
        public Task<int> InsertAll(List<T> entity)
        {
            return dBConnection.InsertAllAsync(entity);
        }
        public Task<int> Update(T entity)
        {
            return dBConnection.UpdateAsync(entity);
        }
        public Task<int> Delete(T entity)
        {
            return dBConnection.DeleteAsync(entity);
        }
    }
}
